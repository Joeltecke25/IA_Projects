using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizerSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public float Radius = 1;
    public Transform ItemPrefab;

    void Start()
    {
        SpawnObjectRandom();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObjectRandom()
    {
        Vector3 randomPos = Random.insideUnitCircle * Radius;
        randomPos = ItemPrefab.transform.position;
        //Instantiate(ItemPrefab, randomPos, Quaternion.identity);
    }
}
