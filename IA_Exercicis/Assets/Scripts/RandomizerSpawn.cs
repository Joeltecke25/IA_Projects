using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizerSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public seek prefab;

    public float minRange;
    public float maxRange;

    public bool RandomRange = false;

    private void Start()
    {
        InstantiateObject();
    }

    void InstantiateObject()
    {
        if (RandomRange == true) {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-10, 11), 1, Random.Range(-10, 11));
            Instantiate(prefab, randomSpawnPosition, Quaternion.identity);
        }
        else
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-minRange, maxRange), 1, Random.Range(-minRange, maxRange));
            Instantiate(prefab, randomSpawnPosition, Quaternion.identity);
        }
    }
}
