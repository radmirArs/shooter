using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    public List<Transform> pointToSpawn;
    public GameObject enemy;
    private int i;

    // Start is called before the first frame update
    void Start()
    {
        RandomSpawnEnemy();
    }

    void Update()
    {
        
    }

    public void CheckCountEnemyUpdate(int count)
    {
        if(count <=0) 
        {
            RandomSpawnEnemy();
        }
    }
    void RandomSpawnEnemy()
    {
        int count = 0;
        if(count == 5)
        {
            i = Random.Range(0, pointToSpawn.Count);
            Instantiate(enemy, pointToSpawn[i].transform.position, Quaternion.identity);
        }
        
        
    }

}
