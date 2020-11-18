using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    public float scrollSpeed;

    private Renderer renderer; //making it of type renderer to be generic

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();

        //2D aesthetic way
        InvokeRepeating("MoveBG", scrollSpeed, scrollSpeed); //0.1 seconds after start it will happen, and every 0.1 seconds after that it will repeat
    }

    private void MoveBG()
    {
        //this is a more 2D aesthetic way of doing it
        renderer.material.mainTextureOffset = new Vector2(renderer.material.mainTextureOffset.x + 0.05f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //renderer.material.mainTextureOffset = new Vector2(Time.time * scrollSpeed, 0); this is a smooth way to do it
        //(time.time is a reference to the time since the start of the game, basing the scroll off that.)
    }
}
