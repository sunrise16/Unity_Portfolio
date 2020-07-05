﻿using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    #region 제어값 변수 관련

    // 카메라 회전 속도 (카메라를 마우스 움직이는 방향으로 회전하기)
    public float speed = 150.0f;
    // 회전 각도를 직접 제어할 변수
    private float angleX;

    #endregion

    void Update()
    {
        #region 지속적으로 실행할 함수 실행

        if (GameManager.instance.isGameOver == false && GetComponent<PlayerFSM>().playerStop == false)
        {
            // 플레이어 회전 처리 함수
            Rotate();
        }

        #endregion
    }

    #region 플레이어 회전 처리 함수

    void Rotate()
    {
        float h = Input.GetAxis("Mouse X");

        angleX += h * speed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, angleX, 0);
    }

    #endregion
}
