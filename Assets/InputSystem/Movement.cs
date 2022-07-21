using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] float speed = 11f;
    Vector2 horizontalInput;

    [SerializeField] float gravity = -30f;
    Vector3 verticalVelocity = Vector3.zero;
    [SerializeField] LayerMask groundMask;
    bool isGrounded;

    float timer = 0;
    public float walkingBobbingSpeed;
    public float bobbingAmount;

    public Transform groundCheck;

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.5f, groundMask);
        // UnityEngine.Debug.Log("IS GROUNDED =  " + isGrounded);

        if(isGrounded)
        {
            verticalVelocity.y = 0;
        }

        
        Vector3 horizontalVelocity = (transform.right * horizontalInput.x + transform.forward * horizontalInput.y ) * speed;
        Vector3 vectorToCompare = new Vector3 (0, 0, 0);
        if(horizontalVelocity != vectorToCompare && isGrounded)
        {
            timer += Time.deltaTime * walkingBobbingSpeed;

            controller.Move(horizontalVelocity * Time.deltaTime);
            
            verticalVelocity.y += Mathf.Sin(timer) * bobbingAmount;
            // controller.Move(verticalVelocity * Time.deltaTime);

        }else
        {
            timer = 0;
        }

        if(!isGrounded)
        {
            verticalVelocity.y += gravity * Time.deltaTime;
        }

        controller.Move(verticalVelocity * Time.deltaTime);
    }

    public void ReceiveInput(Vector2 _horizontalInput)
    {
        horizontalInput = _horizontalInput;
        // UnityEngine.Debug.Log("HORIZONTAL INPUT = " + horizontalInput);
    }

}
