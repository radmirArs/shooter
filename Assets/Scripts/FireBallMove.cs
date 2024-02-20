using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FireBallMove : MonoBehaviour
{
    public float speed;
    public float damage = 10;
    public float lifetime;

    void Start()
    {
        Invoke("DestroyFireball", lifetime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        MoveFixedUpdate();
    }

    void MoveFixedUpdate()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    void OnCollisionEnter(Collision collision)
    {
        DamageEnemy(collision);
        DestroyFireball();
    }

    void DestroyFireball()
    {
        Destroy(gameObject);
    }
    
    void DamageEnemy(Collision collision)
    {
        var enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.DamageEnemy(damage);
        }
    }
}

