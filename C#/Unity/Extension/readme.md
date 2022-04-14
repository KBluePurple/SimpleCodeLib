# 유용한 확장 함수들

`Unity`에서 이용할 수 있는 여러가지 확장 메소드들의 모음

## 사용법

`UsefulExtensions.cs` 스크립트를 만들어 내용을 붙여넣는다.

### 종류

#### TransformExtensions

```cs
void Transform.LookAt2D(Vector2 target)
```

#### MaterialExtensions

```cs
void Material.SetRGB(int r, int g, int b)
```

```cs
void Material.SetRGBA(int r, int g, int b, float a)
```

```cs
void Material.SetRGBA(int r, int g, int b, float a)
```

#### TextExtensions (DummyMonobehaviour.cs 필수)

```cs
WaitForSeconds Text.AnimatedText(string textToAnimate, float timePerChar, [Action onCompleted = null]) // 텍스트를 순차적으로 출력한다.
```
