using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle : MonoBehaviour
{

    [SerializeField] private float min, max;
    [SerializeField] private float screenWidthInUnity = 16f;

    GameSession gameSession;
    ball ball;

    private float mouseXPos;
    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<ball>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameSession.isPaused)
        {
            return;
        }
        else
        {
            //マウスの生の位置を取得し、Screensizeで割って、カメラサイズをかける
            mouseXPos = Input.mousePosition.x /
                Screen.width * screenWidthInUnity;
            //Mouse位置を制限し、YにはPaddleObject自体のTransformコンポーネントから値を取得する。
            Vector2 paddlePos = new Vector2(Mathf.Clamp(getXpos(), min, max), transform.position.y);
            //Transformコンポーネントにマウス位置をVector2型に含めたものを返す。
            transform.position = paddlePos;

        }
    }

    private float getXpos()
    {
        if (gameSession.IsAutoPlayEnabled())
        {
            return ball.transform.position.x;
        }
        else
        {
            return mouseXPos;
        }
    }
   
}
