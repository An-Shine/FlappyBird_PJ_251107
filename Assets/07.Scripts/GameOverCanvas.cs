using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameOverCanvas : MonoBehaviour
{
    [SerializeField] Image medal;
    [SerializeField] TMP_Text scoreResult;
    [SerializeField] TMP_Text bestScore;
    [SerializeField] Sprite[] medalSprite;

    // Update is called once per frame
    public void UpdateResult()
    {
        if(ScoreManager.Instance.Rank < 3)
        {
        //메달 표시
        medal.sprite = medalSprite[ScoreManager.Instance.Rank];

        }
        else    
        {
            //메달 이미지 자체를 표시하지않는다
            medal.gameObject.SetActive(false);
        }
        scoreResult.text = ScoreManager.Instance.Score.ToString();
        // 베스트스코어는 최고스코어 값을 보여준다
        

         
    }
    
}
