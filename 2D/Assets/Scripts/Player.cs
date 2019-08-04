using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D body;
    GameManager gameManager;

    float horizontal;
    float vertical;

    public float runSpeed = 5.0f;

    void Start ()
    {
        body = GetComponent<Rigidbody2D>();
        gameManager =FindObjectOfType<GameManager>();
    }

    void Update ()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical"); 
        if (!gameManager.IsRunning())
        {
            body.velocity = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        if (!gameManager.IsRunning())
        {
            return;
        }
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        var zombieCol = col.collider  as BoxCollider2D;
        if (zombieCol != null)
        {
            // must be zombie
            gameManager.PlayerHit();
        }
    }
}
