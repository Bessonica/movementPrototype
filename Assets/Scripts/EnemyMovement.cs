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
        currentWay = Instantiate(WayOne);

        // UnityEngine.Debug.Log(currentWay.name);
        wavePointIntIndex = 0;
        target = currentWay.points[0];
        // currentWay = WayOne;


        // randomize movement
        x = Random.Range(-0.3f, 0.3f);
        y = 0;
        z = Random.Range(-0.3f, 0.3f);
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


        UnityEngine.Debug.Log("wavePoint index " + wavePointIntIndex);






    
 // my vector solution
        // currentWay.points[wavePointIntIndex];
        // UnityEngine.Debug.Log(randomVec);
        // Vector3 dir = target.position - transform.position + randomVec;

        // UnityEngine.Debug.Log(x);
        // transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
       

// unity lerp solution ( CHECK UNITY LERP DOC )  works, BUT only with manualy choosen points(with wavePointIntIndex it just breaks)    



        // float distCovered = (Time.time - startTime)*speed;

        // pointLength = Vector3.Distance(currentWay.points[wavePointIntIndex].position, currentWay.points[wavePointIntIndex+1].position);
        // // UnityEngine.Debug.Log(Vector3.Distance(transform.position, currentWay.points[wavePointIntIndex+1].position ) );
        // float fraction = distCovered/pointLength;
        // // UnityEngine.Debug.Log("fraction " + fraction);
        // UnityEngine.Debug.Log("index " + wavePointIntIndex);



        


        var step =  speed * Time.deltaTime; 

        if(currentWay.points[wavePointIntIndex].childCount > 0)
        {
            
            //   .GetChild(0);


            UnityEngine.Debug.Log("<color=blue> Object has children </color>" + currentWay.points[wavePointIntIndex].GetChild(0).position  );
            Vector3 turndir1 = currentWay.points[wavePointIntIndex].GetChild(0).position;
            Vector3 turndir2 = currentWay.points[wavePointIntIndex+1].position;

            float distCovered = (Time.time - startTime)*speed;
            pointLength = Vector3.Distance(currentWay.points[wavePointIntIndex].position, turndir2);
            float fraction = distCovered/pointLength;

            Vector3 dir1 = Vector3.Lerp(currentWay.points[wavePointIntIndex].position, turndir1, fraction);
            Vector3 dir2 = Vector3.Lerp(turndir1, turndir2, fraction);
            Vector3 dir3 = Vector3.Lerp(dir1, dir2, fraction);

            
            transform.position = Vector3.MoveTowards(transform.position, dir3, step);
        }
        else
        {
            float distCovered = (Time.time - startTime)*speed;
            pointLength = Vector3.Distance(currentWay.points[wavePointIntIndex].position, currentWay.points[wavePointIntIndex+1].position);
            float fraction = distCovered/pointLength;

            Vector3 dir = Vector3.Lerp(currentWay.points[wavePointIntIndex].position, currentWay.points[wavePointIntIndex+1].position, fraction);
            transform.position = Vector3.MoveTowards(transform.position, dir, step);
        }
        




// old version with RANDOM VECTOR
        // if(Vector3.Distance(transform.position, target.position + randomVec) <= 0.2f)
        // {
        //     GetNextWaypoint();

        // }

        if(Vector3.Distance(transform.position, currentWay.points[wavePointIntIndex+1].position ) <= 0.2f)
        {
            GetNextWaypoint();

        }
        
    }



    void GetNextWaypoint()
    {

        // UnityEngine.Debug.Log("<color=red> __________ CHANGED WAYPOINT INDEX  ________ </color>   ");
        // UnityEngine.Debug.Log("<color=red> __________ CHANGED WAYPOINT INDEX  ________ </color>   ");
        // UnityEngine.Debug.Log("<color=red> __________ CHANGED WAYPOINT INDEX  ________ </color>   ");
        UnityEngine.Debug.Log("<color=red> __________ CHANGED WAYPOINT INDEX  ________ </color>   ");
        UnityEngine.Debug.Log(wavePointIntIndex+1);
        //currentWay.points.Length
        UnityEngine.Debug.Log(currentWay.points.Length);
        UnityEngine.Debug.Log("<color=red> __________ CHANGED WAYPOINT INDEX  ________ </color>   ");
        // UnityEngine.Debug.Log("<color=red> __________ CHANGED WAYPOINT INDEX  ________ </color>   ");
        // UnityEngine.Debug.Log("<color=red> __________ CHANGED WAYPOINT INDEX  ________ </color>   ");
        // UnityEngine.Debug.Log("<color=red> __________ CHANGED WAYPOINT INDEX  ________ </color>   ");
        // UnityEngine.Debug.Log("<color=red> __________ CHANGED WAYPOINT INDEX  ________ </color>   ");
        // UnityEngine.Debug.Log("   <color=red> __________ CHANGED WAYPOINT INDEX  ________ </color>   ");

        // randomize movement
        x = Random.Range(-0.3f, 0.3f);
        y = 0;
        z = Random.Range(-0.3f, 0.3f);
        randomVec = new Vector3(x, y, z);

        wavePointIntIndex++;


        //     !!!! important  !!!   it was   >= currentWay.points.Length -2

        //   really fucking important
        // last waypoint should be in same place as first waypoint of NEW way
        
        if(wavePointIntIndex >= currentWay.points.Length -1 )
        {
            UnityEngine.Debug.Log("   <color=yellow> __________ Get Next Way ________ </color>   ");
            GetNextWay();
        }

        

        startTime = Time.time;

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
                 UnityEngine.Debug.Log("   <color=green> __________ Get Next Way: changed way ________ </color>   ");
                 currentWay = Instantiate(WayTwo);
                 wavePointIntIndex = 0;
                 UnityEngine.Debug.Log("   <color=green> __________ Get Next Way: wavePointIntIndex ________ </color> " + wavePointIntIndex);

                 

                 
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
