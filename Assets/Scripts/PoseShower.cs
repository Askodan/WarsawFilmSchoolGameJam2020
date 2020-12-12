using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerPose))]
public class PoseShower : MonoBehaviour
{
    PlayerPose playerPose;
    void Awake()
    {
        playerPose = GetComponent<PlayerPose>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
