using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    


    void Update()
    {
        if( Game_Manager.instance.PlayerPos.x +100 < transform.position.x || Game_Manager.instance.PlayerPos.x - 100 > transform.position.x)
        {
            Destroy(gameObject);
        }
        else if(Game_Manager.instance.PlayerPos.y + 100 < transform.position.y || Game_Manager.instance.PlayerPos.y - 100 > transform.position.y)
        {
            Destroy(gameObject);
        }

        if (Game_Manager.instance.PlayerDied)
        {
            Destroy(gameObject);
        }
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
