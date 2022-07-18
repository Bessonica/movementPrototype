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

//  track is pc should be accessible
    [Header("isThisPC")]
    public bool isPC = true; 
    public bool isPCon;
    
    [Header("DO NOT TOUCH")]
    public float phaseStartTime;

  
    // Start is called before the first frame update
    void Start()
    {
        ID = Random.Range(0, 99999);
        isPCon = false;

    }

// UnityEngine.Debug.Log("WAVE is SPAWNED" + waveSpawner.phaseString);

// start wave and reload money and turret variables!!! 
    // figure out cooldown for it
    // after starting wave need to put timer

    //    courutine that waits for some time
    //    and then stops the wave
    //       several public variables in GameMaster(TimeWaveFirst, TimeWaveSecond and etc)
    public void StartWave(GameObject gameMaster)
    {
        // UnityEngine.Debug.Log("WAVE is SPAWNED" + gameMaster);
        waveSpawner = gameMaster.GetComponent<WaveSpawner>();
        playerStats = gameMaster.GetComponent<PlayerStats>();

        phaseStartTime = Time.time;
        // UnityEngine.Debug.Log("WaveStarted at = " + phaseStartTime);


    // if its first time we pulled lever
        if(waveSpawner.phaseString == waveSpawner.phaseStringStart)
        {
            // start phaseZero
            waveSpawner.phaseString = waveSpawner.phaseStringZero;   

        
            playerStats.startTimer = true;
            
            // Money is static variable, so you can access it from everywhere?
            // read about public static
            PlayerStats.Money = 0; 
        }



        
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

    public void turnOnPC()
    {
        UnityEngine.Debug.Log("TEST = " + this.transform);
        interactablePC = this.GetComponent<Interactable>();
        // UnityEngine.Debug.Log("TEST = " + interactablePC.ID);
        interactablePC.isPCon = true;
    }

    public void turnOffPC()
    {
        interactablePC = this.GetComponent<Interactable>();
        // UnityEngine.Debug.Log("TEST = " + interactablePC.ID);
        interactablePC.isPCon = false;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
