using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Mario Style camera, only goes forwards not back
    //Variables
    [SerializeField] private Transform player; //where is the player currently
    [SerializeField] private Transform moveThreshold; //if player passes this, move camera

    // Update is called once per frame
    void Update()
    {
        if (player.position.x > moveThreshold.position.x) //if the player moves to the right past the threshold 
        {
            //camera follows the player on the x axis
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
        }
    }

    //To view things in the editor that don't show up on the game camera you need this function
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(moveThreshold.position.x, moveThreshold.position.y + 10), new Vector2(moveThreshold.position.x, moveThreshold.position.y - 10));
        //if you dont offset the y with the +10 and -10 it will draw a dot
    }
}
