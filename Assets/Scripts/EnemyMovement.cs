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

    private GameObject[] WayArray;

    float startTime;

    // for FullStopFor()  function
    float stopTime;

    [Header("if it is final enemy")]
    public bool IsFinalEnemy;

    [Header("Should we stop when reach end of way")]
    public bool NeedToStop;
    public bool stopNow;

    [Header("Door")]
    public GameObject DoorObject;
    DoorBehaiviour door;

    float amountToStopFor = 5f;

    public GameObject gameMaster;
    WaveSpawner waveSpawnerObject;

    public Coroutine bashOnDoorHardest;




    void Start()
    {
        waveSpawnerObject = gameMaster.GetComponent<WaveSpawner>();
        door = DoorObject.GetComponent<DoorBehaiviour>();


        stopNow = false;

        currentWay = WayOne;

        // UnityEngine.Debug.Log(currentWay.name);
        wavePointIntIndex = 0;
        target = currentWay.points[0];
        // currentWay = WayOne;


        // randomize movement
        if (IsFinalEnemy)
        {
            x = 0;
            y = 0;
            z = 0;
            randomVec = new Vector3(x, y, z);

        }
        else
        {

            x = Random.Range(-0.4f, 0.4f);
            y = 0;
            z = Random.Range(-0.4f, 0.4f);
            randomVec = new Vector3(x, y, z);


        }



        startTime = Time.time;
    }


    // npc stops for some amount of time
    //  FOUND SOLUTION
    // check stopNow bool variable


    // FullStopFor function SHOULD NOT be courutine. it should stop ALL proccesses
    // probably thats why there is mistake
    IEnumerator FullStopFor(float amount)
    {
        stopNow = true;
        yield return new WaitForSeconds(amount);
        stopNow = false;
    }

    // public void FullStopFor(float amount)
    // {
    //     stopNow = true;
    //     amountToStopFor -= UnityEngine.Time.deltaTime;
    //     if(amountToStopFor >= 0)
    //     {
    //         return;
    //     }
    //     stopNow = false;
    // }



    void Update()
    {

        if (!stopNow)
        {





            if (gameObject.transform.parent != null)
            {
                // UnityEngine.Debug.Log("YO null");
            }
            else
            {


                // UnityEngine.Debug.Log("wavePoint index " + wavePointIntIndex);

                //if enemy is in enemyGroup1 do nothing
                // else do all of this down here



                var step = speed * Time.deltaTime;


                if (currentWay.points[wavePointIntIndex].childCount > 0)
                {
                    //wavepointIndex        GetcChild(0)         wavePointInex+1
                    //      a                    b                     c
                    Vector3 turnWayA = currentWay.points[wavePointIntIndex].position + randomVec;
                    Vector3 turnWayB = currentWay.points[wavePointIntIndex].GetChild(0).position + randomVec;
                    Vector3 turnWayC = currentWay.points[wavePointIntIndex + 1].position + randomVec;

                    Vector3 turndir1 = turnWayB;
                    Vector3 turndir2 = turnWayC;

                    float distCovered = (Time.time - startTime) * speed;
                    pointLength = Vector3.Distance(turnWayA, turndir2);
                    float fraction = distCovered / pointLength;
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
                    float distCovered = (Time.time - startTime) * speed;
                    pointLength = Vector3.Distance(currentWay.points[wavePointIntIndex].position + randomVec, currentWay.points[wavePointIntIndex + 1].position + randomVec);
                    float fraction = distCovered / pointLength;

                    Vector3 dir = Vector3.Lerp(currentWay.points[wavePointIntIndex].position + randomVec, currentWay.points[wavePointIntIndex + 1].position + randomVec, fraction);
                    transform.position = Vector3.MoveTowards(transform.position, dir, step);
                }


                if (Vector3.Distance(transform.position, currentWay.points[wavePointIntIndex + 1].position + randomVec) <= 0.2f)
                {
                    // UnityEngine.Debug.Log("   <color=yellow> __________ Get Next Way Point ________ </color>   ");
                    GetNextWaypoint();

                }


            }




        }




    }



    void GetNextWaypoint()
    {


        wavePointIntIndex++;


        if (wavePointIntIndex >= currentWay.points.Length - 1)
        {
            // UnityEngine.Debug.Log("   <color=yellow> __________ Get Next Way ________ </color>   ");

            //  if it is zero wave we should stop enemy
            // StartCoroutine(FullStopFor(3f));


            GetNextWay();
        }

        startTime = Time.time;

        target = currentWay.points[wavePointIntIndex];
    }

    void GetNextWay()
    {


        // its stupid. it needs to change it no matter tha name of way
        switch (currentWay.name)
        {
            case "WayA":
                currentWay = WayTwo;
                wavePointIntIndex = 0;
                break;
            case "WayZeroOne":
                StartCoroutine(FullStopFor(4f));
                currentWay = WayTwo;
                wavePointIntIndex = 0;
                break;


        }
        // targetObject = GameObject.Find("WayB");
        // target = targetObject.points[0];

        // UnityEngine.Debug.Log("");
        if (wavePointIntIndex >= currentWay.points.Length - 1)
        {

            // when final enemy reaches end of its road
            if (IsFinalEnemy)
            {
                stopNow = true;

                StartCoroutine(RoarAndSpawnStrongEnemies(5f, 19f));


                // ITS IMPORTANT 
                // after final enemy reaches destination
                // we play his sound wait and spawn even more enemies
                return;

            }
            else
            {
                Destroy(gameObject);
                return;
            }

        }


    }



    IEnumerator RoarAndSpawnStrongEnemies(float waitBeforeRoar, float waitAfterRoar)
    {
        yield return new WaitForSeconds(waitBeforeRoar);

        // play roar sound effect
        // AudioManager.instance.SoundFinalRoarSFX();

        AudioManager.instance.StartSoundFinalRoarSFX();

        yield return new WaitForSeconds(1f);

        // stop all npc on screen
        waveSpawnerObject.StopAllEnemies();

        // wait waitAfterRoar
        yield return new WaitForSeconds(waitAfterRoar);

        AudioManager.instance.StartWaveDetectedSFX(1f);
        AudioManager.instance.StartWaveDetectedSFX(3f);
        AudioManager.instance.StartWaveDetectedSFX(4f);
        AudioManager.instance.StartWaveDetectedSFX(6f);
        AudioManager.instance.StartWaveDetectedSFX(8f);

        // resume movement
        waveSpawnerObject.StartAllEnemies();

        // start spawning strongFinalEnemies
        UnityEngine.Debug.Log("<color=green>SPAWNING STRONG ENEMIES </color>");
        UnityEngine.Debug.Log("<color=green>SPAWNING STRONG ENEMIES </color>");
        UnityEngine.Debug.Log("<color=green>SPAWNING STRONG ENEMIES </color>");

        waveSpawnerObject.StartSpawnStrongEnemies();

        yield return new WaitForSeconds(1f);
        AudioManager.instance.StartAfterFinalRoarSFX();

        // after some time make door bash louder
        // can put new fucntion for door, where it bashes much faster
        yield return new WaitForSeconds(35f);      //22f
        UnityEngine.Debug.Log("MADE DOOR LOUDER");

        if (waveSpawnerObject.bashOnDoorHard != null)
        {
            StopCoroutine(waveSpawnerObject.bashOnDoorHard);
        }


        bashOnDoorHardest = StartCoroutine(door.BashOnDoorHardest(DoorObject));
        AudioManager.instance.SetDoorBashVolume(1.2f);

        // count till final and stop courutine
        yield return new WaitForSeconds(9f);       //16f
        StopCoroutine(bashOnDoorHardest);


        // change DoorBash and change sound behind door, and maybe add/change ost


    }

    public void TakeDamage(int amount)
    {
        // UnityEngine.Debug.Log("TAKE DAMAGE YOOOOO");
        health -= amount;

        if (health <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        Destroy(gameObject);
    }


}
