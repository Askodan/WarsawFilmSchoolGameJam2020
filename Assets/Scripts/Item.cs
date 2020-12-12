using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
  void OnTriggerEnter(Collider other)
  {
    Debug.Log("Collision");
    if(other.gameObject.tag == "Player")
    {
      Player p = other.gameObject.GetComponentInParent(typeof(Player)) as Player;
      p.affect();
      Destroy(gameObject);
    }
  }
}
