# 2D 시아각 체크 컴포넌트

## 사용법

- `ViewAngle2D.cs`를 원한는 곳에 `import`한다.
- 보는 주체가 되는 `Gameobject`에 `ViewAngle2D`를 넣는다.
- 스크립트에서 `ViewAngle2D`를 불러온 후 다음과 같이 사용한다.

```cs
var viewAngle2D = GetComponent<ViewAngle2D>();

viewAngle2d.ObjectsInView // 보이는 오브젝트들 GameObject[]
```
