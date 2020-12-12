using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRotation : MonoBehaviour
{
    public Vector3 rotationAxis = Vector3.forward;
    public float dumpThreshold = 0.1f;
    public float accelerationPower = 100;
    public float dumpPower = 50;
    public float speedLimit = 300;
    private float steering;
    private float currentRotation;
    private float rotationSpeed;

    private void Update()
    {
        CalculateSpeed();
        UpdateRotation();
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
