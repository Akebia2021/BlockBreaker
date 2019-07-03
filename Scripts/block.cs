using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{




    ///[SerializeField] private level level;
    ///今回はfindObjectOfTypeを使用してLevelオブジェクトを参照する
    level level;

    //Sound
    [SerializeField] AudioClip breakSound;
    //VFX
    [SerializeField] GameObject blockSparkles;

    //スプライトを切り替えるための変数
    [SerializeField] int maxHits;
    [SerializeField] int timesHit;
    [SerializeField] Sprite[] spriteHits;
    private void Start()
    {
        //findobjectでlevelスクリプトを参照してブロックの数を数える
        
            level = FindObjectOfType<level>();
            if(tag == "Breakable")
            {
                level.CountBlocks();

            }

        
    }

    //このブロックにボールがあたったときの挙動
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (tag == "Breakable")
        {
            timesHit++;
            if (timesHit == maxHits)
            {
                
                DestroyBlock();
            }
            else
            {
                ShowNextHitSprite();

            }
        }

    }

    //スプライトを切り替える変数
    private void ShowNextHitSprite()
    {
        int spriteindex = timesHit - 1;
        if(spriteHits[spriteindex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = spriteHits[spriteindex];

        }
        else
        {
            Debug.LogError("Block sprite is missing from array" + gameObject.name);
        }
    }

    private void DestroyBlock()
    {
        //カメラの位置で破壊の音を発生させる。
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position, 1.0f);
        //GetComponent<AudioSource>().Play();
        Destroy(gameObject, 0.1f);

        //衝突したらこのブロックをブロックカウントから１減らす
        level.DecreaseBlockCount();

        //GameStatusのScore変数を加算する。
        FindObjectOfType<GameSession>().addScore();
        //instantiate particle
        TriggerSparkles();


        
    }

    private void TriggerSparkles()
    {
        GameObject sparkles = Instantiate(blockSparkles, transform.position, transform.rotation);

        //Particle effectを1秒後に削除
        Destroy(sparkles, 1f);

    }
}
