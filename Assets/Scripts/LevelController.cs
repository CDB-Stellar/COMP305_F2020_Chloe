using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //access to UI stuff
using UnityEngine.SceneManagement; //change scene

public class LevelController : MonoBehaviour
{
    //Singleton pattern
    private static LevelController _instance; //holds the object of level controller
    public static LevelController Instance { get { return _instance; } }

    // "Public" variables
    [SerializeField] private Text itemUIText; //drag the text in

    // Private Variables
    private int totalItemsAmount = 0; //zero by default
    private int itemsCollected = 0;

    private void Awake()
    {
        if (_instance != null && _instance != this) //if there is somehow a second controller destroy it
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        totalItemsAmount = GameObject.FindGameObjectsWithTag("Cherry").Length; //find how many cherries there are
        //Debug.Log("There are: " + totalItemsAmount + " cherries");
        UpdateItemUI();
    }

    private void UpdateItemUI()
    {
        itemUIText.text = itemsCollected + " / " + totalItemsAmount;
    }

    public void PickedUpItem()
    {
        itemsCollected++;
        //Debug.Log("Cherries collected: " + itemsCollected);
        UpdateItemUI();
    }

    public void CheckLevelComplete()
    {
        if (itemsCollected == totalItemsAmount)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //whatever current scene is, go to the next
    }
}
