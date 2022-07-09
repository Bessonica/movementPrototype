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
        
// transform.position = transform.position + new Vector3(horizontalInput * movementSpeed * Time.deltaTime, verticalInput * movementSpeed * Time.deltaTime, 0);

// target = currentWay.points[wavePointIntIndex];

//          b 1
//     a 0        c 2
//  c - target  wavePointIntIndex + 2




// dir1 a - b
// dir2 b - c

    
 // my vector solution
        // currentWay.points[wavePointIntIndex];
        // UnityEngine.Debug.Log(randomVec);
        // Vector3 dir = target.position - transform.position + randomVec;

        // UnityEngine.Debug.Log(x);
        // transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
       


                            // in future if optmization gonna suck, test each solution, which faster?
 // my lerp  solution (works shitty)

        // float newTime = (startTime - Time.time)/speed;

        // transform.position = testLerp(currentWay.points[0].position, currentWay.points[1].position, newTime);

// unity lerp solution ( CHECK UNITY LERP DOC )  works, BUT only with manualy choosen points(with wavePointIntIndex it just breaks)    

        float distCovered = (Time.time - startTime)*speed;

        pointLength = Vector3.Distance(currentWay.points[wavePointIntIndex].position, currentWay.points[wavePointIntIndex+1].position);
        // UnityEngine.Debug.Log(Vector3.Distance(transform.position, currentWay.points[wavePointIntIndex+1].position ) );
        float fraction = distCovered/pointLength;
        // UnityEngine.Debug.Log("fraction " + fraction);
        UnityEngine.Debug.Log("index " + wavePointIntIndex);
        
    // from a to b   WORKS but with manually choosen points
        // UnityEngine.Debug.Log("lerp for transform.position " + Vector3.Lerp(currentWay.points[wavePointIntIndex].position, currentWay.points[wavePointIntIndex+1].position, fraction));
        // transform.position = Vector3.Lerp(currentWay.points[wavePointIntIndex].position, currentWay.points[wavePointIntIndex+1].position, fraction);
        
    // from a to c,  b as ?anker?   WORKS but with manually choosen points
        // Vector3 dir1 = Vector3.Lerp(currentWay.points[0].position, currentWay.points[1].position, fraction);
        // Vector3 dir2 = Vector3.Lerp(currentWay.points[1].position, currentWay.points[2].position, fraction);
        // transform.position = Vector3.Lerp(dir1, dir2, fraction);

        // Vector3 dir3 = Vector3.Lerp(dir1, dir2, fraction);
        


//  !! POSIBLE SOLUTION !!    use lerp only to make points,  BUT use transform.Translate to move it
        Vector3 dir = Vector3.Lerp(currentWay.points[wavePointIntIndex].position, currentWay.points[wavePointIntIndex+1].position, fraction);
        // UnityEngine.Debug.Log("Direction " + dir);
        // transform.Translate(dir.normalized * speed * Time.deltaTime,  Space.World);
        //
        // Alternative to  transform.Translate   (it fucking works, i hate myself and unity)
        var step =  speed * Time.deltaTime; 
        transform.position = Vector3.MoveTowards(transform.position, dir, step);




        // Vector3 one = Vector3.Lerp(currentWay.points[0].position, currentWay.points[1].position, speed * Time.deltaTime);
        // Vector3 two = Vector3.Lerp(currentWay.points[1].position, currentWay.points[2].position, speed * Time.deltaTime);

        // transform.position = Vector3.Lerp(one, two, speed * Time.deltaTime);

//   t = speed * Time.deltaTime
        // transform.position = Vector3.Lerp(transform.position, target.position, speed * Time.deltaTime);
        // UnityEngine.Debug.Log(target.position);



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


    public static Vector3 testLerp(Vector3 a, Vector3 b, float t)
    {
        return a+(a-b)*t;

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

        
        //     !!!! important  !!!
        if(wavePointIntIndex >= currentWay.points.Length -2 )
        {
            UnityEngine.Debug.Log("   <color=yellow> __________ Get Next Way ________ </color>   ");
            GetNextWay();
        }

        wavePointIntIndex++;

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
