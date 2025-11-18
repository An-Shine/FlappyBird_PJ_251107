using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class MovePipe : MonoBehaviour
{
    [SerializeField] float speed = 0.6f;
    [SerializeField] BoxCollider2D upPipe;
    [SerializeField] BoxCollider2D downPipe;
    public bool Moving {get;set;} // 오브젝트풀링을 위해 파이프가 움직일지 말지

    
    void Update()
    {
        //게임 상태가 PLAY 일때만 움직이도록
        if (GameManager.Instance.GameState == GameManager.State.PLAY)
        {
            if(Moving)  //Moving 이라는 값이 true 일때만 움직이게
            {
                //파이프의 위치를 speed 만큼 좌로 이동
                transform.position += Vector3.left * speed * Time.deltaTime;        
            }
            
        }
        else if (GameManager.Instance.GameState == GameManager.State.GAMEOVER)
        {
            //게임오버상태에서는 파이프의 충돌이 안일어나게끔
            upPipe.enabled = downPipe.enabled = false;      
        }
    }
}
