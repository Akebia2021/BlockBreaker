using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //Indexで次のシーンへ移動する
    public void loadNextScene()
    {
        //ActiveシーンのIndexを取得
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        //currentがシーンのカウントと同じ(最後のシーンなら)最初に戻る
        SceneManager.LoadScene(currentScene + 1);
         
    }
    //最初のシーン （Index0）を読みこむ
    public void loadStartScene()
    {
        //スコアリセット
        FindObjectOfType<GameSession>().resetScore();

        SceneManager.LoadScene(0);

    }
    //終了画面に遷移する
    public void QuitGame()
    {
        Application.Quit();
    }
}
