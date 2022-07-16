using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// idea for functions
// fullStop(amountOfSeconds)
// speedUp(newSpeed)
// vibrate?


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

    public int health = 50;

    
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

    // for FullStopFor()  function
    float stopTime;
 

 
    void Start()
    {

        
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


// npc stops for some amount of time
    public void FullStopFor(float amount)
    {
        // fStopStartTime = Time.time;
        UnityEngine.Debug.Log("started stop function TIME = " + Time.time);
        float fStopStartTime = 0;

        while(fStopStartTime <=amount)
        {
            fStopStartTime += UnityEngine.Time.deltaTime;
            UnityEngine.Debug.Log(" fStopStartTime = " + fStopStartTime);
            
        }
        UnityEngine.Debug.Log("finished stop function fStopStartTime = " + fStopStartTime);

        UnityEngine.Debug.Log("finished stop function TIME = " + Time.time);
        return;

    }

    // IEnumerator FullStopFor(float amount)
    // {
    //    UnityEngine.Debug.Log("FullStopFor   STARTED " + Time.time);
    //    yield return new WaitForSeconds(4);
    //    UnityEngine.Debug.Log("FullStopFor   ENDED " + Time.time);


    // }

    public void TakeDamage(int amount)
    {
        // UnityEngine.Debug.Log("TAKE DAMAGE YOOOOO");
        health -= amount;

        if(health <=0)
        {
            Die();
        }

    }

    void Die()
    {
        Destroy(gameObject);
    }

    void Update()
    {

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
        

        if(Vector3.Distance(transform.position, currentWay.points[wavePointIntIndex+1].position + randomVec ) <= 0.2f)
        {
            // UnityEngine.Debug.Log("   <color=yellow> __________ Get Next Way Point ________ </color>   ");
            GetNextWaypoint();

        }


        }


        
    }



    void GetNextWaypoint()
    {


        wavePointIntIndex++;

        
        if(wavePointIntIndex >= currentWay.points.Length -1 )
        {
            // UnityEngine.Debug.Log("   <color=yellow> __________ Get Next Way ________ </color>   ");
            GetNextWay();
        }

        startTime = Time.time;

        target = currentWay.points[wavePointIntIndex];
    }

    void GetNextWay()
    {
        FullStopFor(4f);

        switch(currentWay.name)
        {
            case "WayA":
                 currentWay = WayTwo;
                 wavePointIntIndex = 0;                 
                 break;


        }
        // targetObject = GameObject.Find("WayB");
        // target = targetObject.points[0];

        if(wavePointIntIndex >= currentWay.points.Length -1)
        {
            Destroy(gameObject);
            return;
        }


    }


}
