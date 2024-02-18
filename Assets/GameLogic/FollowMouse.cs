using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public Camera isometricCamera;
    public float groundPlaneHeight = 0f; // Adjust if your ground plane is not at y = 0

    void Update()
    {
        FollowMousePosition();
    }

    void FollowMousePosition()
    {
        Plane groundPlane = new Plane(Vector3.up, new Vector3(0, groundPlaneHeight, 0));
        Ray ray = isometricCamera.ScreenPointToRay(Input.mousePosition);

        if (groundPlane.Raycast(ray, out float position))
        {
            Vector3 targetPoint = ray.GetPoint(position);
            transform.position = targetPoint;
        }
    }
}
