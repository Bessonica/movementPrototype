using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 1f;

    private Transform target;
    private Transform target1;
    private Transform target2;
    private Transform target3;


    private int wavePointIntIndex = 0;
    
    

    // in Waypoints.cs changed public Transform[] (8)  taken out "static" part
    // when static is in there is only one instance of class
    //without you can have several instances of this class
    // and here we add instance in editor

    //now need to find a way to address different ways through cs file.
    // find them by name for example
    // change  variable "Way" from WayA to WayB and etc
    // 
    public Waypoints WayOne;
    public Waypoints WayTwo;
    public Waypoints WayThree;
    public Waypoints WayFour;

    Waypoints currentWay;
    Vector3 randomVec;

    float x, y, z;

    private  GameObject[] WayArray;
 

    //TODO: create array WayArray and append all your ways into it 
    void Start()
    {
        // WayArray += WayOne;
        // WayArray += WayTwo;
        // WayArray += WayThree;
        // WayArray += WayFour;
        // UnityEngine.Debug.Log(WayArray);
        currentWay = Instantiate(WayOne);
        UnityEngine.Debug.Log(currentWay.name);

        target = currentWay.points[0];
        // currentWay = WayOne;


        // randomize movement
        x = Random.Range(-0.3f, 0.3f);
        y = 0;
        z = Random.Range(-0.3f, 0.3f);
        randomVec = new Vector3(x, y, z);
        
    }

    //movement 

    //     npc == enemy
    //  ANSWER: it kinda works. BUT all random postions are SAME for all enemies.it should be different for every one
    //    +optimization, if we have 20+ npc wouldnt it fry pc?

    //  how to make npc make smoother turns
    //     use quaterions? in relation to next point in line?
    //  FOUND ANSWER:     [Unity] 2D Curve Editor (E01: introduction and concepts)  (Sebastian Lague)
    //  
    
    void Update()
    {
        
// transform.position = transform.position + new Vector3(horizontalInput * movementSpeed * Time.deltaTime, verticalInput * movementSpeed * Time.deltaTime, 0);

// target = currentWay.points[wavePointIntIndex];

//          b
//     a         c
//  c - target  wavePointIntIndex + 2




// dir1 a - b
// dir2 b - c



        
        UnityEngine.Debug.Log(randomVec);
        Vector3 dir = target.position - transform.position + randomVec;

        UnityEngine.Debug.Log(x);
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);


//   t = speed * Time.deltaTime
        // transform.position = Vector3.Lerp(transform.position, target.position, speed * Time.deltaTime);
        // UnityEngine.Debug.Log(target.position);

        // if(Vector3.Distance(transform.position, target.position + randomVec) <= 0.4f)

        if(Vector3.Distance(transform.position, target.position + randomVec) <= 0.2f)
        {
            GetNextWaypoint();

        }
        
    }

    void GetNextWaypoint()
    {

        // randomize movement
        x = Random.Range(-0.3f, 0.3f);
        y = 0;
        z = Random.Range(-0.3f, 0.3f);
        randomVec = new Vector3(x, y, z);
        
        if(wavePointIntIndex >= currentWay.points.Length -1)
        {
            GetNextWay();
        }

        wavePointIntIndex++;

        target = currentWay.points[wavePointIntIndex];
        // target = currentWay.points[wavePointIntIndex];

    }

    void GetNextWay()
    {

        // x = Random.Range(-0.5f, 0.5f);
        // y = 0;
        // z = Random.Range(0f, 0.5f);
        // randomVec = new Vector3(x, y, z);


        switch(currentWay.name)
        {
            case "WayA(Clone)":
                 currentWay = Instantiate(WayTwo);
                 wavePointIntIndex = 0;

                 
                 break;


        }
        // targetObject = GameObject.Find("WayB");
        // target = targetObject.points[0];

        //destroy if reached end
        if(wavePointIntIndex >= currentWay.points.Length -1)
        {
            Destroy(gameObject);
            return;
        }


    }
}
