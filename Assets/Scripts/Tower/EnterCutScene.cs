﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class EnterCutScene : MonoBehaviour
{
    public PlayableDirector timeline;
    private int counter = 0;
    private float timer = 0;
    private float timerMax = 0;
 
    // Use this for initialization
    void Start()
    {
        timeline = GetComponent<PlayableDirector>();
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            timeline.Stop();
        }
    }
 
    private void OnTriggerExit2D(Collider2D c)
    {
        counter++;
        if (c.gameObject.tag == "Player")
        {
            if(counter == 1){
                if(!Waited(4.8f)){
                    return;
                } 
                timeline.Play(); 
            }
            
        }
    }
    
    private bool Waited(float seconds)
    {
        timerMax = seconds;
        timer += Time.deltaTime;
        if (timer >= timerMax) {return true;}
        return false;
    }
}
