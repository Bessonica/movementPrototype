using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenu;

    public static bool isPaused = false;


    [Header("gameMaster")]
    public GameObject gameMaster;
    PlayerStats playerStats;
    Interactable interactablePC;

    MouseLook mouseLook;
    InputManager inputManager;
    GameObject playerObjectInteract;

    // [Header("Player")]
    // public GameObject playerObject;

    [Header("PC")]
    public GameObject PCobject;

    // this is variabe so player cant pause when inside intro cutscene
    // is this really important?
    public bool IntroCutsceneOver;


    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);

        playerStats = gameMaster.GetComponent<PlayerStats>();
        playerObjectInteract = playerStats.playerObject;

        mouseLook = playerObjectInteract.GetComponent<MouseLook>();
        inputManager = playerObjectInteract.GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // if(IntroCutsceneOver)

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        // take away controls
        mouseLook.enabled = false;
        inputManager.enabled = false;

        // if player is in pc, change camera to first person
        playerStats = gameMaster.GetComponent<PlayerStats>();
        
        interactablePC = PCobject.GetComponent<Interactable>();

        if(playerStats.tdCamera.enabled)
        {
            interactablePC.ChangeCameraToFirstPerson();
        }


        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }


    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

        // give controls back
        mouseLook.enabled = true;
        inputManager.enabled = true;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }


}
