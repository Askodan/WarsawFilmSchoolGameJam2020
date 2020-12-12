using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProgress : MonoBehaviour
{

    public PipeSystem pipeSystem;

    private float velocity;
    public float levelLength = 1f;
    public float LevelLength { get { return levelLength; } }

    private Pipe currentPipe;
    private float distanceTraveled;

    private float deltaToRotation;
    private float systemRotation;
    private float worldRotation, avatarRotation;

    private Transform world;

    public float DistanceTraveled { get => distanceTraveled; }
    public float Progress { get; private set; }
    private void Start()
    {
        world = pipeSystem.transform.parent;
        currentPipe = pipeSystem.SetupFirstPipe();
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
        Progress += Time.deltaTime;

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

    public void modifySpeed(float amount)
    {
      velocity = amount;
    }
}
