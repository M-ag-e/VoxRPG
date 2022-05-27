using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorStates : MonoBehaviour
{
    public CharacterController player;
    public Animator anim;
    public float moveThreshold = 0.1f;
    private float px;
    private float pz;
    private bool isMove;
    private bool isInAir;
    [HideInInspector]
    public bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        px = Input.GetAxis("Horizontal");
        pz = Input.GetAxis("Vertical");
        //Animation State Machine
        if (PlayerMovement.isGrounded)
        {
            isInAir = false;
            if (px >= moveThreshold || px <= -moveThreshold || pz >= moveThreshold || pz <= -moveThreshold)
            {
                isMove = true;
            }
            else
            {
                isMove = false;
            }

        }
        else
        {
            isMove = false;
            isInAir = true;
        }


        anim.SetBool("isMove", isMove);
        anim.SetBool("isInAir", isInAir);
    }
}
