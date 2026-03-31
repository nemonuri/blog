---
alias: git-tag-how-to-use
---

# git tag 로 특정 커밋에 이름 붙이기

## 들어가기

### 현재 상황

1. 저장소를 싹 갈아엎고 싶다.
   - 핵심 파일 및 폴더 이름 바꾸기
   - 불필요한 파일 및 폴더 제거

2. 하지만 필요할 때 다시 찾을 수 있게 하고 싶다.
   - 이름 바꾸기를 잘못 했다가 의존성이 꼬이면 복구할 수 있어야 한다.
   - 제거했던 코드가 나중에 다시 필요할 수도 있다.
   
### 해결책

1. 현재 커밋에 특별한 '이름'을 붙이면 된다.

2. `git tag` 를 이용해 특정 커밋에 이름을 붙일 수 있다.

## 이름 짓기

1. `v{버전}` 형식으로 태그 이름을 짓는 것이 관례.

2. 버전은 [Semantic Versioning](https://semver.org/) 규칙을 따르는 것이 좋다.

- 예시

```
v6.0.33
v8.0.8
v9.0.0-preview.4.24266.19
v9.0.0-rc.2.24473.5
```

## Annotated Tags

(TODO)

```
$ git tag -a v1.4 -m "my version 1.4"
```

## Push Tag

(TODO)

## 참고자료

- [Git Basics - Tagging](https://git-scm.com/book/en/v2/Git-Basics-Tagging)

