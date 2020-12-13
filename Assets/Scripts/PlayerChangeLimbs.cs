using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Limb
{
    public GameObject cyber;
    public SpriteRenderer original;
    public void Load()
    {
      ChangeLimb(false);
    }
    public void ChangeLimb(bool ifcyber)
    {
        if (original)
            original.enabled = !ifcyber;
        cyber.SetActive(ifcyber);
    }
}


public class PlayerChangeLimbs : MonoBehaviour
{
    public Limb HandRight;
    public Limb HandLeft;
    public Limb LegRight;
    public Limb LegLeft;
    public Limb WingRight;
    public Limb WingLeft;

    void Awake()
    {
        HandRight.Load();
        HandLeft.Load();
        LegRight.Load();
        LegLeft.Load();
        WingRight.Load();
        WingLeft.Load();
    }

    void Start()
    {
        // StartCoroutine(changelibtest());
    }

    IEnumerator changelibtest()
    {
        bool cyber = false;
        while (true)
        {
            cyber = !cyber;
            yield return new WaitForSeconds(0.5f);
            HandRight.ChangeLimb(cyber);
            HandLeft.ChangeLimb(cyber);
            LegRight.ChangeLimb(cyber);
            LegLeft.ChangeLimb(cyber);
            WingRight.ChangeLimb(cyber);
            WingLeft.ChangeLimb(cyber);
        }
    }
}
