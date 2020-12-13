using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnerMenu : ItemSpawner
{
    int index = 0;
    bool allowSpawn = false;

    public bool AllowSpawn { get => allowSpawn; set => allowSpawn = value; }

    new public void Start()
    {
    }

    override public void spawnItems(Pipe pipe)
    {
        if (allowSpawn && index < itemsToGenerate.Length)
        {
            Debug.Log("Spawning new items");
            Vector3 temp = Vector3.zero;
            GameObject[,] potential_spots = pipe.getSpawnLocations();
            int count = potential_spots.GetLength(0) * potential_spots.GetLength(1);
            for (int i = 0; i < potential_spots.GetLength(0); i++)
            {
                for (int j = 0; j < potential_spots.GetLength(1); j++)
                {
                    temp += potential_spots[i, j].transform.position;
                }
            }
            if (count == 0)
                return;
            Vector3 pos = new Vector3(temp.x / count, temp.y / count, temp.z / count);
            GameObject item = itemsToGenerate[index];
            Instantiate(
              item,
              pos,
              Quaternion.identity,
              pipe.transform
            );
            index++;
            allowSpawn = false;
        }
    }
}
