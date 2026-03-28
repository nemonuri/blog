---
alias: benchmarkdotnet-fsharp-test
---

# BenchmarkDotNet 으로 F# 성능 테스트하기

## 들어가기

1. 기존 라이브러리가 성능이 좋지 않아서, 내가 새로운 라이브러리를 구현했다.
2. 이제, 내 라이브러리가 기존 라이브러리보다 성능이 좋다는 것을 증명해야 한다.
3. 증명하기 위해, [BenchmarkDotNet](https://benchmarkdotnet.org/) 을 사용하자!

## 증명해야 할 것들

1. 실행 속도가 더 뛰어남.
2. 메모리 할당이 더 적게 발생함.
3. 오류가 전혀 발생하지 않음.

## 템플릿 설치

일단, 템플릿([BenchmarkDotNet.Templates](https://www.nuget.org/packages/BenchmarkDotNet.Templates)) 부터 설치하자.
- F# 도 지원한다!

### 오류?

```
>> dotnet new install BenchmarkDotNet.Templates::0.15.8
dotnet 신규 설치에서 패키지와 버전을 구분하기 위해 "::" 콜론 구분 기호를 "@" 기호로 대체했습니다. 따라서 이 경우 BenchmarkDotNet.Templates::0.15.8 대신 BenchmarkDotNet.Templates@0.15.8 기호를 사용해야 합니다.
```

어쨌든, 템플릿 설치는 성공했다.

### 템플릿 옵션

```
>> dotnet new benchmark --help
Benchmark Project (C#)
작성자 :.NET Foundation and contributors
설명: A project template for creating benchmarks.

사용법:
  dotnet new benchmark [options] [템플릿 옵션]

옵션:
  -n, --name <name>       생성 중인 출력의 이름입니다. 이름을 지정하지 않으면 출력 디렉터리의 이름이 사용됩니다.
  -o, --output <output>   생성된 출력을 배치할 위치입니다.
  --dry-run               템플릿이 생성될 경우 주어진 명령 줄이 실행되면 어떤 일이 발생하는지에 대한 요약을 표시합니다. [default: False]
  --force                 기존 파일을 변경하더라도 콘텐츠를 강제로 생성합니다. [default: False]
  --no-update-check       템플릿을 인스턴스화할 때 템플릿 패키지 업데이트 확인을 사용하지 않도록 설정합니다. [default: False]
  --project <project>     컨텍스트 평가에 사용해야 하는 프로젝트입니다.
  -lang, --language <C#>  인스턴스화할 템플릿 언어를 지정합니다.
  --type <project>        인스턴스화할 템플릿 형식을 지정합니다.

템플릿 옵션:
  -b, --benchmarkName <benchmarkName>   The name of the benchmark class.
                                        유형: string
                                        기본값: Benchmarks
  -f, --framework <net10.0|net9.0|...>  The target framework for the project.
                                        유형: choice
                                          net10.0         .NET 10
                                          net9.0          .NET 9
                                          net8.0          .NET 8
                                          net7.0          .NET 7
                                          net6.0          .NET 6
                                          netstandard2.1  .NET Standard 2.1
                                          netstandard2.0  .NET Standard 2.0
                                          net481          .NET Framework 4.8.1
                                          net48           .NET Framework 4.8
                                          net472          .NET Framework 4.7.2
                                          net471          .NET Framework 4.7.1
                                          net47           .NET Framework 4.7
                                          net462          .NET Framework 4.6.2
  -c, --config                          Adds a benchmark config class.
                                        유형: bool
                                        기본값: false
  --no-restore                          If specified, skips the automatic restore of the project on create.
                                        유형: bool
                                        기본값: false
  --console-app                         If specified, the project is set up as console app.
                                        유형: bool
                                        기본값: true
  -ve, --version <version>              Version of BenchmarkDotNet that will be referenced.
                                        유형: string
                                        기본값: 0.15.8
```

특별한 건 없어 보인다.

## 증명에 필요한 기능들

### 1. [Baselines](https://benchmarkdotnet.org/articles/features/baselines.html)

- '1. 실행 속도가 더 뛰어남.' 을 증명
- 비교 대상에 `[Benchmark(Baseline = true)]` 특성을 추가하면, 내 것이 몇 배나 성능이 뛰어난지 알 수 있다.

#### 예시

- 소스 코드

```cs
using System.Threading;
using BenchmarkDotNet.Attributes;

namespace BenchmarkDotNet.Samples
{
    public class IntroBenchmarkBaseline
    {
        [Benchmark]
        public void Time50() => Thread.Sleep(50);

        [Benchmark(Baseline = true)]
        public void Time100() => Thread.Sleep(100);

        [Benchmark]
        public void Time150() => Thread.Sleep(150);
    }
}
```

- 출력

|  Method |      Mean |     Error |    StdDev | Ratio |
|-------- |----------:|----------:|----------:|------:|
|  Time50 |  50.46 ms | 0.0779 ms | 0.0729 ms |  0.50 |
| Time100 | 100.39 ms | 0.0762 ms | 0.0713 ms |  1.00 |
| Time150 | 150.48 ms | 0.0986 ms | 0.0922 ms |  1.50 |

### 2. MemoryDiagnoser

- '2. 메모리 할당이 더 적게 발생함.' 을 증명
- 클래스에 `[MemoryDiagnoser]` 특성 적용 필요

#### 예시

- 소스 코드

```cs
class Program
{
    static void Main(string[] args)
    {
        BenchmarkRunner.Run<Benchmarks>();
    }
}

[MemoryDiagnoser] // we need to enable it in explicit way
[RyuJitX64Job, LegacyJitX86Job] // let's run the benchmarks for 32 & 64 bit
public class Benchmarks
{
    [Benchmark]
    public byte[] EmptyArray() => Array.Empty<byte>();

    [Benchmark]
    public byte[] EightBytes() => new byte[8];

    [Benchmark]
    public byte[] SomeLinq()
    {
        return Enumerable
            .Range(0, 100)
            .Where(i => i % 2 == 0)
            .Select(i => (byte)i)
            .ToArray();
    }
}
```

- 출력

|     Method | Platform |          Mean |     StdDev |  Gen 0 | Allocated |
|----------- |--------- |-------------- |----------- |------- |---------- |
| EmptyArray |      X86 |     4.4947 ns |  0.0530 ns |      - |       0 B |
| EightBytes |      X86 |     3.1586 ns |  0.0215 ns | 0.0060 |      20 B |
|   SomeLinq |      X86 | 1,600.6928 ns |  7.4951 ns | 0.0132 |     356 B |
| EmptyArray |      X64 |     5.9602 ns |  0.0411 ns |      - |       0 B |
| EightBytes |      X64 |     4.6416 ns |  0.0956 ns | 0.0097 |      32 B |
|   SomeLinq |      X64 | 1,620.6928 ns | 12.6973 ns | 0.0631 |     496 B |

- 출처: [The new MemoryDiagnoser is now better than ever!](https://adamsitnik.com/the-new-Memory-Diagnoser/)

### 3. ExceptionDiagnoser

- '3. 오류가 전혀 발생하지 않음.' 을 증명
- `Exception` 이 얼마나 자주 발생하는지 분석
- 클래스에 `[ExceptionDiagnoser]` 특성 적용 필요

#### 예시

- 소스 코드

```cs
using BenchmarkDotNet.Attributes;
using System;

namespace BenchmarkDotNet.Samples
{
    [ExceptionDiagnoser]
    public class IntroExceptionDiagnoser
    {
        [Benchmark]
        public void ThrowExceptionRandomly()
        {
            try
            {
                if (new Random().Next(0, 5) > 1)
                {
                    throw new Exception();
                }
            }
            catch
            {
                // ignored
            }
        }
    }
}
```

- 출력

|                 Method |     Mean |     Error |    StdDev | Exception frequency |
|----------------------- |---------:|----------:|----------:|--------------------:|
| ThrowExceptionRandomly | 4.936 us | 0.1542 us | 0.4499 us |              0.1381 |

- 출처: [Sample: IntroExceptionDiagnoser](https://benchmarkdotnet.org/articles/samples/IntroExceptionDiagnoser.html)


