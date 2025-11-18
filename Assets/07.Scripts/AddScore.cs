using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    [SerializeField] int scoreValue;
    [SerializeField] AudioClip acPoint;

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Player 라는 태그로 들어온 트리거만 인식
        if(collision.gameObject.CompareTag("Player"))
        {
            //scoreValue 값을 실제 scroe 에 업데이트
            ScoreManager.Instance.UpdateScore(scoreValue);
            //점수 획득 소리
            GameManager.Instance.PlayAudio(acPoint);
        }
    }
}
