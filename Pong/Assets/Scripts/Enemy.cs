using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb2d;
    private Vector2 movement;
    public GameObject Ball;
    void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
        Ball = GameObject.FindGameObjectWithTag("Ball");
    }

    void Update()
    {
        
    }
    void FixedUpdate()
    {
        ChaseBall();
        LimitMovement();
    }
    
    private void ChaseBall()
    {
        movement = new Vector2(0, 0);
        float difference = Ball.transform.position.y - this.transform.position.y;
        if (difference > 0.7)
        {
            movement = new Vector2(0, (float) 0.7);
        }
        else if(difference < - 0.7)
        {
            movement = new Vector2(0, (float) -0.7);
        }
        rb2d.MovePosition(rb2d.position + speed * Time.fixedDeltaTime * movement);
    }
    private void LimitMovement()
    {
        if (transform.position.y > 3.75)
        {
            transform.position = new Vector2(transform.position.x, (float)3.75);
        }
        else if (transform.position.y < -3.75)
        {
            transform.position = new Vector2(transform.position.x, (float)-3.75);
        }

    }
}
