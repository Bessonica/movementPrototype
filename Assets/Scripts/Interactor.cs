using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactor : MonoBehaviour
{
    public LayerMask interactableLayermask = 8;
    public Camera PlayerCamera;
    public Image interactImage;
    public Sprite defaultIcon;
    public Sprite defaultInteractIcon;

    [Header("default size for interact icons")]
    public Vector2 defaultIconSize;
    public Vector2 defaultInteractIconSize;


    Interactable interactable;
    // UnityEvent onInteract;

    [Header("gameMaster Test")]
    public GameObject gameMaster;
    WaveSpawner waveSpawner;

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

            // onInteract = hit.collider.GetComponent<Interactable>().onInteract;

            // with this code we run check only one time and not every frame
            if(interactable == null || interactable.ID != hit.collider.GetComponent<Interactable>().ID)
            {
                interactable = hit.collider.GetComponent<Interactable>();
            }

            // choose icon in center of screen
            if(interactable.interactIcon != null)
            {
                interactImage.sprite = interactable.interactIcon;
                if(interactable.iconSize == Vector2.zero)
                {
                    interactImage.rectTransform.sizeDelta = defaultInteractIconSize;
                }
                else
                {
                    interactImage.rectTransform.sizeDelta = interactable.iconSize;
                }
                
                // hold text
                if(interactable.isLever)
                {
                    Transform test =  interactImage.transform.GetChild(0);
                    Text test1 = test.GetComponent<Text>();
                    test1.gameObject.SetActive(true);
                }

            // how to get ui text bellow( like hold, or E)
                // Transform test =  interactImage.transform.GetChild(0);
                // Text test1 = test.GetComponent<Text>();
                // UnityEngine.Debug.Log("HOLD TEXT = " + test1.text);
            }
            else
            {
                interactImage.sprite = defaultInteractIcon;
                interactImage.rectTransform.sizeDelta = defaultIconSize;

            }

            // if we press "E" then activate this function
            if(Input.GetKeyDown(KeyCode.E))
            {
                interactable.onInteract.Invoke();

        // !!! this shit here works but not in interactable for some reason
                // waveSpawner = gameMaster.GetComponent<WaveSpawner>();
                // UnityEngine.Debug.Log("TEST = " + waveSpawner.phaseString);

            }
        }
    }
    else
    {
        // if we have no interactable object in reach
        if(interactImage.sprite != defaultIcon)
        {
            // hold text
            Transform test =  interactImage.transform.GetChild(0);
            Text test1 = test.GetComponent<Text>();
            test1.gameObject.SetActive(false);

            interactImage.sprite = defaultIcon;
            interactImage.rectTransform.sizeDelta = defaultInteractIconSize;
        }
    }

    }
}
