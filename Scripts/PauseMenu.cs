using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseUIPrefab;
    [SerializeField] private GameObject pauseUIInsance;

    private GameSession gameSession;

    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();    
    }

    // Update is called once per frame
    void Update()
    {



        if (Input.GetKeyDown("p"))
        {

            if (pauseUIInsance == null)
            {
                pauseUIInsance = GameObject.Instantiate(pauseUIPrefab) as GameObject;
                Time.timeScale = 0f;
                gameSession.isPaused = true;
            }
            else
            {
                Destroy(pauseUIInsance);
                Time.timeScale = 1f;
                gameSession.isPaused = false;
            }
        }
    }
}
