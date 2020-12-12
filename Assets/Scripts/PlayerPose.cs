using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPose : MonoBehaviour
{
    Animator anim;
    public Pose[] availablePoses;
    private int currentPose;

    public int CurrentPose { get => currentPose; }

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }
    void Start()
    {
    }

    private void OnChangePose(InputValue value)
    {
        float steering = value.Get<float>();
        int change = (int)Mathf.Sign(steering);
        ChangeCurrentPose(change);
    }
    private void ChangeCurrentPose(int change)
    {
        anim.SetInteger("Action", currentPose);
        currentPose = (int)Mathf.Repeat(currentPose + change, availablePoses.Length);
    }
}
