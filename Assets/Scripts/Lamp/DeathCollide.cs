using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCollide : MonoBehaviour
{
    [Header("final lamp")]
    public GameObject lampGameObject;

    Lamp lampComponent;
    Light lightToStart;

    public bool startChecking = false;
    

    // Start is called before the first frame update
    void Start()
    {
        
        lightToStart =  lampGameObject.GetComponent<Light>();
        lampComponent = lampGameObject.GetComponent<Lamp>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) 
    {
        if(startChecking)
        {
            UnityEngine.Debug.Log(gameObject.name); 
            StartCoroutine(lampComponent.PopFinalLight());
            StopAllColliders(); 
                      
        }



    }


    public void StopAllColliders()
    {


        foreach(GameObject colliderObject in GameObject.FindGameObjectsWithTag("deathCollide"))
        {
        //    UnityEngine.Debug.Log("yo" + colliderObject.name);
           DeathCollide collider =  colliderObject.GetComponent<DeathCollide>();
           collider.startChecking = false;

        }

    }



}
