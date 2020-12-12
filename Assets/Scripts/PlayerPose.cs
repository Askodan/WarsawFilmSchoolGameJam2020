using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPose : MonoBehaviour
{
    public Pose[] availablePoses;
    private int currentPose;

    public int CurrentPose { get => currentPose; }

    void Start()
    {
        for (int i = 0; i < availablePoses.Length; i++)
        {
            if (currentPose == i)
                availablePoses[i].Show();
            else
                availablePoses[i].Hide();
        }
    }

    private void OnChangePose(InputValue value)
    {
        float steering = value.Get<float>();
        int change = (int)Mathf.Sign(steering);
        ChangeCurrentPose(change);
    }
    private void ChangeCurrentPose(int change)
    {
        availablePoses[currentPose].Hide();
        currentPose = (int)Mathf.Repeat(currentPose + change, availablePoses.Length);
        availablePoses[currentPose].Show();
    }
}
