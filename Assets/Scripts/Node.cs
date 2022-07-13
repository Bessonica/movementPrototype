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

    // Start is called before the first frame update
    void Start()
    {
        x = 0.20f;
        y = -0.54f;
        z = 0.67f;
        vecToFixTurretPosition = new Vector3(x, y, z);

        
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        
    }

    void OnMouseDown()
    {
        if(turret != null)
        {
            UnityEngine.Debug.Log("cannot build turret here");
            return;
        }

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + vecToFixTurretPosition, transform.rotation);
    }

    void OnMouseEnter()
    {
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
