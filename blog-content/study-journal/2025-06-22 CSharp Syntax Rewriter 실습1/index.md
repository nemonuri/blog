---
alias: csharp-syntax-rewriter-study1
---

# CSharp Syntax Rewriter 실습1

## 학습 목표

1. 나만의 CSharp Syntax Rewriter 를 개발하기 위한 프로젝트를 세팅해본다.
2. CSharp Syntax 를 어떻게 변경해야 할 지, 분석하는 방법을 알아본다.
3. CSharp Syntax Rewriter 의 작동 원리를 알아본다.
4. 간단한 CSharp Syntax Rewriter 의 기능을 구현해본다.

## 프로젝트 목표

- 코드1을 코드2로 고치는 프로그램을 만든다.

**코드1**
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

**코드2**
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
            var v1 = originalPath.AsSpan(0, lastDotIndex);
            return string.Concat(v1, extension);
        }
    }
```

## CSharp Syntax 분석하기

- [RoslynQuoter](https://github.com/KirillOsenkov/RoslynQuoter) 라이브러리를 이용하면, C# 코드의 Syntax를 분석할 수 있다.
  - [데모 웹사이트](https://roslynquoter.azurewebsites.net/) 에서도 실행할 수 있지만, 비효율적이니 툴을 만들어 사용하자.

### 분석 결과

#### 코드1

```csharp
// (전략)
                            Block(
                                SingletonList<StatementSyntax>(
                                    ReturnStatement(
                                        InvocationExpression(
                                            MemberAccessExpression(
                                                SyntaxKind.SimpleMemberAccessExpression,
                                                PredefinedType(
                                                    Token(SyntaxKind.StringKeyword)),
                                                IdentifierName("Concat")))
                                        .WithArgumentList(
                                            ArgumentList(
                                                SeparatedList<ArgumentSyntax>(
                                                    new SyntaxNodeOrToken[]{
                                                        Argument(
                                                            InvocationExpression(
                                                                MemberAccessExpression(
                                                                    SyntaxKind.SimpleMemberAccessExpression,
                                                                    IdentifierName("originalPath"),
                                                                    IdentifierName("AsSpan")))
                                                            .WithArgumentList(
                                                                ArgumentList(
                                                                    SeparatedList<ArgumentSyntax>(
                                                                        new SyntaxNodeOrToken[]{
                                                                            Argument(
                                                                                LiteralExpression(
                                                                                    SyntaxKind.NumericLiteralExpression,
                                                                                    Literal(0))),
                                                                            Token(SyntaxKind.CommaToken),
                                                                            Argument(
                                                                                IdentifierName("lastDotIndex"))})))),
                                                        Token(SyntaxKind.CommaToken),
                                                        Argument(
                                                            IdentifierName("extension"))}))))))
// (후략)
```

#### 코드2

```csharp
// (전략)
                            Block(
                                LocalDeclarationStatement(
                                    VariableDeclaration(
                                        IdentifierName(
                                            Identifier(
                                                TriviaList(),
                                                SyntaxKind.VarKeyword,
                                                "var",
                                                "var",
                                                TriviaList())))
                                    .WithVariables(
                                        SingletonSeparatedList<VariableDeclaratorSyntax>(
                                            VariableDeclarator(
                                                Identifier("v1"))
                                            .WithInitializer(
                                                EqualsValueClause(
                                                    InvocationExpression(
                                                        MemberAccessExpression(
                                                            SyntaxKind.SimpleMemberAccessExpression,
                                                            IdentifierName("originalPath"),
                                                            IdentifierName("AsSpan")))
                                                    .WithArgumentList(
                                                        ArgumentList(
                                                            SeparatedList<ArgumentSyntax>(
                                                                new SyntaxNodeOrToken[]{
                                                                    Argument(
                                                                        LiteralExpression(
                                                                            SyntaxKind.NumericLiteralExpression,
                                                                            Literal(0))),
                                                                    Token(SyntaxKind.CommaToken),
                                                                    Argument(
                                                                        IdentifierName("lastDotIndex"))})))))))),
                                ReturnStatement(
                                    InvocationExpression(
                                        MemberAccessExpression(
                                            SyntaxKind.SimpleMemberAccessExpression,
                                            PredefinedType(
                                                Token(SyntaxKind.StringKeyword)),
                                            IdentifierName("Concat")))
                                    .WithArgumentList(
                                        ArgumentList(
                                            SeparatedList<ArgumentSyntax>(
                                                new SyntaxNodeOrToken[]{
                                                    Argument(
                                                        IdentifierName("v1")),
                                                    Token(SyntaxKind.CommaToken),
                                                    Argument(
                                                        IdentifierName("extension"))})))))
// (후략)
```

코드1에서 `ArgumentList/0/Argument/InvocationExpression` 이 사라지고, \
코드2에서 기존 `ReturnStatement` 앞에 `LocalDeclarationStatement` 이 새로 생긴 것을 확인할 수 있다.

## 프로젝트 세팅

1. C# 프로젝트를 만든다
   - 여기서는 Console 템플릿을 사용

2. 1.의 프로젝트에 [Microsoft.CodeAnalysis.CSharp](https://www.nuget.org/packages/Microsoft.CodeAnalysis.CSharp) 패키지를 추가한다
   - 패키지 버전별로 지원하는 언어 버전은 [여기](https://github.com/dotnet/roslyn/blob/main/docs/wiki/NuGet-packages.md)를 참고

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net9.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>
  
  <ItemGroup>
    <PackageReference Include="Microsoft.CodeAnalysis.CSharp" Version="4.14.0" />
  </ItemGroup>

</Project>
```