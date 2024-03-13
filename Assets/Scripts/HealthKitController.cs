using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthKitController : MonoBehaviour
{
    public GameObject player;
    
    private PlayerHealth _healthPlayer;
    public float healAmount;
    void Start()
    {
        InitComponentLinks();
    }

    private void OnTriggerEnter(Collider other)
    {
        var playerHealth = other.gameObject.GetComponent < PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.AddHealth(healAmount);
            Destroy(gameObject);
        }
    }
    
    void InitComponentLinks()
    {
        _healthPlayer =  player.GetComponent<PlayerHealth>();
    }
}
