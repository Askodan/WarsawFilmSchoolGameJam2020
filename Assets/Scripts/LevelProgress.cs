using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProgress : MonoBehaviour
{

    public PipeSystem pipeSystem;

    public float velocity;
    public float levelLength;


    private Pipe currentPipe;
    private float distanceTraveled;

    private float deltaToRotation;
    private float systemRotation;
    private float worldRotation, avatarRotation;

    private Transform world;

    public float DistanceTraveled { get => distanceTraveled; }

    private void Start()
    {
        world = pipeSystem.transform.parent;
        currentPipe = pipeSystem.SetupFirstPipe();
        Debug.Log(currentPipe);
        SetupCurrentPipe();
    }

    private void SetupCurrentPipe()
    {
        deltaToRotation = 360f / (2f * Mathf.PI * currentPipe.curveRadius);
        worldRotation += currentPipe.relativeRotation;

        if (worldRotation < 0f)
        {
            worldRotation += 360f;
        }
        else if (worldRotation >= 360f)
        {
            worldRotation -= 360f;
        }
        world.localRotation = Quaternion.Euler(worldRotation, 0f, 0f);
    }

    private void Update()
    {
        float delta = velocity * Time.deltaTime;
        distanceTraveled += delta;
        systemRotation += delta * deltaToRotation;

        if (systemRotation >= currentPipe.curveAngle)
        {
            delta = (systemRotation - currentPipe.curveAngle) / deltaToRotation;
            currentPipe = pipeSystem.SetupNextPipe();
            deltaToRotation = 360f / (2f * Mathf.PI * currentPipe.curveRadius);
            SetupCurrentPipe();
            systemRotation = delta * deltaToRotation;
        }

        pipeSystem.transform.localRotation =
            Quaternion.Euler(0f, 0f, systemRotation);
    }
}
