﻿using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DestroyEnemyUpdate();
    }

    public void DamageEnemy(float damage)
    {
        health -= damage;
    }

    void DestroyEnemyUpdate()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
