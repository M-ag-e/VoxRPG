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
    private float playerVelocity;

    // Update is called once per frame
    void Update()
    {

        isGrounded = PlayerMovement.isGrounded;
        isDodging = PlayerMovement.isDodging;
        playerVelocity = (Mathf.Abs(player.velocity.x) + Mathf.Abs(player.velocity.z));

        //Animation State Machine
        if (isDodging)
        {
            isDodging = true;
        }
        else if (isGrounded)
        {
            isInAir = false;
            isDodging = false;
            if ((playerVelocity > moveThreshold || playerVelocity < -moveThreshold))
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

    private void SetAnimationStates()
    {
        anim.SetBool("isMove", isMove);
        anim.SetBool("isInAir", isInAir);
        anim.SetBool("isDodging", isDodging);
        anim.SetFloat("velocity", playerVelocity);
    }
}
