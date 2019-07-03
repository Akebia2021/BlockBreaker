using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    [SerializeField] paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float ypush = 15f;
    [SerializeField] AudioClip[] ballSounds;

    [SerializeField] float randomFactor = 0.2f;


    //state
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    //キャッシュされたコンポーネントへのリファレンス
    AudioSource myAudioSource;

    Rigidbody2D myrigidbody;

    void Start()
    {
        //initialize ball starting position
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myrigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LocBallToPaddle();
            LaunchOnMouseClick();

        }

    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;

            myrigidbody.velocity = new Vector2(xPush, ypush);
        }
    }

    private void LocBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(UnityEngine.Random.Range(0,randomFactor),
            UnityEngine.Random.Range(0,randomFactor));
        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            
            //GetComponentをせずに最初にメンバ変数として定義しておくこともできる
            //GetComponent<AudioSource>().PlayOneShot(clip);
            myAudioSource.PlayOneShot(clip);

            myrigidbody.velocity += velocityTweak;
        }
    }
}
