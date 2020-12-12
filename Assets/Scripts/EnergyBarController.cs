using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBarController : MonoBehaviour
{
    [SerializeField]
    private RectTransform energyBarTransform;

    [SerializeField]
    public float energy = 0.5f;

    private Vector3 scaleChange;

    // Start is called before the first frame update
    void Start()
    {
        energyBarTransform = gameObject.GetComponent<RectTransform>();
    }

    public void modifyEnergy(float modifier)
    {
      energy += modifier;
      energy = Mathf.Clamp(energy,0.0f,1.0f);
      scaleChange = new Vector3(1.0f,energy,1.0f);
      energyBarTransform.localScale = scaleChange;
    }
}
