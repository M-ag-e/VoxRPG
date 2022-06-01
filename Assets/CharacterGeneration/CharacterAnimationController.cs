using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    public CharacterController player;
    public Animator anim;
    public float moveThreshold = 0.1f;
    private bool isMove;
    private bool isInAir;
    private bool isDodging;
    [HideInInspector]
    public bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        isGrounded = PlayerMovement.isGrounded;
        isDodging = PlayerMovement.isDodging;
        Vector3 horizontalVelocity = new Vector3(player.velocity.x, 0, player.velocity.z);
        //Animation State Machine
        if (isDodging)
        {
            isDodging = true;
        }
        else if (isGrounded)
        {
            isInAir = false;
            isDodging = false;
            if ((horizontalVelocity.x > moveThreshold || horizontalVelocity.x < -moveThreshold || horizontalVelocity.z > moveThreshold || horizontalVelocity.z < -moveThreshold))
            {
                isMove = true;
            }
            else
            {
                isMove = false;
                isDodging = false;
            }

        }
        else
        {
            isMove = false;
            isInAir = true;
        }
        SetAnimationStates();

    }

    public void PlayerIsMove(bool state)
    {
        isMove = state;
    }

    public void PlayerIsInAir(bool state)
    {
        isInAir = state;
    }

    public void PlayerIsDodging(bool state) 
    {
        isDodging = state;
    }

    private void SetAnimationStates()
    {
        anim.SetBool("isMove", isMove);
        anim.SetBool("isInAir", isInAir);
        anim.SetBool("isDodging", isDodging);
    }
}
