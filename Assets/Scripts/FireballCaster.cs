using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCaster : MonoBehaviour
{
    public Transform fireball;
    public Transform pointForSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MouseClickUpdate();
    }

    void MouseClickUpdate()
    {
        if(Input.GetMouseButtonDown(0))
        {
            
            SpawnFireball(); 
        }
    }

    void SpawnFireball()
    {
        Instantiate(fireball, pointForSpawn.transform.position, pointForSpawn.transform.rotation);
        
    }
}
