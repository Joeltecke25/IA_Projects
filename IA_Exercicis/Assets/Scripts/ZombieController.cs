using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public AIVision zombiePrefab;
    public int numberOfZombies;
    public static Transform playerTransform;

    private List<AIVision> zombies = new List<AIVision>();
    public static bool playerDetected = false;

    void Start()
    {
        for (int i = 0; i < numberOfZombies; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-5, 5), 0.5f, Random.Range(-5, 5));
            AIVision newZombie = Instantiate(zombiePrefab, randomPosition, Quaternion.identity);
            zombies.Add(newZombie);
        }
    }

    private void Update()
    {
        foreach(AIVision zombies in zombies)
        {
            zombies.Vision();
        }

        if (playerDetected)
        {
            foreach(AIVision z in zombies)
            {
                z.SendMessage("Chase");
            }
        }
        else
        {
            foreach(AIVision z in zombies)
            {
                z.SendMessage("Wander");

            }
        }
    }
}
