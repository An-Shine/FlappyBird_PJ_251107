using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;
using System.Linq;
public class BestScoreCanvas : MonoBehaviour
{
    
    [SerializeField] RankUI[] ranking;

    void Start()
    {
        for(int i = 0; i < ScoreManager.MAX_RANK; i++)
        {
            // 키값이 없으면 "251117120000"의 마지막 값만 바꾼것을 디폴트로 만든다
            string key = PlayerPrefs.GetString($"RANKDATE{i}", $"25111712000{i}");
            int value = PlayerPrefs.GetInt($"RANKSCORE{i}", 0);
            //BestSCore 에 각 랭크 내용 전달
            ranking[i].SetRank(i, value, key);
        }
    }    
}
