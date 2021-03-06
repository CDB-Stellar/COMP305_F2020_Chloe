﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpSound : StateMachineBehaviour
{
    //public AudioClip clip; //you can put the audio clip directly onto the animation instead of the game object
    //public AudioClip[] clip; //if you want multiple sounds 

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.GetComponent<AudioSource>().Play(); //to play the sound that is on the game object (player)
        //animator.gameObject.GetComponent<AudioSource>().PlayOneShot(clip); //to play the sound that is on the animator
        //animator.gameObject.GetComponent<AudioSource>().PlayOneShot(clip[Random.Range(0, 5)]); //if you want to play a random sound out of an array
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
