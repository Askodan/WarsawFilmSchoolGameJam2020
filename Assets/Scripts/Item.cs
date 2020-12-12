using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
  public Modifier[] modifiers;

  void OnTriggerEnter(Collider other)
  {
    if(other.gameObject.tag == "Player")
    {
      Player p = other.gameObject.GetComponentInParent(typeof(Player)) as Player;
      p.affect(modifiers);
      Destroy(gameObject);
    }
  }
}
