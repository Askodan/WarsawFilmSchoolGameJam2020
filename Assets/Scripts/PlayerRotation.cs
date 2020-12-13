using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRotation : MonoBehaviour
{
    public Vector3 rotationAxis = Vector3.forward;
    public float dumpThreshold = 0.1f;
    private float accelerationPower;
    public float normalAccelerationPower = 50;
    public float bumpedAccelerationPower = 100;
    private float dumpPower;
    public float normalDumpPower = 25;
    public float bumpedDumpPower = 50;
    public float speedLimit = 300;
    private float steering;
    private float currentRotation;
    private float rotationSpeed;

    public void Start()
    {
      accelerationPower = normalAccelerationPower;
      dumpPower = normalDumpPower;
    }

    private void Update()
    {
        CalculateSpeed();
        UpdateRotation();
    }

    public void bumpAcceleration()
    {
      accelerationPower = bumpedAccelerationPower;
    }
    public void debumpAcceleration()
    {
      accelerationPower = normalAccelerationPower;
    }
    public void bumpDumpPower()
    {
      dumpPower = bumpedDumpPower;
    }
    public void debumpDumpPower()
    {
      dumpPower = normalDumpPower;
    }

    private void CalculateSpeed()
    {
        if (Mathf.Abs(steering) >= dumpThreshold)
        {
            rotationSpeed -= steering * accelerationPower * Time.deltaTime;
            rotationSpeed = Mathf.Clamp(rotationSpeed, -speedLimit, speedLimit);
        }
        else
        {
            rotationSpeed = Mathf.MoveTowards(rotationSpeed, 0f, dumpPower * Time.deltaTime);
        }
    }

    private void UpdateRotation()
    {
        currentRotation += rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(rotationAxis * currentRotation);
    }
    private void OnRotation(InputValue value)
    {
        steering = value.Get<float>();
    }
}
