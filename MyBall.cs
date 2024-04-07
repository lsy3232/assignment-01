using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking.Types;

public class MyBall : MonoBehaviour
{
    Rigidbody rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //rigid.velocity = new Vector3(2, 4, 3); //1. 속력바꾸기

        /* 2. 힘을 가하기
        if(Input.GetButtonDown("Jump")){
            rigid.AddForce(Vector3.up * 25, ForceMode.Impulse);
            Debug.Log((rigid.velocity));
        }
        */

        Vector3 vec = new Vector3(Input.GetAxisRaw("Horizontal"),
        0, Input.GetAxisRaw("Vertical"));
        Input.GetAxisRaw("Horizontal");
        Input.GetAxisRaw("Vertical");

        rigid.AddForce(vec, ForceMode.Impulse);
        
        /*
        //3. 회전력
        rigid.AddTorque(Vector3.up);
        */
    }

    private void OnTriggerStay(Collider other) 
    {
        if(other.name == "Cube")
        {
            rigid.AddForce(Vector3.up*2, ForceMode.Impulse);
        }
    }

    public void Jump()
    {
        rigid.AddForce(Vector3.up*20,ForceMode.Impulse);
    }


    /* 8강 deltaTime
    void Update()
    {
        Vector3 vec = new Vector3(
            Input.GetAxisRaw("Horizontal") * Time.deltaTime,
            Input.GetAxisRaw("Vertical") * Time.deltaTime, 0);
            transform.Translate(vec);
    }


    /* 7강 Vector함수
    Vector3 target = new Vector3(8, 1.5f, 0);

    void Update()
    {
    
        //1. MoveTowards 
        transform.position = 
        Vector3.MoveTowards(transform.position, target, 2f);

        //2. SmoothDamp 
        Vector3 velo = Vector3.zero;

        transform.position = 
        Vector3.SmoothDamp(transform.position, 
        target, ref velo, 0.1f);

        //3. Lerp (선형 보간)
        transform.position =
        Vector3.Lerp(transform.position, target, 0.05f);
        

        //4. Slerp (구면 선형 보간)
        transform.position =
        Vector3.Slerp(transform.position, target, 0.05f);
    }



    /* 6강 키보드 마우스 이동
    void Start()
    {

    }

    void Update()
    {
        Vector3 vec = new Vector3(Input.GetAxis("Horizontal"),
        Input.GetAxis("Vertical"),
        0);
        transform.Translate(vec);
    }


    /*
    void Update()
    {
        /* GetAxis, GeetAxisRaw
        if( Input.anyKeyDown )
        {
            Debug.Log("플레이어가 아무 키를 눌렀습니다.");
        }

        if (Input.GetButton("Horizontal"))
        {
            Debug.Log("횡 이동 중..." + Input.GetAxisRaw("Horizontal"));
        }

        if (Input.GetButton("Vertical"))
        {
            Debug.Log("종 이동 중..." + Input.GetAxisRaw("Vertical"));
        }


        /* GetButton
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("점프!");
        }

        if (Input.GetButton("Jump"))
        {
            Debug.Log("점프 모으는 중...");
        }

        if (Input.GetButtonUp("Jump"))
        {
            Debug.Log("슈퍼 점프!!");
        }


        /* GetMouseButton
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("미사일 발사!");
        }

        if (Input.GetMouseButton(0))
        {
            Debug.Log("미사일 모으는 중...");
        }

        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("슈퍼 미사일 발사!!");
        }


        /* GetKey
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("아이템을 구입하였습니다.");
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("왼쪽으로 이동 중");
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            Debug.Log("오른쪽 이동을 멈추었습니다.");
        }


        /* Input, anyKey
        if ( Input.anyKey )
        {
            Debug.Log("플레이어가 아무 키를 누르고 있습니다.");
        }
        */
    /*}
    
    
    /* 5강
    private void Awake() 
    {
         Debug.Log("플레이어 데이터가 준비되었습니다.");       
    }

    void OnEnable()
    {
        Debug.Log("플레이어가 로그인했습니다.");
    }

    void Start()
    {
        Debug.Log("사냥 장비를 챙겼습니다.");
    }

    void FixedUpdate() 
    {
        Debug.Log("이동~");
    }

    void Update()
    {
        Debug.Log("몬스터 사냥!!");
    }

    void LateUpdate() 
    {
        Debug.Log("경험치 획득.");
    }

    void OnDisable()
    {
        Debug.Log("플레이어가 로그아웃했습니다.");
    }

    void OnDestroy() 
    {
        Debug.Log("플레이어 데이터를 해제하였습니다.");    
    }


    /* 3강
    void Start()
    {
        Debug.Log("Hello Unity!!")
    }
    */
}
