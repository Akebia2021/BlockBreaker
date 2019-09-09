using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameSession : MonoBehaviour
{
    //時間のすけーる　
    [SerializeField] private float time = 1f;

    //スコアと加算値
    [SerializeField] private int score = 0;
    [SerializeField] private int addNum = 50;

    [SerializeField] bool isAutoPlayEnabled;

    public bool isPaused { get; set; }


    void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if(gameStatusCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        FindObjectOfType<TextMeshProUGUI>().text = "0";
    }

    void Update()
    {
        Time.timeScale = time;

        //シーン内のTMProコンポーネントのtextパラメータを直接書き換える。
        FindObjectOfType<TextMeshProUGUI>().text = score.ToString();
        
    }

    //各ブロックからCallする
    public void addScore()
    {
        score += addNum;
        score += addNum;
    }

    public void resetScore()
    {
        Destroy(gameObject);
        score = 0;
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }

    public void SetAutoPlay()
    {
        if (isAutoPlayEnabled) isAutoPlayEnabled = false;
        else isAutoPlayEnabled = true;
    }

    
}
