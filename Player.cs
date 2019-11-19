using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float hspeed;
    public float vspeed;
    public Rigidbody2D rb;
    

    
    void Start()
    {
        hspeed = 4f;
        vspeed = 4f;
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Horizontal") * hspeed * Time.deltaTime;
        float ver = Input.GetAxis("Vertical") * vspeed * Time.deltaTime;
        
        rb.position = new Vector2(transform.position.x + hor, transform.position.y + ver);

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var platform = other.gameObject.GetComponent<Platform>();
        if (platform != null)
        {
            if(other.otherCollider is EdgeCollider2D)
                platform.Land();

        }
        
        var death = other.gameObject.GetComponent<DeathPlatform>();
        
        if(death != null)
        {
            if(other.collider is EdgeCollider2D)
                Death();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag.Equals("Prize"))
        {
            Game.Ctx.Score.GameWin();
            Game.Ctx.EndGame.GameWin();
            Destroy(this);
            foreach (MovingPlatform move in FindObjectsOfType<MovingPlatform>())
            {
                move.Freeze();
            }
        }

        if (other.gameObject.tag.Equals("Ground"))
        {
            Death();
            
        }

    }


    private void Death()
    {
        Camera.main.transform.SetParent(null);
        Destroy(this);
        Game.Ctx.Score.GameLose();
        Game.Ctx.EndGame.GameLose();
        GetComponent<SpriteRenderer>().enabled = false;
        foreach (MovingPlatform move in FindObjectsOfType<MovingPlatform>())
        {
            move.Freeze();
        }
        
    }
}
