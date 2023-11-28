using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(0, Input.GetAxisRaw("Vertical"));

        rb2d.MovePosition(rb2d.position + speed * Time.fixedDeltaTime * movement);
        LimitMovement();
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
