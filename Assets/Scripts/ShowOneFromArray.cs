using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOneFromArray : MonoBehaviour
{
    [SerializeField]
    private GameObject[] alternatives;
    [SerializeField]
    private float changeFrequency;
    private int index = 0;
    void Start()
    {
        StartCoroutine(ChangeSprite());
    }
    public void Show(int index)
    {
        for (int i = 0; i < alternatives.Length; i++)
        {
            alternatives[i].SetActive(i == index);
        }
    }
    IEnumerator ChangeSprite()
    {
        while (true)
        {
            Show(index);
            index = (int)Mathf.Repeat(++index, alternatives.Length);
            yield return new WaitForSeconds(1f / changeFrequency);
        }
    }
}
