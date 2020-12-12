using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    AudioSource source;
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    void OnEnable()
    {
        source.Play();
    }
}
