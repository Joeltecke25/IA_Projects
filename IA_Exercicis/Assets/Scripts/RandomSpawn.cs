using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    
    public bool SpawnRandom = true;
    public float minRange;
    public float maxRange;
    
    void Start()
    {
        RandomizePosition();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            RandomizePosition();

    }
    
    void RandomizePosition()
    {
        if (SpawnRandom == true)
        {
            Vector3 randomSpawnPosition = 
                new(Random.Range(-10, 11), 1, Random.Range(-10, 11));
            transform.position = randomSpawnPosition;
        }
        else
        {
            Vector3 randomSpawnPosition = 
                new(Random.Range(-minRange, maxRange), 1, Random.Range(-minRange, maxRange));
            transform.position = randomSpawnPosition;
        }
    }
}
