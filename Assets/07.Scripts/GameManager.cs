using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class GameManager : MonoBehaviour
{

    public enum State
    {
        TITLE,      // 0
        READY,      // 1
        PLAY,       // 2
        GAMEOVER,   // 3
        BESTSCORE   // 4

    }
    public static GameManager Instance;

    [SerializeField] GameObject[] stateUI;
    [SerializeField] SpriteRenderer background;
    [SerializeField] Sprite[] bgSprite;
    [SerializeField] Animator floorAnim;


    State gameState;        //게임상태를 저장할 변수
    public State GameState => gameState;

    //싱글턴
    void Awake()
    {
        if (Instance == null) Instance = this;
        
    }
    void Start()
    {
        Time.timeScale = 1.0f;      //정상적인 게임의 시간의 흐르게
        GameTitle();                //시작은 타이틀에서
    }
    void ChangeState(State value)
    {
        gameState = value;
        //stateUI 에 있는 모든 UI를 끝다
        foreach(var item in stateUI)
        {
            item.SetActive(false);            
        }
        // State 값을 공통으로 사용하므로 미리 int 값으로 변환
        int temp = (int)gameState;
        // 해당하는 Background sprite 연결
        background.sprite = bgSprite[temp % 2];
        //해당하는 stateUI 를 켠다
        stateUI[temp].SetActive(true);
    }
    public void GameTitle() => ChangeState(State.TITLE);    

    public void GameReady()
    {
        ChangeState(State.READY);
    }

    public void GamePlay()
    {
        ChangeState(State.PLAY);
    }

    public void GameBestScore() => ChangeState(State.BESTSCORE);
    

    public void GameOver()
    {
        ChangeState(State.GAMEOVER);
        //게임 시간을 멈춘다
        //Time.timeScale = 0f;
        //바닥애니메이션을 멈춘다
        floorAnim.enabled = false;
        
    }
     //현재 씬을 다시 불러오기
    public void RestartGame() =>SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);    

}
