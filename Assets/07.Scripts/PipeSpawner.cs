using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] float maxTime = 1.5f;      //생성주기
    [SerializeField] float heightRange = 0.5f;  //생성위치y의 랜덤 범위
    [SerializeField] GameObject[] pipePrefab;     //파이프 프리펩 연결
    [SerializeField] GameObject[] redpipePrefab;  //빨간 파이프 프리펩

    const int MAX_PIPE = 3;
    int pipeIndex = 0;

    float timer;

    void Update()
    {
        //게임상태가 PLAY 일때만 파이프를 생성
        if (GameManager.Instance.GameState != GameManager.State.PLAY) return;      
                    
        //timer 가 maxTime 을 넘으면
        if (timer > maxTime)
        {
            SpawnPipe();

            //pipe 만드는 함수 호출
            timer = 0;
            //timer 는 0으로
        }
        timer += Time.deltaTime;
        //timer 에 deltaTime 더해주기
    }
    
    void SpawnPipe()
    {
        //랜덤으로 녹색인지 빨간색인지 파이프 선택
        //GameObject colorpipe = (Random.Range(0,100)> 10) ? pipePrefab : redpipePrefab;
        //랜덤으로 y값을 정해서, 생성될 파이프의 위치 정하기
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange));

        //instantiate 로 생성, 생성된 객체는 pipe 라는 GameObject 에 할당
        //GameObject pipe = Instantiate(colorpipe, spawnPos, Quaternion.identity);

        //5초뒤 pipe 객체 파괴
        //Destroy(pipe, 5.0f);

        //오브젝트풀링
        if(Random.Range(0,100) > 10)        
        {
            //그린파이프
            pipePrefab[pipeIndex].transform.SetPositionAndRotation(spawnPos, Quaternion.identity);
            pipePrefab[pipeIndex].GetComponent<MovePipe>().Moving = true;
        }
        else
        {
            //레드파이프
            redpipePrefab[pipeIndex].transform.SetPositionAndRotation(spawnPos, Quaternion.identity);
            redpipePrefab[pipeIndex].GetComponent<MovePipe>().Moving = true;
        }
        //최대파이프 갯수도달시
        if(++pipeIndex == MAX_PIPE)
        {
            //인덱스를 다시 0으로시작
            pipeIndex = 0;
        }

    }
}
