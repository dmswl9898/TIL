﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UI사용위해서


public class Main_Capsule_Controller : MonoBehaviour
{
    public float moveSpeed = 4.0f;
    public float gap = 3f; //왼,중,오 간격
    private Transform character = null;
    public int life = 5; //생명 5개
    public Transform Barrel; // 배럴 프리팹
    public Transform Center;
    public Transform Right;
    public Transform Middle;
    public Transform Left;
    public Transform Right2;
    public Transform Middle2;
    public Transform Left2;
    public int n = 0;
    public Text timeText; //시간텍스트
    public Text lifeText;  // 생명텍스트
    float time = 0f; //시간
    int frame=30;

    // Start is called before the first frame update
    void Start()
    {
        character = this.gameObject.GetComponent<Transform>(); //메인 캡슐 캐릭터
        lifeText.text = "Life : ♥ ♥ ♥ ♥ ♥";

        int empty = (int)Random.Range(1, 4); //가는길에 Barrel 비워둘 곳.

        if (empty == 1) //왼쪽 비워놓기
        {
            Instantiate(Barrel, Middle.position, Quaternion.identity);
            Instantiate(Barrel, Right.position, Quaternion.identity);
        }
        else if (empty == 2)// 가운데 비워놓기
        {
            Instantiate(Barrel, Left.position, Quaternion.identity);
            Instantiate(Barrel, Right.position, Quaternion.identity);
        }
        else //오른쪽 비워놓기
        {
            Instantiate(Barrel, Middle.position, Quaternion.identity);
            Instantiate(Barrel, Left.position, Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {
       
        move();
        Create_Barrel();
        if (time >= 0)
        {
            time += Time.deltaTime; // 프레임 수 더해준다..((delta.Time으로 어느 컴이든 같게 기준
            timeText.text = "Time : " + time.ToString("F"); //time.Tostring("F")는 소숫점 많이 방출 방지
        }
      
    } //Update

  void move() //캐릭터 기본 이동
    {
       
        character.Translate(Vector3.forward * moveSpeed * Time.deltaTime); //무조건 앞으로 이동함
        Center.Translate(Vector3.forward * moveSpeed * Time.deltaTime); //무조건 가운데에 고정(left, middle, right 고정해줌)
    
        if (Input.GetKeyDown(KeyCode.LeftArrow)) //왼쪽 방향키는 왼쪽
        {
            if (character.position.x  < 1 && character.position.x > -1) //현재 중앙이면
            {
                character.Translate(-gap, 0, moveSpeed * Time.deltaTime); //왼쪽으로

            }
            else if (character.position.x == gap) //현재 오른쪽이면
            {
                character.Translate(-gap, 0, moveSpeed * Time.deltaTime); //중앙으로
            }

        }

        if (Input.GetKeyDown(KeyCode.RightArrow)) // 오른쪽 방향키는 오른쪽
        {
            if (character.position.x < 1 && character.position.x > -1) //현재 중앙이면
            {
                character.Translate(gap, 0, moveSpeed * Time.deltaTime); //오른쪽으로

            }
            else if (character.position.x == -gap) //현재 왼쪽이면
            {

                character.Translate(gap, 0, moveSpeed * Time.deltaTime); //중앙으로

            }
        }
        if(n%15 == 0)
        {
            moveSpeed += 0.1f;
        }
    }

    void Create_Barrel() //배럴 랜덤생성
    {
      
        if (n%frame == 0) //프레임마다 한번씩...frame 작을수록  배럴 더 빠르게 생성.
        {
            
            int empty2 = (int)Random.Range(1, 4); //가는길에 Barrel 비워둘 곳.
          
            if (empty2 == 1) //왼쪽 비워놓기
            {
                Instantiate(Barrel, Middle2.position, Quaternion.identity);
                Instantiate(Barrel, Right2.position, Quaternion.identity);
            }
            else if (empty2 == 2)// 가운데 비워놓기
            {
                Instantiate(Barrel, Left2.position, Quaternion.identity);
                Instantiate(Barrel, Right2.position, Quaternion.identity);
            }
            else //오른쪽 비워놓기
            {
                Instantiate(Barrel, Middle2.position, Quaternion.identity);
                Instantiate(Barrel, Left2.position, Quaternion.identity);
            }
           
        }
        n++;
      
    }
    private void OnTriggerEnter(Collider coll)
    {
        if(coll.tag == "Barrel") //Barrel과 부딪히면
        {
            Debug.Log("충돌 감지 T");
            life--; //생명 하나 줄어듦
            Debug.Log(life);
            Destroy(coll.gameObject); //충돌한 배럴 제거
            if(life == 4)
                lifeText.text = "Life : ♥ ♥ ♥ ♥";
            else if (life == 3)
                lifeText.text = "Life : ♥ ♥ ♥";
            else if (life == 2)
                lifeText.text = "Life : ♥ ♥";
            else if (life == 1)
                lifeText.text = "Life : ♥";
            else
                lifeText.text = "Life : ";
        }
    }
  
}