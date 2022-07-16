using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{

    // private GameObject turret;

    public Color hoverColor;

    private Renderer rend;
    private Color startColor;

    [Header("optinal, if you want to start level with turrets already on")]
    public GameObject turret;

    Vector3 vecToFixTurretPosition;
    float x, y, z;

    BuildManager buildManager;

// when you press activate turret, you activate it one time
    void Start()
    {
        x = 0.1f;
        y = 0.2f;
        z = 0.17f;
        vecToFixTurretPosition = new Vector3(x, y, z);

        
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
        
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + vecToFixTurretPosition;
    }


// when enter turret, set turret to build to null
    void OnMouseDown()
    {


        if(!buildManager.CanBuild && !buildManager.needToDestroy)
        {
            return;
            // if you choose turret to deactivate

        }

        if(buildManager.needToDestroy && turret == null)
        {
            UnityEngine.Debug.Log(" THERE IS NOTHING TO DESTROY ");

            return;

        }

        
        if(buildManager.needToDestroy && turret != null)
        {
            UnityEngine.Debug.Log("!!!! BUILD MANAGER DESTROY buildManager.needToDestroy");
            buildManager.DestroyTurretOn(this);
            buildManager.needToDestroy = false;
            return;

        }

        if(turret != null)
        {
            UnityEngine.Debug.Log("cannot build turret here");
            return;
        }

        buildManager.BuildTurretOn(this);
        buildManager.SetTurretToBuildToNull();


        // //DestroyTurretOn 
        // buildManager.DestroyTurretOn(this);


    
    }

    void OnMouseEnter()
    {
        if(!buildManager.CanBuild)
        {
            return;
        }
        
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
