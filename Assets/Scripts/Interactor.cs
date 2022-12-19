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
    public Vector2 defaultInteractIconBlobSize;


    Interactable interactable;
    // UnityEvent onInteract;

    [Header("gameMaster Test")]
    public GameObject gameMaster;
    WaveSpawner waveSpawner;

    [Header("how long whoeld player hold lever")]
    public float HoldTimerDeadLine;
    float holdTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void ActivateInteract(Iinteractable interfaceOfObject)
    {
        interfaceOfObject.Interact();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out hit, 2, interactableLayermask))
        {



            //  UnityEngine.Debug.Log(hit.collider.name); 
            // if we look at interactable object
            if (hit.collider.GetComponent<Interactable>() != false)
            {
                //  !!!! remember this code seems usefull
                // get onInteract function from this object

                // onInteract = hit.collider.GetComponent<Interactable>().onInteract;

                // with this code we run check only one time and not every frame
                if (interactable == null || interactable.ID != hit.collider.GetComponent<Interactable>().ID)
                {
                    interactable = hit.collider.GetComponent<Interactable>();
                }

                // choose icon in center of screen
                if (interactable.interactIcon != null)
                {
                    // if pc is onn show interact icon
                    // also can start SOUND component
                    if (interactable.isPC && interactable.isPCon)
                    {

                        interactImage.sprite = interactable.interactIcon;
                        if (interactable.iconSize == Vector2.zero)
                        {
                            interactImage.rectTransform.sizeDelta = defaultInteractIconSize;
                        }
                        else
                        {
                            interactImage.rectTransform.sizeDelta = interactable.iconSize;
                        }

                    }



                    // "HOLD" text
                    if (interactable.isLever && interactable.isLeverOn)
                    {
                        // UnityEngine.Debug.Log("WaveStarted at = " + interactable.phaseStartTime);

                        interactImage.sprite = interactable.interactIcon;
                        if (interactable.iconSize == Vector2.zero)
                        {
                            interactImage.rectTransform.sizeDelta = defaultInteractIconSize;
                        }
                        else
                        {
                            interactImage.rectTransform.sizeDelta = interactable.iconSize;
                        }

                        Transform test = interactImage.transform.GetChild(0);
                        Text test1 = test.GetComponent<Text>();
                        test1.gameObject.SetActive(true);
                    }

                }
                else
                {
                    interactImage.sprite = defaultInteractIcon;
                    interactImage.rectTransform.sizeDelta = defaultIconSize;

                }

                // if we press "E" then activate this function
                // Input.GetKeyDown(KeyCode.E))
                if (Input.GetKey(KeyCode.E))
                {
                    // using interface
                    if (hit.collider.GetComponent<Iinteractable>() != null)
                    {
                        hit.collider.GetComponent<Iinteractable>().Interact();
                    }

                    if (interactable.isLetter)
                    {
                        interactable.onInteract.Invoke();
                    }


                    // if its pc enter immediatly
                    if (interactable.isPC)
                    {
                        interactable.onInteract.Invoke();
                    }
                    else
                    {

                        if (holdTimer <= 0 && interactable.isLeverOn)
                        {

                            // SOUND start sound
                            AudioManager.instance.LeverSFX();

                        }


                        // if its lever then start timer

                        if (interactable.isLeverOn)
                        {
                            holdTimer += Time.deltaTime;
                        }


                        // UnityEngine.Debug.Log(" HoldTimer = " + holdTimer);

                        if (holdTimer > HoldTimerDeadLine && interactable.isLeverOn)
                        {
                            interactable.onInteract.Invoke();
                            AudioManager.instance.LeverStopSFX();
                            // SOUND stop sound
                            return;
                        }

                    }
                    // interactable.onInteract.Invoke();

                    // !!! this shit here works but not in interactable for some reason
                    // waveSpawner = gameMaster.GetComponent<WaveSpawner>();
                    // UnityEngine.Debug.Log("TEST = " + waveSpawner.phaseString);

                }
                else
                {

                    // SOUND stop sound
                    AudioManager.instance.LeverStopSFX();

                    holdTimer = 0;
                    // UnityEngine.Debug.Log(" <color=red>HoldTimer IS zero </color> " + holdTimer);
                }
            }
        }
        else
        {
            // if we have no interactable object in reach
            if (interactImage.sprite != defaultIcon)
            {
                // hold text
                Transform test = interactImage.transform.GetChild(0);
                Text test1 = test.GetComponent<Text>();
                test1.gameObject.SetActive(false);

                interactImage.sprite = defaultIcon;
                interactImage.rectTransform.sizeDelta = defaultInteractIconBlobSize;
            }
        }

    }
}
