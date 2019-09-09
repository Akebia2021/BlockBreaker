using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeChanger : MonoBehaviour
{
    private GameSession gameSession;
    private bool autoPlay = false;

    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnClick()
    {
        gameSession.SetAutoPlay();
    }
}
