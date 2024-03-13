using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float maxSize = 5;
    public float speed = 1;
    public float damage = 50;
    void Start()
    {
        transform.localScale = Vector3.zero;
    }

    void Update()
    {
        transform.localScale += Vector3.one * Time.deltaTime * speed;
        if (transform.localScale.y >= maxSize)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var playerHealth = other.GetComponent<PlayerHealth>();
        var enemyHealth = other.GetComponent<EnemyHealth>();
        if (playerHealth != null)
        {
            playerHealth.DestroyEnemyUpdate(damage);
        }
        if (enemyHealth != null)
        {
            enemyHealth.DamageEnemy(damage);
        }
    }
}
