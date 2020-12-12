using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {
  public GameObject[] itemsToGenerate;

  public void OnEnter (Pipe pipe) {
    SpawnItems(pipe);
  }
  private void SpawnItems(Pipe pipe){

  }
}
