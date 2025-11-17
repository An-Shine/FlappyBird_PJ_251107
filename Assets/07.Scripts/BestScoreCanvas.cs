using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BestScoreCanvas : MonoBehaviour
{
    public const int MAX_RANK = 5; //최대랭크 보여줄 갯수
    //DateTime 을 string 형식으로바꿀때 쓸 패턴
    public static string DTPattern = @"yyMMddhhmmss";
    [SerializeField] RankUI[] ranking;

    void Start()
    {
        for(int i = 0; i < MAX_RANK; i++)
        {
            // 키값이 없으면 "251117120000"의 마지막 값만 바꾼것을 디폴트로 만든다
            string key = PlayerPrefs.GetString($"RANKDATE{i}", $"25111712000{i}");
            int value = PlayerPrefs.GetInt($"RANKSCORE{i}", 0);
            //BestSCore 에 각 랭크 내용 전달
            ranking[i].SetRank(i, value, key);
        }
    }

    
}
