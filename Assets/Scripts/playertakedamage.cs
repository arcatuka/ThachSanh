﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playertakedamage : MonoBehaviour
{
    int dmg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger != true && col.CompareTag("Player"))
        {
            col.SendMessageUpwards("Damage", dmg);
        }

    }
}
