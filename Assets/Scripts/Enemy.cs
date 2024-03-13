using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;

    //speed and direction of the enemy, should be defined on creation
    public float speed;
    public Vector2 direction;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        rb.AddForce(new Vector2(direction.x * speed, direction.y * speed));
    }

    //when player hits object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Game_Manager.instance.destroyPlayer();
        }
    }
}
