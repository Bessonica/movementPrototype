using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerCollide : MonoBehaviour
{


    [Header("final lamp")]
    public GameObject LampObject;

    Lamp lampComponent;
    Light lightToStart;
    

    // Start is called before the first frame update
    void Start()
    {
        
        lightToStart =  LampObject.GetComponent<Light>();
        lampComponent = LampObject.GetComponent<Lamp>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {

        StartCoroutine(lampComponent.FlickerFinalLight());



    }


}
