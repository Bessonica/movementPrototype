using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactor : MonoBehaviour
{
    public LayerMask interactableLayermask = 8;
    public Camera PlayerCamera;
    UnityEvent onInteract;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
    if(Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out hit, 2,interactableLayermask))
    {

    //  UnityEngine.Debug.Log(hit.collider.name); 
        // if we look at interactable object
        if(hit.collider.GetComponent<Interactable>() != false)
        {
            //  !!!! remember this code seems usefull
            // get onInteract function from this object
            onInteract = hit.collider.GetComponent<Interactable>().onInteract;

            // if we press "E" then activate this function
            if(Input.GetKeyDown(KeyCode.E))
            {
                onInteract.Invoke();

            }
        }
    }

    }
}
