using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [SerializeField] [Range(0.1f, 5f)] float gamespeed = 1f;
    [SerializeField] int blockpointdestroy = 15;
    [SerializeField] TextMeshProUGUI ScoreText;
    public int currentscore;

    private void Awake()
    {
        int gamestatuscount = FindObjectsOfType<GameStatus>().Length;
        if (gamestatuscount > 1)
        {
            gameObject.SetActive(false);    
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        ScoreText.text = currentscore.ToString();
    }
    void Update()
    {
        Time.timeScale = gamespeed;
    }

    public void  PointIncrease()
    {
        currentscore = currentscore + Random.Range(5,blockpointdestroy);
        ScoreText.text = currentscore.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
