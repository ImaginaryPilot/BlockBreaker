using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drop : MonoBehaviour
{
    Rigidbody2D myrigidbody;
    void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
        myrigidbody.velocity = new Vector2(0f, -10f);
    }

    void Update()
    {
        
    }
}
