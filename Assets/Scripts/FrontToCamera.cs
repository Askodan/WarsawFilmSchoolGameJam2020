using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontToCamera : MonoBehaviour
{
    // Start is called before the first frame update
    Transform cam;
    private void Awake()
    {
        cam = FindObjectOfType<Camera>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(cam, cam.up);
    }
}
