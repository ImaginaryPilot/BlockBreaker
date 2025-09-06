using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LostScript : MonoBehaviour
{
    [SerializeField] int countballs;

    public void CountBalls()
    {
        countballs++;
    }
    public void ReduceBalls()
    {
        countballs--;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ReduceBalls();
    }

    private void Update()
    {
        if (countballs <= 0)
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }
    }
}
