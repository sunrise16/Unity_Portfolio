﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultFadeImage : MonoBehaviour
{
    public static ResultFadeImage instance = null;
    private Image fadeImage;
    private float imageAlpha;
    public bool alphaChange;
    public bool exitGame;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        // instance에 할당된 클래스의 인스턴스가 다를 경우 새로 생성된 클래스를 의미
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }

        // 다른 씬으로 넘어가더라도 삭제하지 않고 유지
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        fadeImage = GetComponent<Image>();
        imageAlpha = 1.0f;
        alphaChange = true;
        exitGame = false;
    }

    // Update is called once per frame
    void Update()
    {
        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, imageAlpha);

        if (alphaChange == true)
        {
            imageAlpha -= (Time.deltaTime * 0.4f);

            if (imageAlpha <= 0.0f)
            {
                gameObject.SetActive(false);
            }
        }
        else
        {
            imageAlpha += (Time.deltaTime * 0.4f);

            if (imageAlpha >= 1.0f)
            {
                if (exitGame == false)
                {
                    SceneManager.LoadScene("MainScene");
                }
                else
                {
                #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
                #else
                    Application.Quit();
                #endif
                }
            }
        }
    }
}