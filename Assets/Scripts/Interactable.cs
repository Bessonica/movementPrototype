using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{

    public UnityEvent onInteract;
    public Sprite interactIcon;
    public int ID;


    [Header("size of Icons")]
    public Vector2 iconSize;


    [Header("gameMaster")]
    public GameObject gameMaster;
    WaveSpawner waveSpawner;

    PlayerStats playerStats;
    GameObject playerObjectInteract;
    MouseLook mouseLook;
    InputManager inputManager;
    Interactable interactablePC;

    [Header("isThisLever")]
    public bool isLever;
    public bool isLeverOn = true;

//  track is pc should be accessible
    [Header("isThisPC")]
    public bool isPC; 
    public bool isPCon;
    
    [Header("isThisLetter")]
    public bool isLetter; 
    public GameObject LetterCanvasObject;
    
    
    [Header("DO NOT TOUCH")]
    public float phaseStartTime;

  
    // Start is called before the first frame update
    void Start()
    {
        ID = Random.Range(0, 99999);
        isPCon = false;

    }


    public void StartWave(GameObject gameMaster)
    {
        // мужду 0 и 1 фазой рычаг должен быть выключен, но он работает
        if(isLeverOn)
        {
            waveSpawner = gameMaster.GetComponent<WaveSpawner>();
            waveSpawner.StartPhase();
        }

    }
    
    
    public void ShowLetter()
    {
        LetterCanvasObject.SetActive(true);
        UnityEngine.Debug.Log(" isLetter = ");

        //take movement away from player
        playerStats = gameMaster.GetComponent<PlayerStats>();
        playerObjectInteract = playerStats.playerObject;
        mouseLook = playerObjectInteract.GetComponent<MouseLook>();
        inputManager = playerObjectInteract.GetComponent<InputManager>();
        mouseLook.enabled = false;
        inputManager.enabled = false;
    }


    public void HideLetter()
    {
        LetterCanvasObject.SetActive(false);
        UnityEngine.Debug.Log(" isLetter = ");

        //give movement to player
        playerStats = gameMaster.GetComponent<PlayerStats>();
        playerObjectInteract = playerStats.playerObject;
        mouseLook = playerObjectInteract.GetComponent<MouseLook>();
        inputManager = playerObjectInteract.GetComponent<InputManager>();
        mouseLook.enabled = true;
        inputManager.enabled = true;
    }



    public void ChangeCamera()
    {

        if(isPCon)
        {

            playerStats = gameMaster.GetComponent<PlayerStats>();
            
            //take movement away from player
            playerObjectInteract = playerStats.playerObject;
            mouseLook = playerObjectInteract.GetComponent<MouseLook>();
            inputManager = playerObjectInteract.GetComponent<InputManager>();
            mouseLook.enabled = false;
            inputManager.enabled = false;


            //changing camera and ui
            playerStats.playerCamera.enabled = false;
            playerStats.playerCanvas.SetActive(false);
            
            
            playerStats.towerDefCanvas.SetActive(true);
            playerStats.tdCamera.enabled = true;

        }

        

    }

    public void ChangeCameraToFirstPerson()
    {
        if(isPCon)
        {
            playerStats = gameMaster.GetComponent<PlayerStats>();
            playerObjectInteract = playerStats.playerObject;
            
            mouseLook = playerObjectInteract.GetComponent<MouseLook>();
            inputManager = playerObjectInteract.GetComponent<InputManager>();

            // take away pc camera and ui 
            playerStats.towerDefCanvas.SetActive(false);
            playerStats.tdCamera.enabled = false;

            playerStats.playerCamera.enabled = true;
            playerStats.playerCanvas.SetActive(true);

            //give movement to player
            mouseLook.enabled = true;
            inputManager.enabled = true;

            
        }

    }

    public void turnOnPC()
    {
        interactablePC = this.GetComponent<Interactable>();
        // UnityEngine.Debug.Log("TEST = " + interactablePC.ID);
        interactablePC.isPCon = true;
    }

    public void turnOffPC()
    {
        playerStats = gameMaster.GetComponent<PlayerStats>();


        interactablePC = this.GetComponent<Interactable>();
        // UnityEngine.Debug.Log("tdCamera.enabled = " + playerStats.tdCamera.enabled);

        if(playerStats.tdCamera.enabled)
        {
            interactablePC.ChangeCameraToFirstPerson();
        }

        interactablePC.isPCon = false;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
