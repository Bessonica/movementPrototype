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

    void Start()
    {
        turretToBuild = standartTurretPrefab;

    }


    

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

}
