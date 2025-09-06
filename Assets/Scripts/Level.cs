using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableblocks;


    public void CountBlocks()
    {
        breakableblocks++;
    }

    public void ReduceBlocks()
    {
        breakableblocks--;
    }    

    private void Update()
    {
        if(breakableblocks <= 0)
        {
            FindObjectOfType<SceneLoader>().LoadNextScene();
        }
    }
}
