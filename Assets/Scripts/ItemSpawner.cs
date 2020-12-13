using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] itemsToGenerate;
    public float skipChance;
    public GameObject[] badItemsToGenerate;
    public float badSkipChance;

    public Pose[] allowedPositions;

    public void Start()
    {
        allowedPositions = FindObjectOfType<PlayerPose>().availablePoses;
    }

    virtual public void spawnItems(Pipe pipe)
    {
        Debug.Log("Spawning new items");
        GameObject[,] potential_spots = pipe.getSpawnLocations();

        for (int i = 0; i < potential_spots.GetLength(0); i++)
        {
            Pose pose = allowedPositions[(int)Random.Range(0, allowedPositions.Length)];
            for (int j = 0; j < potential_spots.GetLength(1); j++)
            {
                GameObject item;
                if (pose.TakenFields[j])
                {
                    if (skipChance > Random.Range(0, 1.0f))
                        continue;
                    item = itemsToGenerate[(int)Random.Range(0, itemsToGenerate.Length)];
                }
                else
                {
                    if (badSkipChance > Random.Range(0, 1.0f))
                        continue;
                    item = badItemsToGenerate[(int)Random.Range(0, badItemsToGenerate.Length)];
                }
                Instantiate(
                  item,
                  potential_spots[i, j].transform.position,
                  Quaternion.identity,
                  pipe.transform
                );
            }
        }
    }
}
