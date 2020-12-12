using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {
  public GameObject[] itemsToGenerate;

  public void spawnItems(Pipe pipe){
    GameObject[,] potential_spots = pipe.getSpawnLocations();

    for(int i = 0; i < potential_spots.GetLength(0); i++)
    {
      for(int j = 0; j < potential_spots.GetLength(1); j++)
      {
        GameObject item = itemsToGenerate[(int)Random.Range(0, itemsToGenerate.Length)];
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
