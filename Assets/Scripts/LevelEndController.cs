using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) //if the player touches the door
        {
            LevelController.Instance.CheckLevelComplete();
        }
    }
}
