﻿using UnityEngine;
using UnityEngine.UI;

public class BalanceScore : MonoBehaviour
{
    #region 컴포넌트 변수 관련

    // 현재 소지 금액 비례 점수 텍스트 컴포넌트
    public Text balanceScoreText;

    #endregion

    void Start()
    {
        #region 컴포넌트 변수 관련 초기화

        // 현재 소지 금액 비례 점수 텍스트 컴포넌트 할당
        balanceScoreText = GetComponent<Text>();

        #endregion
    }

    void Update()
    {
        #region 제어값 변수 갱신

        // 현재 소지 금액 비례 점수 텍스트로 출력
        balanceScoreText.text = (DataManager.instance.playerGold * 10).ToString();

        #endregion
    }
}
