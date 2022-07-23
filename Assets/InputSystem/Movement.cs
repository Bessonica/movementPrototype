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


    float lowestSin = 5;
    float sinOne = 5;
    float sinTwo;

    float timer = 0;
    public float walkingBobbingSpeed;
    public float bobbingAmount;

    public Transform groundCheck;

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.6f, groundMask);
        // UnityEngine.Debug.Log("IS GROUNDED =  " + isGrounded);

        if(isGrounded)
        {
            verticalVelocity.y = 0;
        }

        
        Vector3 horizontalVelocity = (transform.right * horizontalInput.x + transform.forward * horizontalInput.y ) * speed;
        Vector3 vectorToCompare = new Vector3 (0, 0, 0);
        // UnityEngine.Debug.Log("TIMER =  " + timer);

        if(horizontalVelocity != vectorToCompare && isGrounded)
        {
            // UnityEngine.Debug.Log("<color=green> TIMER IS NOT ZERO    </color>  " + timer);
            timer += Time.deltaTime * walkingBobbingSpeed;

            controller.Move(horizontalVelocity * Time.deltaTime);
            
            verticalVelocity.y += Mathf.Sin(timer) * bobbingAmount;
            // controller.Move(verticalVelocity * Time.deltaTime);
            // UnityEngine.Debug.Log(" Cos =" + Mathf.Cos(timer) + " sin = " + Mathf.Sin(timer));


        // sound part
            // if mathf.sin(timer) == amountX (when player on lowest point) play sound

            

            
         // i dont even understand how i made this 
            // THIS FUNCTION FINDS FUCKING EXTREMUM AND NOT MINIMUM WHAT THE FUCK
            if(Mathf.Sin(timer) < lowestSin)
            {
                lowestSin = Mathf.Sin(timer);
            }

            if(Mathf.Sin(timer) > lowestSin && Mathf.Cos(timer) < 0)
            {
                UnityEngine.Debug.Log("STEP  Mathf.Sin(timer)     " + Mathf.Sin(timer) + "  lowestSin = " + lowestSin);
                AudioManager.instance.StepOnFloorSFX();
                lowestSin = 5;
            }

        }else
        {
            timer = 0;
            // UnityEngine.Debug.Log("<color=red> TIMER IS ZERO    </color>  " + timer);
            verticalVelocity.y += gravity * Time.deltaTime;
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
