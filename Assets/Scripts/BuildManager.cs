using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    Vector3 vecToFixTurretPosition;
    float x, y, z;

    void Awake()
    {
        if(instance != null)
        {
            UnityEngine.Debug.Log("you alreaddy have build manager");
            return;
        }
        instance = this;

        x = 0.1f;
        y = 0.2f;
        z = 0.17f;
        vecToFixTurretPosition = new Vector3(x, y, z);
    }

    public GameObject standartTurretPrefab;
    private TurretBlueprint turretToBuild;

    public bool CanBuild {get { return turretToBuild != null; } }

    public void BuildTurretOn(Node node)
    {
        // money part !!!!!
        if(PlayerStats.Money < turretToBuild.cost)
        {
            UnityEngine.Debug.Log("no money for turret");
            return;
        }
        PlayerStats.Money -= turretToBuild.cost;
        UnityEngine.Debug.Log("<color=yellow> Money left  </color>" + PlayerStats.Money );


        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        
    }

    public void DestroyTurretOn(Node node)
    {
        // we have node and we can set its turret parametr to null
        
        // node.turret = null;
        
    }


    //это убрать ? 15 мин
    //у меня нихуя не работает
    //без старта shop.cs обращается к buildManager.SetTurretToBuild(buildManager.standartTurretPrefab);
    // и там null, и я хз почему
    //
    // void Start()
    // {
    //     turretToBuild = standartTurretPrefab;

    // }


    

    // public GameObject GetTurretToBuild()
    // {
    //     return turretToBuild;
    // }

    // public void SetTurretToBuild(GameObject turret)
    // {
    //     UnityEngine.Debug.Log("SetTurretToBuild:  standart turret purchased");
    //     turretToBuild = turret;

    // }

    public void SetTurretToBuildToNull()
    {
        UnityEngine.Debug.Log("SetTurretToBuildToNull:  turretToBuild is now NULL");
        turretToBuild = null;

    }



    public void SetTurretToBuild(TurretBlueprint turret)
    {
        UnityEngine.Debug.Log("SetTurretToBuild:  standart turret purchased");
        turretToBuild = turret;

    }
}
