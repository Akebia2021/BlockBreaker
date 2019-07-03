using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class level : MonoBehaviour
{
    
    
    //破壊可能ブロックの個数
    [SerializeField] int breakableBlocks;

    //cached reference
    SceneLoader sceneloader;

    
    void Start()
    {
       sceneloader = FindObjectOfType<SceneLoader>();
    }

    //すべてのブロックを数えてその値を返す関数
    public void CountBlocks()
    {
        breakableBlocks++;        
    }

    //ブロックカウントを１減らす
    public void DecreaseBlockCount()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            sceneloader.loadNextScene();
        }
    }

    
}

