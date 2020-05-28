using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables
    private float currentSpeed;
    private float currentJumpForce;

    bool dashInProgress = false;


    public float walkSpeed = 20f;
    public float runSpeed = 35f;
    public float dashSpeed = 200f;


    public float walkJumpForce = 40f;
    public float runJumpForce = 50f;
    public float gravity = 130f;

    public Vector3 moveDir = Vector3.zero;
    #endregion
    
    CharacterController controller;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }


    void Update()
    {


        if (Input.GetButton("Run") && dashInProgress == false)
        {
            currentSpeed = runSpeed;
            currentJumpForce = runJumpForce;
        }
        else
        {
            if (dashInProgress == false)
            {
                currentSpeed = walkSpeed;
                currentJumpForce = walkJumpForce;
            }
            
        }


        if (controller.isGrounded)
        {


            moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            moveDir = Vector3.ClampMagnitude(moveDir, 1);

            moveDir = transform.TransformDirection(moveDir);

            moveDir *= currentSpeed;

            if (Input.GetButtonDown("Jump"))
            {
                moveDir.y = currentJumpForce;
            }
        }

        if (Input.GetKeyDown("c"))
        {
            if (dashInProgress == false)
            {
                StartCoroutine(DashUsed());
            }
        }






        if (dashInProgress == false)
        {
            moveDir.y -= gravity * Time.deltaTime;
        }
        else
        {
            moveDir.y = 0;
        }
        
    






       //Debug.Log(dashInProgress);
       //Debug.Log(currentSpeed);



        controller.Move(moveDir * Time.deltaTime);
    }

    IEnumerator DashUsed()
    {
        dashInProgress = true;
        currentSpeed = dashSpeed;
        yield return new WaitForSeconds(1);
        currentSpeed = walkSpeed;
        dashInProgress = false;
        
       
    }
}