using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenwidth = 1;
    [SerializeField] float min = 1;
    [SerializeField] float max = 16;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float MousePos = Input.mousePosition.x / Screen.width * screenwidth;
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(MousePos, min, max);
        transform.position = paddlePos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("hit drop");
    }
}
