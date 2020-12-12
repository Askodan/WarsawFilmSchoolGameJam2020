using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    [SerializeField]
    private Sprite[] alternatives;
    [SerializeField]
    private SpriteRenderer renderer;
    [SerializeField]
    private float changeFrequency;
    private int index = 0;
    void Awake()
    {
        if (!renderer)
        {
            renderer = GetComponent<SpriteRenderer>();
        }
    }
    void Start()
    {
        StartCoroutine(ChangeSprite());
    }
    IEnumerator ChangeSprite()
    {
        while (true)
        {
            renderer.sprite = alternatives[index];
            index = (int)Mathf.Repeat(++index, alternatives.Length);
            Debug.Log(index);
            yield return new WaitForSeconds(1f / changeFrequency);
        }
    }
}
