using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBarController : MonoBehaviour
{
    [SerializeField]
    private RectTransform energyBarTransform;

    [SerializeField]
    private float energy;

    private Vector3 scaleChange;

    // Start is called before the first frame update
    void Awake()
    {
        energyBarTransform = gameObject.GetComponent<RectTransform>();
    }

    public void modifyEnergy(float modifier)
    {
        if (energyBarTransform != null)
        {
            energy = modifier;
            scaleChange = new Vector3(1.0f, energy, 1.0f);
            energyBarTransform.localScale = scaleChange;
        }
    }
}
