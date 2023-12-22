﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.timeScale > 0)
            {
                Time.timeScale = 0.3f;
                Time.fixedDeltaTime = Time.timeScale * Time.fixedDeltaTime;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }
}
