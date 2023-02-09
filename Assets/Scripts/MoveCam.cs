using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{
    public Transform cameraPosition; // cameras position
    private void Update()
    {
        transform.position = cameraPosition.position; // moves the camera to the position of the cam pos object
    }
}
