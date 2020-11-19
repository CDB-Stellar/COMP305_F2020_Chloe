using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{
    [SerializeField] private GameObject itemFeedback; //drag in itemPickup prefab

    private LevelController levelController; //just to simplify reference to LevelController

    private void Start()
    {
        levelController = LevelController.Instance;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) //if the player touches the cherry's collider
        {
            // Play item feedback
            GameObject.Instantiate(itemFeedback, this.transform.position, this.transform.rotation); //make the item feedback play

            // Increase item collected counter (LevelController)
            levelController.PickedUpItem();

            Destroy(this.gameObject);
        }
    }
}
