using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    Vector3 vecToFixTurretPosition;
    float x, y, z;

    public bool needToDestroy;
    public GameObject NodeArray;

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

//       destroy turret
        needToDestroy = false;
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


    public void SetTurretToBuild(TurretBlueprint turret)
    {
        UnityEngine.Debug.Log("SetTurretToBuild:  standart turret purchased");
        turretToBuild = turret;

    }


    public void SetTurretToBuildToNull()
    {
        UnityEngine.Debug.Log("SetTurretToBuildToNull:  turretToBuild is now NULL");
        turretToBuild = null;

    }


    public void DestroyAllTurrets()
    {    
        foreach(Transform Child in NodeArray.transform)
        {
            Node childNode = Child.GetComponent<Node>();
            Destroy(childNode.turret);
        }

            // Transform Child = NodeArray.transform.GetChild(1);
            // Node childNode = Child.GetComponent<Node>();
            // Destroy(childNode.turret);

    }

//  this doesnt work



    public void DestroyTurretOn(Node node)
    {
        // we have node and we can set its turret parametr to null

        // for now i dont know how to fix this, turret overlays node, so its impossible to press
        node.turret = null;
        PlayerStats.Money += turretToBuild.cost;
        UnityEngine.Debug.Log("<color=green> turret deactivated Money left  </color>" + PlayerStats.Money );
        
        
    }

    public void SetTurretToDestroy()
    {
        UnityEngine.Debug.Log("SetTurretToDestroy:  needToDestroy before " + needToDestroy);
        needToDestroy = true;
        UnityEngine.Debug.Log("SetTurretToDestroy:  needToDestroy after  " + needToDestroy);
        

    }





}
