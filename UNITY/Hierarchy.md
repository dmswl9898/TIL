# 계층

어떤 옵젝2를 끌어다 다른 옵젝1에 넣어주면 종속되어 1을 움직이면 2도 같이 움직임

캐릭터에 메인카메라 종속 시키면 3인칭 시점 게임 가능

standard assets에서 third person~~받아서 캐릭터랑 메인카메라가 따라다닐수있게하고
아바타 바꿔주고 나머지 관련된것들 삭제시킴!



## 큐브 객체 줍기 코드
~~~c#
using System.Collections;

using System.Collections.Generic;

using UnityEngine;

public class SphereControl : MonoBehaviour
{

    private float speed = 10.0f;
    private bool got = false; //잡고있냐


    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);//앞
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);//뒤
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);//왼
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);//오
        }
        //스페이스 누르면 물건 줍기
        if (Input.GetKey(KeyCode.Space))
        { 
            GameObject child = GameObject.Find("Cube") as GameObject;
            if(!got) //물건을 잡고있지않으면
             {
                child.transform.parent = this.transform;
                got = true;
            }
            else
            {
                child.transform.parent = null;
                got = false;

            }
        }
    }
}
