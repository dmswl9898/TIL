# 유니티 캐릭터 & 애니메이션

## Assets
- 프로젝트 안에서 사용되는 다양한 리소스들이 모여있는곳
- Images
- Audios
- Scripts
- Models
- Animations
- Prefabs
- 보통 위 요소들로 구성됨
## 캐릭터
Window의 Asset Store(Ctrl + 9)에서 다운로드, 임폴트
### - 프리팹
보통 하늘색 큐브모양

오브젝트

### - 머티리얼

### - 텍스쳐

## 애니메이션
Assets에 Animations 폴더를 만들어서 그안에
Animator Controller를 생성해준다.

이미 다운받은 Asset 캐릭터의 Animation으로 동작들을 넣어준다. 

그리고 그 캐릭터의 inspector의 Animator의 controller에 만든 Animaition을 맞게 넣어준다 (이거 빼먹어서 동작이 안먹길래 잠깐 헤맸다.ㅠㅠ)

* 애니메이션 관련 코드 첨부

public class MainController : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {   
        if(Input.GetKeyDown(KeyCode.Space))//사용자가 Space키를 눌렀을때만 한해서,GetKey면 Space키를 누르고 있을떄 계속 점프
        {
            animator.Play("JUMP00", -1, 0);
            //두번쨰 인자는 레이어, 기본적인 레이어는 -1임
            //세번째 넣어서 시간차 없애줌
        }
        
    }
}