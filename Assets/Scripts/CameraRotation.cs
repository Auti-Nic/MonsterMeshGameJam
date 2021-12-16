using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float rotationSpeed;
    bool isMovingRight = true;
    public float maxRotationRight;
    public float maxRotationLeft;

    public float pauseTime;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GetRotationZ() >= maxRotationRight)
        {
            isMovingRight = false;
        }

        if (GetRotationZ() <= maxRotationLeft)
        {
            isMovingRight = true;
        }

        if (isMovingRight)
            transform.Rotate(new Vector3(0, 0, 1) * (rotationSpeed * Time.deltaTime));
        else
            transform.Rotate(new Vector3(0, 0, -1) * (rotationSpeed * Time.deltaTime));
    }

    float GetRotationZ()
    {
        float angle = transform.localEulerAngles.z;
        angle = (angle > 180) ? angle - 360 : angle;
        return angle;
    }
}
