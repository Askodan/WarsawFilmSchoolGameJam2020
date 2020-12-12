using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRotation : MonoBehaviour
{
    public float rotationSpeed;
    public float rotationAcceleration;
    public float rotationDump;

    private float steering;
    private float currentRotation;

    private void Update()
    {
        CalculateSpeed();
        UpdateRotation();
    }
    private void CalculateSpeed()
    {
        if (steering != 0f)
        {
            rotationSpeed -= steering * rotationAcceleration * Time.deltaTime;
        }
        else
        {
            rotationSpeed = Mathf.MoveTowards(rotationSpeed, 0f, rotationDump * Time.deltaTime);
        }
    }
    private void UpdateRotation()
    {
        currentRotation += rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0f, 0f, currentRotation);
    }
    private void OnRotation(InputValue value)
    {
        steering = value.Get<float>();
    }
}
