using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public Camera secondaryCamera;
    public Transform target; // The target the secondary camera should focus on
    public Vector3 offset = new Vector3(0, 0, -10); // Offset from the target

    void Start()
    {
        if (secondaryCamera == null)
        {
            Debug.LogError("Secondary camera is not assigned.");
            return;
        }

        // Set the viewport rect to display in the bottom-right corner
        secondaryCamera.rect = new Rect(0.75f, 0f, 0.25f, 0.25f);

        if (target != null)
        {
            // Position the camera relative to the target
            secondaryCamera.transform.position = target.position + offset;
        }
    }

    void Update()
    {
        if (target != null)
        {
            // Update the camera position to follow the target
            secondaryCamera.transform.position = target.position + offset;
        }
    }
}
