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

## 코드 분리 기능 구현

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

## 분리된 코드에 주석 달기

- LLM을 이용해 주석을 달아보았다.
  - 사용 모델: qwen2.5-coder:7b

### 예시1

- 입력 프롬프트

```
<|im_start|>system
You are a professional senior C# programmer.

<RULE>
1. Add a comment as sentence in Korean for each code line of the given method name.
2. User will input code in <CODE/> block, and method name in <METHOD_NAME/> block.
</RULE>
<|im_end|>
<|im_start|>user
<CODE>
/// <summary>
/// 원본 파일 경로의 확장자를 새 것으로 교체합니다.
/// </summary>
/// <param name = "originalPath">원본 파일 경로</param>
/// <param name = "extension">교체할 새 확장자</param>
/// <returns>확장자가 교체된 파일 경로</returns>
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
</CODE>

<METHOD_NAME>
ChangeExtension
</METHOD_NAME>
<|im_end|>
<|im_start|>assistant
```

- 출력

```csharp
/// <summary>
/// 원본 파일 경로의 확장자를 새 것으로 교체합니다.
/// </summary>
/// <param name="originalPath">원본 파일 경로</param>
/// <param name="extension">교체할 새 확장자</param>
/// <returns>확장자가 교체된 파일 경로</returns>
public static string ChangeExtension(string originalPath, string? extension)
{
    // 원본 파일 경로에서 마지막 '.' 인덱스를 찾습니다.
    int lastDotIndex = originalPath.LastIndexOf('.');
    
    // 만약 '.'이 없다면 확장자를 추가합니다.
    bool b1_1 = lastDotIndex == -1;
    if (b1_1)
    {
        // 원본 파일 경로에 새 확장자를 연결하여 반환합니다.
        return string.Concat(originalPath, extension);
    }
    else
    {
        // '.'이 있다면 '.' 전까지의 부분을 가져옵니다.
        var v2_1 = originalPath.AsSpan(0, lastDotIndex);
        
        // 원본 파일 경로에서 확장자를 제거한 후 새 확장자를 추가하여 반환합니다.
        return string.Concat(v2_1, extension);
    }
}
```

### 예시2

- 입력 프롬프트

```
<|im_start|>system
You are a professional senior C# programmer.

<RULE>
1. Add a comment as sentence in Korean for each code line of the given method name.
2. User will input code in <CODE/> block, and method name in <METHOD_NAME/> block.
</RULE>
<|im_end|>
<|im_start|>user
<CODE>
using RoslynQuoter;


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
</CODE>

<METHOD_NAME>
Main
</METHOD_NAME>
<|im_end|>
<|im_start|>assistant
```

- 출력

```csharp
using RoslynQuoter;

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
        // 명령어를 파싱하여 결과가 없는지 확인합니다. 결과가 있으면 true, 없으면 false
        bool b1_1 = CommandParsingTheory.Parse(args)is not { } parseResult;
        if (b1_1)
        {
            // 파싱된 결과가 없는 경우 메서드를 종료합니다.
            return;
        }

        // 파싱된 결과에서 대상 파일의 전체 경로를 가져옵니다.
        var v2_1 = parseResult.TargetFile.FullName;
        
        // 해당 경로에 있는 C# 텍스트를 읽어옵니다.
        string csharpText = File.ReadAllText(v2_1);

        // RoslynQuoter를 사용하여 C# 코드를 변환합니다.
        Quoter quoter = new Quoter();
        Quoter.ApiCall apiCall = quoter.Quote(csharpText);

        // 변환된 결과를 문자열로 변환합니다.
        var v2_2 = apiCall.ToString();

        // 변환된 결과를 콘솔에 출력합니다.
        Console.WriteLine(v2_2);
    }
}
```

## 주석 달린 코드를 자연어 알고리즘으로

일단, 예시 1만 해보자. 수작업으로.

### 주석 달린 코드

```csharp
/// <summary>
/// 원본 파일 경로의 확장자를 새 것으로 교체합니다.
/// </summary>
/// <param name="originalPath">원본 파일 경로</param>
/// <param name="extension">교체할 새 확장자</param>
/// <returns>확장자가 교체된 파일 경로</returns>
public static string ChangeExtension(string originalPath, string? extension)
{
    // 원본 파일 경로에서 마지막 '.' 인덱스를 찾습니다.
    int lastDotIndex = originalPath.LastIndexOf('.');
    
    // 만약 '.'이 없다면 확장자를 추가합니다.
    bool b1_1 = lastDotIndex == -1;
    if (b1_1)
    {
        // 원본 파일 경로에 새 확장자를 연결하여 반환합니다.
        return string.Concat(originalPath, extension);
    }
    else
    {
        // '.'이 있다면 '.' 전까지의 부분을 가져옵니다.
        var v2_1 = originalPath.AsSpan(0, lastDotIndex);
        
        // 원본 파일 경로에서 확장자를 제거한 후 새 확장자를 추가하여 반환합니다.
        return string.Concat(v2_1, extension);
    }
}
```

### 자연어 알고리즘

#### ChangeExtension

- 요약
  - 원본 파일 경로의 확장자를 새 것으로 교체합니다.
- 반환
  - 확장자가 교체된 파일 경로
- 매개변수
  - **Param1.** 원본 파일 경로
  - **Param2.** 교체할 새 확장자
- 단계
  - **Step1.** 원본 파일 경로에서 마지막 '.' 인덱스를 찾습니다.
  - **Step2.** 만약 '.'이 없다면 확장자를 추가합니다.
    - **Step2.1.** 맞다면, 원본 파일 경로에 새 확장자를 연결하여 반환합니다.
    - **Step2.2.** 아니라면,
      - **Step2.2.1.** '.'이 있다면 '.' 전까지의 부분을 가져옵니다.
      - **Step2.2.2.** 원본 파일 경로에서 확장자를 제거한 후 새 확장자를 추가하여 반환합니다.

### 자문자답

- 질문1: 결과가 마음에 드는가? 아니라면, 그 이유는 무엇인가?

- 답변1
  - 결과, 마음에 안 든다.
  1. 뭘 하자는 건 지 알 수 없다. 자연어 알고리즘이, 인간이 읽고 이해할 수 있는 문서가 아니다.
  2. **Step2.** 에서 **Step2.1.** 또는 **Step2.2.** 으로 연결되는 것이 너무 어색하다. 둘 다 **Step2.**와 연결되는 문장이 아니다.
     - **Step2.**의 동사가 '확인합니다' 여야 자연스럽다.
  3. 각 **Step**이 무엇을 의미하는지 모르겠다. 애매하다.
     - 무엇무엇을 입력받아, 무슨 작업을 수행하는지, 그 의미가 느껴지지 않는다.
     - 정말 평균적인 느낌의 주석이다. 자세함이 엄청 많이 뭉개진 주석.

- 질문2
  - 답변1 에서 명세한 문제들의 원인은, 사람들이 한 줄 짜리 주석은 보통 엄격한 형식 없이 간단하게 작성하기 때문인 것으로 생각된다.
  - LLM이 주석을 엄격한 형식과 함께 작성하게 할 방법은 없는가?

- 답변2: 있다. '메서드'다! 각 줄의 Expression 을, 메서드로 감싸고, 각 메서드에 엄격한 형식을 가진 주석(`<summary>`)을 LLM에게 달게 하자!

## 코드를 메서드로 감싸서 분리하기

수작업으로 진행했다.

- 분리 전

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

- 분리 후

```csharp
/// <summary>
/// 원본 파일 경로의 확장자를 새 것으로 교체합니다.
/// </summary>
/// <param name = "originalPath">원본 파일 경로</param>
/// <param name = "extension">교체할 새 확장자</param>
/// <returns>확장자가 교체된 파일 경로</returns>
public static string ChangeExtension(string originalPath, string? extension)
{
    int lastDotIndex = M1(originalPath);
    if (M2(lastDotIndex))
    {
        return M3(originalPath, extension);
    }
    else
    {
        Span<char> v2_1 = M4(originalPath, lastDotIndex);
        return M5(v2_1, extension);
    }
}

public static int M1(string originalPath)
{
    return originalPath.LastIndexOf('.');
}

public static bool M2(int lastDotIndex)
{
    return lastDotIndex == -1;
}

public static string M3(string originalPath, string extension)
{
    return string.Concat(originalPath, extension);
}

public static Span<char> M4(string originalPath, int lastDotIndex)
{
    return originalPath.AsSpan(0, lastDotIndex);
}

public static string M5(Span<char> v2_1, string extension)
{
    return string.Concat(v2_1, extension);
}
```

### 주석 달기

- LLM을 이용해 주석을 달아보았다.
  - 사용 모델: qwen2.5-coder:7b

- 입력 프롬프트

````
<|im_start|>system
You are a professional C# programmer.

<RULE>
1. Write `<summary>` style comment to each method, in Korean.
</RULE>
<|im_end|>
<|im_start|>user

```csharp
/// <summary>
/// 원본 파일 경로의 확장자를 새 것으로 교체합니다.
/// </summary>
/// <param name = "originalPath">원본 파일 경로</param>
/// <param name = "extension">교체할 새 확장자</param>
/// <returns>확장자가 교체된 파일 경로</returns>
public static string ChangeExtension(string originalPath, string? extension)
{
    int lastDotIndex = M1(originalPath);
    if (M2(lastDotIndex))
    {
        return M3(originalPath, extension);
    }
    else
    {
        Span<char> v2_1 = M4(originalPath, lastDotIndex);
        return M5(v2_1, extension);
    }
}

public static int M1(string originalPath)
{
    return originalPath.LastIndexOf('.');
}

public static bool M2(int lastDotIndex)
{
    return lastDotIndex == -1;
}

public static string M3(string originalPath, string extension)
{
    return string.Concat(originalPath, extension);
}

public static Span<char> M4(string originalPath, int lastDotIndex)
{
    return originalPath.AsSpan(0, lastDotIndex);
}

public static string M5(Span<char> v2_1, string extension)
{
    return string.Concat(v2_1, extension);
}
```

<|im_end|>
<|im_start|>assistant
````

- 출력

```csharp
/// <summary>
/// 원본 파일 경로의 확장자를 새 것으로 교체합니다.
/// </summary>
/// <param name="originalPath">원본 파일 경로</param>
/// <param name="extension">교체할 새 확장자</param>
/// <returns>확장자가 교체된 파일 경로</returns>
public static string ChangeExtension(string originalPath, string? extension)
{
    int lastDotIndex = M1(originalPath);
    if (M2(lastDotIndex))
    {
        return M3(originalPath, extension);
    }
    else
    {
        Span<char> v2_1 = M4(originalPath, lastDotIndex);
        return M5(v2_1, extension);
    }
}

/// <summary>
/// 원본 파일 경로에서 마지막에 있는 '.'의 인덱스를 반환합니다.
/// </summary>
/// <param name="originalPath">원본 파일 경로</param>
/// <returns>'.'의 인덱스 또는 -1(확장자가 없는 경우)</returns>
public static int M1(string originalPath)
{
    return originalPath.LastIndexOf('.');
}

/// <summary>
/// '.'이 원본 파일 경로에 있는지 확인합니다.
/// </summary>
/// <param name="lastDotIndex">'.'의 인덱스</param>
/// <returns>확장자가 없는 경우 true, 그렇지 않으면 false</returns>
public static bool M2(int lastDotIndex)
{
    return lastDotIndex == -1;
}

/// <summary>
/// 원본 파일 경로에서 확장자를 제외한 부분과 새 확장자를 결합하여 새로운 파일 경로를 생성합니다.
/// </summary>
/// <param name="originalPath">원본 파일 경로</param>
/// <param name="extension">교체할 새 확장자</param>
/// <returns>확장자가 교체된 파일 경로</returns>
public static string M3(string originalPath, string extension)
{
    return string.Concat(originalPath, extension);
}

/// <summary>
/// 원본 파일 경로에서 확장자를 제외한 부분을 가져옵니다.
/// </summary>
/// <param name="originalPath">원본 파일 경로</param>
/// <param name="lastDotIndex">'.'의 인덱스</param>
/// <returns>확장자를 제외한 부분의 Span<char></returns>
public static Span<char> M4(string originalPath, int lastDotIndex)
{
    return originalPath.AsSpan(0, lastDotIndex);
}

/// <summary>
/// 확장자를 제외한 부분과 새 확장자를 결합하여 새로운 파일 경로를 생성합니다.
/// </summary>
/// <param name="v2_1">확장자를 제외한 부분의 Span<char></param>
/// <param name="extension">교체할 새 확장자</param>
/// <returns>확장자가 교체된 파일 경로</returns>
public static string M5(Span<char> v2_1, string extension)
{
    return string.Concat(v2_1, extension);
}
```

### 자연어 알고리즘

#### ChangeExtension

- 요약
  - 원본 파일 경로의 확장자를 새 것으로 교체합니다.
- 반환
  - 확장자가 교체된 파일 경로
- 매개변수
  - **Param1.** 원본 파일 경로
  - **Param2.** 교체할 새 확장자
- 단계
  - **Step1.** 원본 파일 경로에서 마지막에 있는 '.'의 인덱스를 반환합니다.
  - **Step2.** '.'이 원본 파일 경로에 있는지 확인합니다.
    - **Step2.1.** 맞다면, 원본 파일 경로에서 확장자를 제외한 부분과 새 확장자를 결합하여 새로운 파일 경로를 생성합니다.
    - **Step2.2.** 아니라면,
      - **Step2.2.1.** 원본 파일 경로에서 확장자를 제외한 부분을 가져옵니다.
      - **Step2.2.2.** 확장자를 제외한 부분과 새 확장자를 결합하여 새로운 파일 경로를 생성합니다.

### 자연어 알고리즘 (수정)

앞의 것도 나쁘진 않은데, \
'단계'를 약간 수정하면 좋을 것 같아.

#### ChangeExtension

- 요약
  - 원본 파일 경로의 확장자를 새 것으로 교체합니다.
- 반환
  - 확장자가 교체된 파일 경로
- 매개변수
  - **Param1.** 원본 파일 경로
  - **Param2.** 교체할 새 확장자
- 단계
  - **Step1.** 원본 파일 경로(**Param1.**)에서 마지막에 있는 '.'의 인덱스를 반환합니다.
  - **Step2.** '.'의 인덱스(**Step1.** 결과)로부터, '.'이 원본 파일 경로에 있는지 확인합니다.
    - **Step2.1.** 맞다면, 원본 파일 경로(**Param1.**)에서 확장자를 제외한 부분과 새 확장자(**Param2.**)를 결합하여 새로운 파일 경로를 생성합니다.
    - **Step2.2.** 아니라면,
      - **Step2.2.1.** 원본 파일 경로에서 확장자를 제외한 부분을 가져옵니다.
      - **Step2.2.2.** 확장자를 제외한 부분과 새 확장자를 결합하여 새로운 파일 경로를 생성합니다.

