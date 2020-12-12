using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Modifier[] modifiers;
    public GameObject effect;
    public float destroyTime = 1f;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player p = other.gameObject.GetComponentInParent(typeof(Player)) as Player;
            p.affect(modifiers);
            effect.SetActive(true);

            StartCoroutine(DestroyLater(destroyTime));
        }
    }
    IEnumerator DestroyLater(float when)
    {
        var grab_effect = Instantiate(effect, transform.position, transform.rotation);
        int children = transform.childCount;
        for (int i = 0; i < children; ++i)
            transform.GetChild(i).gameObject.SetActive(false);
        yield return new WaitForSeconds(when);
        Destroy(grab_effect.gameObject);
        Destroy(gameObject);
    }
}
