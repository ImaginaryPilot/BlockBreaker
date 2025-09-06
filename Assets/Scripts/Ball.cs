using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] AudioClip[] ballsounds;
    [SerializeField] float RandomFactor = 0.2f;
    bool hasStarted = false;
    [SerializeField] bool firsttime = true;

    Vector2 PadtoBallVec;
    AudioSource audioSource;
    Rigidbody2D myrigidbody;
    Vector2 BallPos;
    LostScript countallballsingame;
    void Start()
    {
        PadtoBallVec = transform.position - paddle1.transform.position;
        audioSource = GetComponent<AudioSource>();
        myrigidbody = GetComponent<Rigidbody2D>();
        countallballsingame = FindObjectOfType<LostScript>();
        countallballsingame.CountBalls();
    }

    void Update()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        BallPos = paddlePos + PadtoBallVec;
        if (!hasStarted)
        {
            transform.position = BallPos;
            if (firsttime == false|| Input.GetMouseButtonDown(0))
            {
                myrigidbody.velocity = new Vector2(4f, 10f);
                hasStarted = true;
                firsttime = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocitytweek = new Vector2(Random.Range(-RandomFactor, RandomFactor), Random.Range(-RandomFactor, RandomFactor));
        if (hasStarted)
        {
            AudioClip clip = ballsounds[Random.Range(0, ballsounds.Length)];
            audioSource.PlayOneShot(clip);
            myrigidbody.velocity += velocitytweek; 
        }
    }

    
}
