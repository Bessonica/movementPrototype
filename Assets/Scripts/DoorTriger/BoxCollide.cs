using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollide : MonoBehaviour
{

    [Header("Door")]
    public GameObject DoorObject;
    DoorBehaiviour door;

    public bool StartChecking = false;


    // Start is called before the first frame update
    void Start()
    {
        door = DoorObject.GetComponent<DoorBehaiviour>();
        // StartChecking = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

// start bash on door fucntion
    void OnTriggerEnter(Collider other) {
        if(StartChecking)
        {
            StartCoroutine(door.BashOnDoor(DoorObject));
            UnityEngine.Debug.Log("Collider entered");
            StartChecking = false;
        }

    }
}
