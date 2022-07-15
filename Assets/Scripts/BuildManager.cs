using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {
        if(instance != null)
        {
            UnityEngine.Debug.Log("you alreaddy have build manager");
            return;
        }
        instance = this;
    }

    public GameObject standartTurretPrefab;
    private GameObject turretToBuild;


    //это убрать ? 15 мин
    //у меня нихуя не работает
    //без старта shop.cs обращается к buildManager.SetTurretToBuild(buildManager.standartTurretPrefab);
    // и там null, и я хз почему
    //
    // void Start()
    // {
    //     turretToBuild = standartTurretPrefab;

    // }


    

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        UnityEngine.Debug.Log("SetTurretToBuild:  standart turret purchased");
        turretToBuild = turret;

    }

    public void SetTurretToBuildToNull()
    {
        UnityEngine.Debug.Log("SetTurretToBuildToNull:  turretToBuild is now NULL");
        turretToBuild = null;

    }

}
