using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using TMPro;
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
    private Animator anim; //need this to be able to make transition parameters for the animtor. 
    private bool isGrounded = false;
    private bool isFacingRight = true; //to flip animation, start off facing right

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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
            //GetComponent<AudioSource>().Play(); //this is one way to play an audio source
        }

        rBody.velocity = new Vector2(horiz * speed, rBody.velocity.y);
        //The first argument moves character left and right, the second argument helps with jumping, if you set it to 0 you can't jump

        //Check if the sprite needs to be flipped:
        if ((isFacingRight && rBody.velocity.x < 0) || (!isFacingRight && rBody.velocity.x > 0))
            Flip();
        //^ if player is facing right and the velocity turns negative, flip, or if player is facing left and velocity turns positive, flip.
        //This could be an if else, but this works too

        //Communicate with the animator:
        anim.SetFloat("xVelocity", Mathf.Abs(rBody.velocity.x)); //use Mathf.Abs() to get the absolute value - you don't want to ignore moving left because it is negative
        anim.SetFloat("yVelocity", rBody.velocity.y); //no absoulte value for jumping because JumpDown should be negative. 
        anim.SetBool("IsGrounded", isGrounded); //pass this to IsGrounded parameter
    }

    private bool GroundCheck() //To jump, we will check first if player is on the ground. If they are then they have the ability to jump
    {
        //OverlapCircle return type is Collider2D which can easily be turned into a boolean
        return Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, whatIsGround); //is character overlapping with an object that is ground?
    }

    private void Flip() //flip the animation when moving left vs moving right
    {
        Vector3 temp = transform.localScale; //this temp vector3 will allow you to flip it because it's not technically the game object
        temp.x *= -1; //multiply by negative 1 to flip
        transform.localScale = temp; //now make the object = temp to flip it haha
        isFacingRight = !isFacingRight; //use this format of writing the bool so that no matter what it is it will turn the opposite way
    }
}
