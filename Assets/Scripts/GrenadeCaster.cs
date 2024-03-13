using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeCaster : MonoBehaviour
{
    public Transform pointForSpawn;
    public Rigidbody _grenade;
    public float force;

    void Update()
    {
        MouseClickUpdate();
    }

    void MouseClickUpdate()
    {
        if (Input.GetMouseButtonDown(1))
        {

            SpawnGrenade();
        }
    }

    void SpawnGrenade()
    {
        var grenade = Instantiate(_grenade, pointForSpawn.transform.position, pointForSpawn.transform.rotation);
        grenade.GetComponent<Rigidbody>().AddForce(pointForSpawn.forward*force);
    }
    
}
