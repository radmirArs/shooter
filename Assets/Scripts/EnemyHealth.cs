using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100;
    
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
