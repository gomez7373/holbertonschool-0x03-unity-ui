using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player; // Reference to the Player GameObject
    private Vector3 offset;   // Stores the initial distance between Camera and Player

    void Start()
    {
        // Calculate and store the offset distance between the Player and Camera
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        // LateUpdate is used to ensure the camera updates after the Player has moved
        transform.position = player.transform.position + offset;
    }
}
