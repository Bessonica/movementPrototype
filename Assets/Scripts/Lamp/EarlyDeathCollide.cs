using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarlyDeathCollide : MonoBehaviour
{
    [Header("final lamp")]
    public GameObject LampObject;

    Lamp lampComponent;
    Light lightToStart;

    public GameObject PlayerIcon;

    public bool StartChecking = false;
    
    [Header("gameMaster")]
    public GameObject gameMaster;

    PlayerStats playerStats;
    GameObject playerObjectInteract;
    MouseLook mouseLook;
    InputManager inputManager;

    // Start is called before the first frame update
    void Start()
    {
        
        // lightToStart =  LampObject.GetComponent<Light>();
        // lampComponent = LampObject.GetComponent<Lamp>();
        playerStats = gameMaster.GetComponent<PlayerStats>();
        playerObjectInteract = playerStats.playerObject;
        
        mouseLook = playerObjectInteract.GetComponent<MouseLook>();
        inputManager = playerObjectInteract.GetComponent<InputManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) 
    {
        if(StartChecking)
        {
            
            // StartCoroutine(lampComponent.PopFinalLight());


            // take away players light
            LampManager.instance.stopPlayerLight();


            // take away player movement
            AudioManager.instance.SetStepVolume(-80f);
            mouseLook.enabled = false;
            inputManager.enabled = false;

            PlayerIcon.SetActive(false);
            FinalMonsterStepAtPlayer.instance.RunAtPlayer();

            // StopAllColliders(); 
                      
        }



    }


    public void StopAllColliders()
    {


        foreach(GameObject colliderObject in GameObject.FindGameObjectsWithTag("earlyDeath"))
        {
        //    UnityEngine.Debug.Log("yo" + colliderObject.name);
           DeathCollide collider =  colliderObject.GetComponent<DeathCollide>();
           collider.StartChecking = false;

        }

    }



}
