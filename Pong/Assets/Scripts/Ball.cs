using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour, IManager
{
    [SerializeField] private Vector2 initialVelocity;
    [SerializeField] private float minVelocity = 10f;
    [SerializeField] GameObject Manager;
    GameManager gameManager;
    private Vector3 CurrentVelocity;
    private Rigidbody2D rb2d;
    private Vector2 OriginPos;
    

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(initialVelocity.x, Random.Range(-5, 5));
        gameManager = Manager.GetComponent<GameManager>();
        OriginPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentVelocity = rb2d.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "LeftWall")
        {
            gameManager.EnemyScoreUpdate();
            transform.position = OriginPos;
            rb2d.velocity = new Vector2(initialVelocity.x, Random.Range(-5, 5));

        }
        else if (collision.gameObject.tag == "RightWall")
        {
            gameManager.PlayerScoreUpdate();
            transform.position = OriginPos;
            rb2d.velocity = new Vector2(-1 * initialVelocity.x, Random.Range(-5, 5));
        }
        var speed = CurrentVelocity.magnitude;
        var direction = Vector3.Reflect(CurrentVelocity.normalized, collision.contacts[0].normal);

        Debug.Log("Out Direction: " + direction);
        rb2d.velocity = direction * Mathf.Max(speed, minVelocity);
    }


}
