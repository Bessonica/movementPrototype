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


    private int wavePointIntIndex;
    
    //   really fucking important
    // last waypoint should be in same place as first waypoint of NEW way
    // way length needs to be >= 2

    

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
    float pointLength;

    float x, y, z;

    private  GameObject[] WayArray;

    float startTime;
 

    //TODO: create array WayArray and append all your ways into it 
    void Start()
    {
        // WayArray += WayOne;
        // WayArray += WayTwo;
        // WayArray += WayThree;
        // WayArray += WayFour;
        // UnityEngine.Debug.Log(WayArray);

        // engine creates CLONE of wayOne, does it take resources?

        // it does
        // when enemy is destroy all clones should also be destroyed
        // but its still a problem if i will have a lot of enemies
        
        currentWay = WayOne;

        // UnityEngine.Debug.Log(currentWay.name);
        wavePointIntIndex = 0;
        target = currentWay.points[0];
        // currentWay = WayOne;


        // randomize movement
        x = Random.Range(-0.4f, 0.4f);
        y = 0;
        z = Random.Range(-0.4f, 0.4f);
        randomVec = new Vector3(x, y, z);
        startTime = Time.time;
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
        // UnityEngine.Debug.Log(gameObject.name); // or  this.name
        // works
        // and .this works
        // if(gameObject.transform.parent.name == "EnemyGroupPreset")
        // {
        //     // UnityEngine.Debug.Log("YO");
        // }
        // else
        // {}

        // if(gameObject.IsChildOf())

        


        if(gameObject.transform.parent != null)
        {
            // UnityEngine.Debug.Log("YO null");
        }
        else
        {

            
        // UnityEngine.Debug.Log("wavePoint index " + wavePointIntIndex);

        //if enemy is in enemyGroup1 do nothing
        // else do all of this down here



        var step =  speed * Time.deltaTime; 
        

        if(currentWay.points[wavePointIntIndex].childCount > 0)
        {
            
            //   .GetChild(0);


            // UnityEngine.Debug.Log("<color=blue> Object has children </color>" + currentWay.points[wavePointIntIndex].GetChild(0).position  );
            
            
            //wavepointIndex        GetcChild(0)         wavePointInex+1
            //      a                    b                     c
            Vector3 turnWayA = currentWay.points[wavePointIntIndex].position + randomVec;
            Vector3 turnWayB = currentWay.points[wavePointIntIndex].GetChild(0).position + randomVec;
            Vector3 turnWayC = currentWay.points[wavePointIntIndex+1].position + randomVec;

            Vector3 turndir1 = turnWayB;
            Vector3 turndir2 = turnWayC;

            float distCovered = (Time.time - startTime)*speed;
            pointLength = Vector3.Distance(turnWayA, turndir2);
            float fraction = distCovered/pointLength;
            // UnityEngine.Debug.Log("  fraction =  " + fraction);

            Vector3 dir1 = Vector3.Lerp(turnWayA, turndir1, fraction);
            Vector3 dir2 = Vector3.Lerp(turndir1, turndir2, fraction);
            Vector3 dir3 = Vector3.Lerp(dir1, dir2, fraction);

            
            transform.position = Vector3.MoveTowards(transform.position, dir3, step);
        }
        else
        {
            //   wavePointIntIndex      wavePointIntIndex+1
            //          a                       b
            float distCovered = (Time.time - startTime)*speed;
            pointLength = Vector3.Distance(currentWay.points[wavePointIntIndex].position + randomVec, currentWay.points[wavePointIntIndex+1].position + randomVec);
            float fraction = distCovered/pointLength;

            Vector3 dir = Vector3.Lerp(currentWay.points[wavePointIntIndex].position + randomVec, currentWay.points[wavePointIntIndex+1].position + randomVec, fraction);
            transform.position = Vector3.MoveTowards(transform.position, dir, step);
        }
        




// old version with RANDOM VECTOR
        // if(Vector3.Distance(transform.position, target.position + randomVec) <= 0.2f)
        // {
        //     GetNextWaypoint();

        // }

        if(Vector3.Distance(transform.position, currentWay.points[wavePointIntIndex+1].position + randomVec ) <= 0.2f)
        {
            // UnityEngine.Debug.Log("   <color=yellow> __________ Get Next Way Point ________ </color>   ");
            
            
            GetNextWaypoint();

        }


        }


        
    }



    void GetNextWaypoint()
    {


        // UnityEngine.Debug.Log("<color=red> __________ CHANGED WAYPOINT INDEX  ________ </color>   ");
        // UnityEngine.Debug.Log(wavePointIntIndex+1);
        // //currentWay.points.Length
        // UnityEngine.Debug.Log(currentWay.points.Length);
        // UnityEngine.Debug.Log("<color=red> __________ CHANGED WAYPOINT INDEX  ________ </color>   ");



//  dont forget about changing randvector to make it look more natural
//    plus randomvector for each npc should be different

        // randomize movement
        // x = Random.Range(-0.3f, 0.3f);
        // y = 0;
        // z = Random.Range(-0.3f, 0.3f);
        // randomVec = new Vector3(x, y, z);

        wavePointIntIndex++;


        //     !!!! important  !!!   it was   >= currentWay.points.Length -2

        //   really fucking important
        // last waypoint should be in same place as first waypoint of NEW way
        // way length needs to be >= 2
        
        if(wavePointIntIndex >= currentWay.points.Length -1 )
        {
            // UnityEngine.Debug.Log("   <color=yellow> __________ Get Next Way ________ </color>   ");
            GetNextWay();
        }

        

        startTime = Time.time;

        target = currentWay.points[wavePointIntIndex];
       
        // target = currentWay.points[wavePointIntIndex];

    }

    void GetNextWay()
    {

        // x = Random.Range(-0.4f, 0.4f);
        // y = 0;
        // z = Random.Range(-0.4f, 0.4f);
        // randomVec = new Vector3(x, y, z);


        switch(currentWay.name)
        {
            case "WayA":
                //  UnityEngine.Debug.Log("   <color=green> __________ Get Next Way: changed way ________ </color>   ");
                //  Destroy(currentWay);
                 currentWay = WayTwo;
                 wavePointIntIndex = 0;
                //  UnityEngine.Debug.Log("   <color=green> __________ Get Next Way: wavePointIntIndex ________ </color> " + wavePointIntIndex);

                 

                 
                 break;


        }
        // targetObject = GameObject.Find("WayB");
        // target = targetObject.points[0];

        //destroy if reached end
        if(wavePointIntIndex >= currentWay.points.Length -1)
        {
            // its not enaugh
            // you need to also destroy all clones of ways
            // WayA(Clone) and etc
            // Destroy(currentWay);
            Destroy(gameObject);
            // Destroy(WayOne);
            // Destroy(WayTwo);
            return;
        }


    }
}
