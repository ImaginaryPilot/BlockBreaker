using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breaksound;
    [SerializeField] Sprite[] hitsprites;
    [SerializeField] int randomnumbers;
    [SerializeField] int timesHit;
    Level level;
    Ball ball;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            timesHit++;
            int blockhealth = hitsprites.Length + 1;
            if (blockhealth <= timesHit)
            {
                DestroyBlock();
            }
            else
            {
                int spriteindex = timesHit - 1;
                if (hitsprites[spriteindex] != null)
                {
                    GetComponent<SpriteRenderer>().sprite = hitsprites[spriteindex];
                }
                else
                {
                    Debug.Log("Block missing array" + gameObject.name);  
                }
            }
        }
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breaksound, Camera.main.transform.position);
        level.ReduceBlocks();
        var point = FindObjectOfType<GameStatus>();
        point.PointIncrease();
        Destroy(gameObject);
    }

    private void Start()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }

        randomnumbers = Random.Range(0, 7);
        ball = FindObjectOfType<Ball>();
    }


}
