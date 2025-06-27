---
alias: code-to-natural-language-algorithm_raw
---

# 코드를 자연어 알고리즘으로

## 들어가기

- 개인적으로, 어떤 알고리즘을 자연어로 표현하는 것 보다, 그냥 코딩하는 게 더 쉽다.
  - IDE가 오류도 척척 잡아준다.
  - 알고리즘을 실제로 실행해 볼 수도 있다.

- 이 문서에서 '알고리즘'은, '구현 방식 기획'과 의미가 비슷하다.

### 그냥 코딩하면 되잖아?

- 문제는, '의사소통' 이다.
- 대부분의 사람들은 코드의 의미를 이해하지 못한다.
  - 코드에 주석 달아도 마찬가지다.
  - 사실상, 그 코드를 작성한 나만 이해할지도...
- 사람들에게 내 생각을 전달하기 위해서는, 코드 대신 '자연어 알고리즘'을 표현해야 한다.

## 코드 vs 자연어 알고리즘 예시

### 상황

- 주어진 파일 경로의 확장자를 새 것으로 바꾸려 한다.

### 코드

```csharp
public static string ChangeExtension(string originalPath, string? extension)
{
    int lastDotIndex = originalPath.LastIndexOf('.');
    if (lastDotIndex == -1)
    {
        return string.Concat(originalPath, extension);
    }
    else
    {
        return string.Concat(originalPath.AsSpan(0, lastDotIndex), extension);
    }
}
```

### 자연어 알고리즘

**주어진 정보:**
1. 원본 파일 경로
2. 새 확장자

**실행 과정:**
1. '원본 파일 경로'에서 '.'의 마지막 위치를 얻는다.
2. `1.의 결과`가 -1 과 같은지 확인한다.
    1. 맞다면, '원본 파일 경로'와 '새 확장자'를 연결하고, 그 결과를 반환한다.
    2. 아니라면,
        1. '원본 파일 경로'를 0번째부터 (`1.의 결과` - 1)번째까지 잘라낸다.
        2. `2.ii.a.의 결과`와 '새 확장자'를 연결하고, 그 결과를 반환한다.

#### 사담

사실 저 자연어 알고리즘도 썩 마음에 드는 건 아닌데...일단 저 정도로 할 수 있는 걸 목표로 하자.

## 코드-자연어 알고리즘 대응시키기

- 자연어 알고리즘의 각 줄이, 코드의 어떤 부분과 대응되는지, 코드와 주석으로 표현해보자.

```csharp
/// <param name="originalPath">원본 파일 경로</param>
/// <param name="extension">교체할 새 확장자</param>
public static string ChangeExtension(string originalPath, string? extension)
{
    // 1. '원본 파일 경로'에서 '.'의 마지막 위치를 얻는다.
    int lastDotIndex = originalPath.LastIndexOf('.');

    // 2. `1.의 결과`가 -1 과 같은지 확인한다.
    if (lastDotIndex == -1)
    {
        // 1. 맞다면, '원본 파일 경로'와 '새 확장자'를 연결하고, 그 결과를 반환한다.
        return string.Concat(originalPath, extension);
    }
    else
    {
        // 2. 아니라면,
        // 1. '원본 파일 경로'를 0번째부터 (`1.의 결과` - 1)번째까지 잘라낸다.
        var v1 = originalPath.AsSpan(0, lastDotIndex);
        // 2. `2.ii.a.의 결과`와 '새 확장자'를 연결하고, 그 결과를 반환한다.
        return string.Concat(v1, extension);
    }
}
```

### 일단은...

저 '분리' 부터 구현해야 하려나.

```csharp
        return string.Concat(originalPath.AsSpan(0, lastDotIndex), extension);
```
↓
```csharp
        var v1 = originalPath.AsSpan(0, lastDotIndex);
        return string.Concat(v1, extension);
```

이것 말고도, 분리해야 할 게 많겠지..

## 구현

- 코드를 주석 달기 좋은 형태로 고치는 걸 구현하는 데 성공했다.
  - TODO: 프로젝트 디렉토리를, 접근성 좋은 오픈소스 저장소 형태로 만들어 공개하기

### 예시 1

- 입력

```csharp
    public static string ChangeExtension(string originalPath, string? extension)
    {
        int lastDotIndex = originalPath.LastIndexOf('.');
        if (lastDotIndex == -1)
        {
            return string.Concat(originalPath, extension);
        }
        else
        {
            return string.Concat(originalPath.AsSpan(0, lastDotIndex), extension);
        }
    }
```

- 출력

```csharp
public static string ChangeExtension(string originalPath, string? extension)
{
    //
    int lastDotIndex = originalPath.LastIndexOf('.');
    //
    bool b1_1 = lastDotIndex == -1;
    if (b1_1)
    {
        //
        return string.Concat(originalPath, extension);
    }
    else
    {
        //
        var v2_1 = originalPath.AsSpan(0, lastDotIndex);
        //
        return string.Concat(v2_1, extension);
    }
}
```

### 예시 2

- 입력

```csharp
using RoslynQuoter;

namespace Nemonuri.RoslynQuoters;

/// <summary>
/// 프로그램
/// </summary>
public static class Program
{
    /// <summary>
    /// 이 프로그램의 진입점입니다.
    /// </summary>
    /// <param name="args">명령어</param>
    public static void Main(string[] args)
    {
        if (CommandParsingTheory.Parse(args) is not { } parseResult) { return; }

        string csharpText = File.ReadAllText(parseResult.TargetFile.FullName);

        Quoter quoter = new Quoter();
        Quoter.ApiCall apiCall = quoter.Quote(csharpText);

        Console.WriteLine(apiCall.ToString());
    }
}
```

- 출력

```csharp
using RoslynQuoter;

namespace Nemonuri.RoslynQuoters;
/// <summary>
/// 프로그램
/// </summary>
public static class Program
{
    /// <summary>
    /// 이 프로그램의 진입점입니다.
    /// </summary>
    /// <param name = "args">명령어</param>
    public static void Main(string[] args)
    {
        //
        bool b1_1 = CommandParsingTheory.Parse(args)is not { } parseResult;
        if (b1_1)
        {
            //
            return;
        }

        //
        var v2_1 = parseResult.TargetFile.FullName;
        //
        string csharpText = File.ReadAllText(v2_1);
        //
        Quoter quoter = new Quoter();
        //
        Quoter.ApiCall apiCall = quoter.Quote(csharpText);
        //
        var v2_2 = apiCall.ToString();
        //
        Console.WriteLine(v2_2);
    }
}
```