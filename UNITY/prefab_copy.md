# 프리팹 복사

### 1. Instantiate(프리팹, 위치, 방향);

 - 지정한 위치에 프리팹을 만든다.

### 2. Transform obj = Instantiate(프리팹, 위치, 방향) as Transform;

 - 프리팹을 만들고 변수 obj에 할당한다. 1과 달리 2는 복제한 프리팹에 추가적인 처리를 할 수 있다.

 게임 실행 중에 복제되는 프리팹은 하이어라키 뷰에 Clone으로 표시되고 싱행을 중지시키면 사라진다.