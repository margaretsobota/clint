using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : Platform
{
    // Start is called before the first frame update
    public float speed;
    public float rightLimit;
    public float leftLimit;
    public float curr;
    public float dir;
    public float timeScale;
    void Start()
    {
        speed = .2f;
        rightLimit = transform.position.x + 2.4f;
        leftLimit = transform.position.x;
        dir = 1f;
        timeScale = Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        curr = transform.position.x;
        if (curr <= leftLimit)
            dir = 1f;
        
        if (curr >= rightLimit) 
            dir = -1f;
        
        transform.position = new Vector2 (transform.position.x + (dir * speed * timeScale), transform.position.y);
        
    }

    public void Freeze()
    {
        timeScale = 0;
    }
    
    

    
    
    
    
    
}
