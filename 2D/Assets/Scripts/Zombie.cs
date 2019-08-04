using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    Rigidbody2D body;
    Rigidbody2D player;

    float horizontal;
    float vertical;

    public float runSpeed = .5f;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>(); 
        player = FindObjectOfType<Player>().GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = player.position.x - body.position.x;
        horizontal = Mathf.Clamp(horizontal, -1f, 1f);
        vertical = player.position.y - body.position.y;
        vertical = Mathf.Clamp(vertical, -1f, 1f);
    }
    private void FixedUpdate()
    {  
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

}
