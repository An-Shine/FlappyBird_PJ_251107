using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GMState = GameManager.State;

public class BirdControl : MonoBehaviour
{
    [SerializeField] float velocity = 1.5f;
    [SerializeField] float rotationSpeed = 10.0f;
    [SerializeField] Animator flapAnim;
    [SerializeField] Animator birdAnim;
    Rigidbody2D rb;
    GameManager gmi;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //처음 시작시, 안떨어지게 중력값 조정
        rb.gravityScale = 0;
        gmi = GameManager.Instance;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))    //마우스클릭을 하면 위로 움직임
        {
            //게임상태가 READY면
            if (gmi.GameState == GameManager.State.READY)
            {
                //게임상태를 Play 로 바꾸고
                gmi.GamePlay();
                rb.gravityScale = 1.0f;
            }
            //게임상태가 PLAY면
            else if (gmi.GameState == GameManager.State.PLAY)
            {
                
                rb.velocity = Vector2.up * velocity;
            }
           
        }
    }

    void FixedUpdate()
    {
        //update 에서 변경된 velocity.y 값 만큼만 회전
        transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * rotationSpeed);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //게임 PLAY 일때만 충돌 감지
        if (gmi.GameState != GMState.PLAY) return;

        gmi.GameOver();

        //새의 Flap 애니메이션을 멈춘다
        //GetComponent<Animator>().enabled = false;
        flapAnim.enabled = false;
    }

    public void BirdReady()
    {
        // 새를 뒤로 움직인다
        birdAnim.SetTrigger("Ready");
    }

    public void OffBirdAnimator()
    {
        birdAnim.enabled = false;
    }
    
}
