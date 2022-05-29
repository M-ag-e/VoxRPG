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
        Vector3 horizontalVelocity = new Vector3(player.velocity.x, 0, player.velocity.z);
        px = Input.GetAxis("Horizontal");
        pz = Input.GetAxis("Vertical");
        //Animation State Machine
        if (PlayerMovement.isGrounded)
        {
            isInAir = false;
            if (horizontalVelocity.x > 0.01 || horizontalVelocity.x < -0.01 || horizontalVelocity.y > 0.01 || horizontalVelocity.y < -0.01)
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
