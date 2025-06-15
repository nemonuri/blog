---
alias: install-ollama-and-run
---

# Ollama 설치 및 실행

## 학습 목표

1. Ollama 를 설치하고 간단한 AI 채팅을 해 본다.
2. Ollama 의 여러가지 설정에 대해 알아본다.
3. Ollama 의 여러가지 명령어에 대해 알아본다.

## Ollama 란?

- [대규모 언어 모델(LLM)](https://en.wikipedia.org/wiki/Large_language_model)을 개인용 컴퓨터, 즉 로컬에서도 실행할 수 있게 하는 프로그램.
- [공식 홈페이지](https://ollama.com/)에서 설치 프로그램을 다운받을 수 있다.

## Ollama Windows 설치 경로

- Windows OS 에서, 기본 설치 경로는 `%LOCALAPPDATA%\Programs\Ollama` 이다.
- 설치 프로그램(OllamaSetup.exe)을 다음과 같이 실행하면, 설치 경로를 변경할 수 있다.
```pwsh
OllamaSetup.exe /DIR="d:\some\location"
```

(작성중)

## 참고자료

- [ollama 공식 Github repository](https://github.com/ollama/ollama)
- [Ollama Windows 가이드](https://github.com/ollama/ollama/blob/main/docs/windows.md)