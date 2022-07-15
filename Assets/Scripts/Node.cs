using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{

    // private GameObject turret;

    public Color hoverColor;

    private Renderer rend;
    private Color startColor;

    private GameObject turret;

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


// when enter turret, set turret to build to null
    void OnMouseDown()
    {
        if(buildManager.GetTurretToBuild() == null)
        {
            return;
        }


        if(turret != null)
        {
            UnityEngine.Debug.Log("cannot build turret here");
            return;
        }

        GameObject turretToBuild = buildManager.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + vecToFixTurretPosition, transform.rotation);

        buildManager.SetTurretToBuildToNull();
    
    }

    void OnMouseEnter()
    {
        if(buildManager.GetTurretToBuild() == null)
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
