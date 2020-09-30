using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerBuffer : MonoBehaviour
{
    //Buffer Style camera, player "drags" the camera around
    //Variables
    [SerializeField] private Transform player; //where is the player currently
    [Range(1f, 10f)][SerializeField] private float cameraOffsetX = 5f;
    [Range(1f, 10f)][SerializeField] private float cameraOffsetY = 5f;

    // Update is called once per frame
    void Update()
    {
        //Check the x threshold left side
        if (player.position.x < transform.position.x - (0.5f * cameraOffsetX)) //is the player position less than the camera x position - offset
        {
            transform.position = new Vector3(
                player.position.x + (0.5f * cameraOffsetX),
                transform.position.y,
                transform.position.z);
        }
        else if (player.position.x > transform.position.x + (0.5f * cameraOffsetX)) //check x threshold right side
        {
            transform.position = new Vector3(
                player.position.x - (0.5f * cameraOffsetX),
                transform.position.y,
                transform.position.z);
        }
        //Check the y threshold
        if (player.position.y < transform.position.y - (0.5f * cameraOffsetY)) //is the player position less than the camera x position - offset
        {
            transform.position = new Vector3(
                transform.position.x,
                player.position.y + (0.5f * cameraOffsetY),
                transform.position.z);
        }
        else if (player.position.y > transform.position.y + (0.5f * cameraOffsetY))
        {
            transform.position = new Vector3(
                transform.position.x,
                player.position.y - (0.5f * cameraOffsetY),
                transform.position.z);
        }
    }

    //To view things in the editor that don't show up on the game camera you need this function
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(cameraOffsetX, cameraOffsetY, 0f));
        //first argument is centre of camera
    }
}
