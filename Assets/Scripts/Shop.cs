using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standartTurret;


//  important code. we reference another object
    BuildManager buildManager;

    // for change camera
    PlayerStats playerStats;
    GameObject playerObjectInteract;
    MouseLook mouseLook;
    InputManager inputManager;

    // попробуй так
    // public GameObject standartTurretPrefabForShop;

    void Start()
    {
        
        buildManager = BuildManager.instance;
        if(buildManager == null)
        {
            UnityEngine.Debug.Log("buildmanager instance is NULL");
        }
    }


    public void SelectStandardTurret()
    {
        buildManager.SetTurretToBuild(standartTurret);
        // or standartTurretPrefabForShop
    }

    public void SelectStandardTurretToDestroy()
    {
        UnityEngine.Debug.Log("SelectStandardTurretToDestroy");
        buildManager.SetTurretToDestroy();
    }


//  dont forget that player still can walk and move camera !!!!
    public void ChangeCameraToFirstPerson(GameObject gameMaster)
    {
        playerStats = gameMaster.GetComponent<PlayerStats>();
        

        AudioManager.instance.SetStepVolume(-5.72f);
        //give movement back to player
        playerObjectInteract = playerStats.playerObject;
        mouseLook = playerObjectInteract.GetComponent<MouseLook>();
        inputManager = playerObjectInteract.GetComponent<InputManager>();
        mouseLook.enabled = true;
        inputManager.enabled = true;


        //changing camera and ui
        playerStats.playerCamera.enabled = true;
        playerStats.playerCanvas.SetActive(true);

        playerStats.towerDefCanvas.SetActive(false);
        playerStats.tdCamera.enabled = false;

    }

}
