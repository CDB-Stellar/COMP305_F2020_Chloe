using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //"Public" variables
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpForce = 750f;
    [SerializeField] private float groundCheckRadius = 0.1f;
    [SerializeField] private Transform groundCheckPosition;
    [SerializeField] private LayerMask whatIsGround;

    //Private Variables
    private Rigidbody2D rBody;
    private bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    // Physics
    private void FixedUpdate() //fixed update is better for working with physics
    {
        //Movement stuff
        float horiz = Input.GetAxis("Horizontal");
        isGrounded = GroundCheck(); //check if the player is on the ground

        //Jump code
        //if the player is grounded and they press the jump button
        if (isGrounded && Input.GetAxis("Jump") > 0) //it is more efficient to put the bool first in the if
        {
            rBody.AddForce(new Vector2(0f, jumpForce));
            isGrounded = false;
        }

        rBody.velocity = new Vector2(horiz * speed, rBody.velocity.y); 
        //The first argument moves character left and right, the second argument helps with jumping, if you set it to 0 you can't jump
    }

    private bool GroundCheck() //To jump, we will check first if player is on the ground. If they are then they have the ability to jump
    {
        //OverlapCircle return type is Collider2D which can easily be turned into a boolean
        return Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, whatIsGround); //is character overlapping with an object that is ground?
    }
}
