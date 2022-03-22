# 2D 시아각 체크 컴포넌트

`Unity2D`에서 이용할 수 있는 일정 거리 내의 콜라이더를 가진 오브젝트 중 시아에 들어오는 오브젝트를 찾는 용도의 컴포넌트

## 사용법

- `ViewAngle2D.cs`를 원한는 곳에 `import`한다.
- 보는 주체가 되는 `Gameobject`에 `ViewAngle2D`를 넣는다.
- 스크립트에서 `ViewAngle2D`를 불러온 후 다음과 같이 사용한다.

```cs
var viewAngle2D = GetComponent<ViewAngle2D>();

viewAngle2d.ObjectsInView // 보이는 오브젝트들 GameObject[]
```
