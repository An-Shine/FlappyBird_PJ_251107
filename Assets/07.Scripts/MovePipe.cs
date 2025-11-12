using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class MovePipe : MonoBehaviour
{
    [SerializeField] float speed = 0.6f;

    
    void Update()
    {
        //게임 상태가 PLAY 일때만 움직이도록
        if (GameManager.Instance.GameState == GameManager.State.PLAY)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;        //파이프의 위치를 speed 만큼 좌로 이동
        }
    }
}
