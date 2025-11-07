using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class MovePipe : MonoBehaviour
{
    [SerializeField] float speed = 0.6f;

    
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;        //파이프의 위치를 speed 만큼 좌로 이동
    }
}
