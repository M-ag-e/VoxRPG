using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform playerCamera;

    public float speed = 6;
    public float gravity = -9.81f;
    public float jumpHeight = 3;
    public static float dodgeAmount = 2f;
    public static float dodgeTime = 0.8f;
    Vector3 velocity;
    public static bool isGrounded;
    public static bool isDodging = false;
    public LayerMask groundMask;

    float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;


    public float collisionRayDistance;
    [HideInInspector]
    public Vector3 moveDir;
    public Vector3 tempDir;


    // Update is called once per frame

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        
        // Do lean amount in the update function, so that its calculated when the player moves
        //gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        //walk
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        //jump
        isGrounded = Physics.Raycast(transform.position, Vector3.down, collisionRayDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            
        }

        if (Input.GetButtonDown("Dodge") && isGrounded && !isDodging && direction.magnitude >= 0.1f)
        {
            tempDir = new Vector3(moveDir.x, moveDir.y, moveDir.z);
            StartCoroutine(DodgeTimer(dodgeTime));
            Debug.Log("Player Dodged!");
        }


        else if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + playerCamera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

              // Make sure to change the 0f to the leanvalue, youll thank me later ;)

            moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            if (isDodging)
            {
                controller.Move(tempDir.normalized * (dodgeAmount * (speed / 2)) * Time.deltaTime);
                
            }
            else
            {
                transform.rotation = Quaternion.Euler((Mathf.Atan2(direction.x, direction.y)), angle, 0f);
                controller.Move(moveDir.normalized * speed * Time.deltaTime);
            }
                
        }
    }



    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, Vector3.down * collisionRayDistance);
    }
    
    IEnumerator DodgeTimer(float time)
    {
        isDodging = true;
        yield return new WaitForSeconds(time);
        isDodging = false;

    }

    private void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 150, 50), "player movement = " + controller, "box");
    }
}
