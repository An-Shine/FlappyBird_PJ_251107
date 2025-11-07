using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdControl : MonoBehaviour
{
    [SerializeField] float velocity = 1.5f;
    [SerializeField] float rotationSpeed = 10.0f;
    Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * velocity;
        }
    }

    void FixedUpdate()
    {
        //update 에서 변경된 velocity.y 값 만큼만 회전
        transform.rotation = Quaternion.Euler(0,0,rb.velocity.y*rotationSpeed);
    }
}
