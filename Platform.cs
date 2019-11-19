using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // Start is called before the first frame update
    public bool Landed { get; private set; }
    public AudioClip scoreSound;
    public AudioSource source;


    private void Start()
    {
        Landed = false;
        source = GetComponent<AudioSource>();
    }

    public void Land()
    {
        if (!Landed)
        {
            Game.Ctx.Score.IncreaseScore(5);
            Landed = true;
            source.PlayOneShot(scoreSound, .7F);
        }
    }
    
   
}
