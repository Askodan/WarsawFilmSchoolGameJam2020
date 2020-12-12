using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProgress : MonoBehaviour
{

    public PipeSystem pipeSystem;

    private float velocity;
    public float levelLength = 1f;
    public float LevelLength { get { return levelLength; } }

    private float startVelocity;

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
        startVelocity = velocity;
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
        float velDiff = velocity - startVelocity;
        if (Mathf.Abs(velDiff) > 0.01f)
        {
            velocity -= velDiff * 0.01f;
        }

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
<<<<<<< HEAD
      velocity = amount;
=======
        velocity += amount;
        velocity = Mathf.Clamp(velocity, 1.0f, 20.0f);
>>>>>>> 964f6d7149966db99f16a19c1fe5d58e3ee61453
    }
}
