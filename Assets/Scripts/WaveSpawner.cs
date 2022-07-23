using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// inputs
//    prefabs of enemy for each wave(ways, speed etc)
//    ?amount of iterations for wave? how many times to spawn it
//    time between spawns

//достаточно двух волн, тпереь нужно понять как удобно менять их параметры по ходу игры
public class WaveSpawner : MonoBehaviour
{


    // [Header("turret variables")]
    // public float turretPrice;   // how much money turret cost
    // public float moneyInSecond; // how much money player gets in second

// need to have several variables for several different waves
//  waveOne
//  wave Two
//  ...
    [Header("Duration of phases")]
    public float phaseZeroDuration;
    public float phaseOneDuration;
    public float phaseTwoDuration;
    public float phaseThreeDuration;
    public float phaseFourDuration;

    [Header("Enemy wave zero")]
    public Transform enemyPrefabZero;
    public Transform spawnPointZero;
    public int waveAmountZero; // how many npc in wave
    public int waveSpawnTimesZero; // how many times wave is spawned
    public float timeBetweenZero;
    public float countdownZero;  // how long wait before starting spawning waves
    int waveOverZero;


    [Header("Enemy wave one")]
    public Transform enemyPrefabOne;
    public Transform spawnPointOne;
    public int waveAmountOne; // how many npc in wave
    public int waveSpawnTimesOne; // how many times wave is spawned
    public float timeBetweenOne;
    public float countdownOne;
    int waveOverOne;

    [Header("Enemy wave two")]
    public Transform enemyPrefabTwo;
    public Transform spawnPointTwo;


    
    public float timeBetweenWaves = 10f;

// this strings are responsible for choosing what phase is right now
    // in (interactable.cs) we reassign phaseString and it changes here
    public string phaseString,phaseStringStart, phaseStringZero, phaseStringFirst, phaseStringSecond, phaseStringThird, phaseStringFourth, phaseStringFinal;

    // private float countdown = 2f; // wait time before first wave
    // private float countdownOne = 2f;

    int waveOverIndex;



    Vector3 randomVec;
    float x, y, z;

    PlayerStats playerStats;
    BuildManager buildManager;

    public bool phaseIsOn;

    [Header("Lever and PC interactable objects")]
    public GameObject PC;
    public GameObject Lever;
    
    [Header("Door")]
    public GameObject DoorObject;
    DoorBehaiviour door;

    Interactable pcInteractable, leverInteractable;
     

    float phaseStartTime = 0;
    float phaseTime = 0;
    float phaseDeadLine = 1;


// idea: phases
//  string variables to separate phases
//      "intro": spawn one slow enemy
//     "phase 1": spawn wave 1
//     "phase 2": spawn wave 1 and 2
//  and so on...
    



    // Start is called before the first frame update
    void Start()
    {
        // UnityEngine.Debug.Log("started " + Time.time);

        x = Random.Range(-0.4f, 0.4f);
        y = 0;
        z = Random.Range(-0.4f, 0.4f);
        randomVec = new Vector3(x, y, z);

        // check how many times to spawn wave

        
        waveOverZero = waveSpawnTimesZero;
        waveOverOne = waveSpawnTimesOne;
    
    // variables for phases
        phaseStringStart = "game has not began yet";
        phaseString = "game has not began yet";

        phaseStringZero = "0";
        phaseStringFirst = "1";
        phaseStringSecond = "2";
        phaseStringThird = "3";
        phaseStringFourth = "4";
        phaseStringFinal = "final";

        
        phaseIsOn = false;
        playerStats = this.GetComponent<PlayerStats>();
        buildManager = this.GetComponent<BuildManager>();

        pcInteractable = PC.GetComponent<Interactable>();
        leverInteractable = Lever.GetComponent<Interactable>();

        door = DoorObject.GetComponent<DoorBehaiviour>();


    }


// what we do when player pull the lever
    public void StartPhase()
    {
        // StopCourutine(door.BashOnDoor());
        phaseStartTime = Time.time;
        playerStats.startTimer = true;
        phaseIsOn = true;

        door.keepBashing = false;
        
        // playerStats = this.GetComponent<PlayerStats>();

        PlayerStats.Money = 0; 
        // Money is static variable, so you can access it from everywhere?
        // read about public static

   

        
        // if its first time we pulled lever
            if(phaseString == phaseStringStart)
            {
                // start phaseZero
                phaseString = phaseStringZero;   
                phaseDeadLine = phaseZeroDuration;
                UnityEngine.Debug.Log("STARTED ZERO PHASE ");
                
                StartCoroutine(door.BashOnDoor(DoorObject));
            }
            else if(phaseString == phaseStringZero)
            {
                phaseString = phaseStringFirst;
                phaseDeadLine = phaseOneDuration;
                UnityEngine.Debug.Log("STARTED FIRST PHASE ");

            }else if(phaseString == phaseStringFirst)
            {
                phaseString = phaseStringSecond;
                phaseDeadLine = phaseTwoDuration;
                UnityEngine.Debug.Log("STARTED SECOND PHASE ");

            }else if(phaseString == phaseStringSecond)
            {
                phaseString = phaseStringThird;
                phaseDeadLine = phaseThreeDuration;
                UnityEngine.Debug.Log("STARTED THIRD PHASE ");

                // StartCoroutine(door.BashOnDoor(DoorObject));

            }else if(phaseString == phaseStringThird)
            {
    //во время фазы/волны к двери слышно вссе больше и больше ударов
    // то есть запускаем корутину и в завивисмости от длинны волны(phaseThreeDuration)
    // и через определенное время меняем звуковой еффект на новый
                phaseString = phaseStringFourth;
                phaseDeadLine = phaseFourDuration;
                UnityEngine.Debug.Log("STARTED FOURTH PHASE ");



            }else if(phaseString == phaseStringFourth)
            {
                phaseString = phaseStringFinal;
                phaseDeadLine = phaseFourDuration;
                UnityEngine.Debug.Log("STARTED FINAL PHASE ");


            }



            
            //when we started phase player cant use lever

            leverInteractable.isLeverOn = false;
           
                


    }

// what we do when phase time ends
    public void StopPhase()
    {

        if(phaseString != phaseStringZero)
        {

        phaseIsOn = false;
        playerStats.startTimer = false;
        PlayerStats.Money = 0; 

        pcInteractable.turnOffPC();
        buildManager.DestroyAllTurrets();


        }



//create object monsterSound behind door and activate it here
// решаем какие звуки ставить, когда выключается свет
        if(phaseString == phaseStringZero)
        {
           UnityEngine.Debug.Log("PHASE ZERO ENDED ");
           StartPhase();

        
        }else if(phaseString == phaseStringFirst)
        {
    //слышно шум задверью, но ее никто не трогает
            UnityEngine.Debug.Log("PHASE ONE ENDED ");
            

        }else if(phaseString == phaseStringSecond)
        {           
    //шум за дверью громче и агрессивнее
            UnityEngine.Debug.Log("PHASE TWO ENDED ");


        }else if(phaseString == phaseStringThird)
        {

            UnityEngine.Debug.Log("PHASE THREE ENDED ");
    


        }else if(phaseString == phaseStringFourth)
        {
            UnityEngine.Debug.Log("PHASE FOUR ENDED ");



        }else if(phaseString == phaseStringFinal)
        {
            // unfinished
            UnityEngine.Debug.Log("PHASE FINAL ENDED ");



        }
        


        

    // when phase is stoped player can use lever to turn it on again
        if(phaseString != phaseStringZero)
        {
            leverInteractable.isLeverOn = true;
            
        }
        
    }

    // Update is called once per frame
    private void Update()
    {


        if(!phaseIsOn)
        {
            return;
        }


  //  check if phase time has ended
        phaseTime = Time.time;
        if((phaseTime - phaseStartTime) >= phaseDeadLine && phaseString != phaseStringFinal)
        {
            // UnityEngine.Debug.Log("phaseTime - phaseStartTime = " + (phaseTime - phaseStartTime ));
            // UnityEngine.Debug.Log("phase has ended phasezeroDuration = " + phaseDeadLine );
            StopPhase();
        }



        if(phaseString == phaseStringZero)
        {

            if(countdownZero <= 0f && waveOverZero > 0)
            {
                StartCoroutine(SpawnWave(enemyPrefabZero,waveAmountZero, 1));
                countdownZero = timeBetweenOne;
            }

            countdownZero -= UnityEngine.Time.deltaTime;
            // UnityEngine.Debug.Log("countdown = " + countdown);



        }
        else if (phaseString == phaseStringFirst)
        {
            // wave1
            if(countdownOne <= 0f && waveOverOne > 0)
            {
                StartCoroutine(SpawnWave(enemyPrefabOne,waveAmountOne, 1));
                countdownOne = timeBetweenOne;
            }

            countdownOne -= UnityEngine.Time.deltaTime;
            // UnityEngine.Debug.Log("countdown = " + countdown);

        }else if (phaseString == phaseStringSecond)
        {



        }else if (phaseString == phaseStringThird)
        {



        }else if (phaseString == phaseStringFourth)
        {



        }else if (phaseString == phaseStringFinal)
        {



        }
        



    }


// waveNumber - choose what wave to spawn
    IEnumerator SpawnWave(Transform enemyPrefabToSpawn, int waveAmountToSpawn, int waveNumber)
    {

        for(int i=0; i<waveAmountToSpawn; i++)
        {
            
            SpawnEnemy(enemyPrefabToSpawn, waveNumber);
            // UnityEngine.Debug.Log("spawned enemy waveIndex = " + waveAmountToSpawn);
            
            yield return new WaitForSeconds(0.5f);
            
        }

//  check how many times we spawned wave
        if(phaseString == "0")
        {
            waveOverZero--;

        }
        else if(phaseString == "1")
        {
            waveOverOne--;

        }

        

        
        

        //      when npc spawn in groups
        // SpawnEnemy();
        // UnityEngine.Debug.Log("spawned enemy waveIndex = " + waveNumber);


        // yield return new WaitForSeconds(0.5f);
        // UnityEngine.Debug.Log("Hellow");
        
    }

//  а зачем waveNmber?????
    void SpawnEnemy(Transform enemy, int waveNumber)
    {

                x = Random.Range(-0.4f, 0.4f);
                y = 0;
                z = Random.Range(-0.4f, 0.4f);
                randomVec = new Vector3(x, y, z);
                // UnityEngine.Debug.Log("spawned an enemy. time = " + Time.time + "   randomVec =  " + randomVec);
                Instantiate(enemy, spawnPointOne.position + randomVec, spawnPointOne.rotation);

        // if(waveNumber == 0)
        // {
        //         x = Random.Range(-0.4f, 0.4f);
        //         y = 0;
        //         z = Random.Range(-0.4f, 0.4f);
        //         randomVec = new Vector3(x, y, z);
        //         // UnityEngine.Debug.Log("spawned an enemy. time = " + Time.time + "   randomVec =  " + randomVec);
        //         Instantiate(enemy, spawnPointOne.position + randomVec, spawnPointOne.rotation);
        // }

        // if(waveNumber == 1)
        // {

        //     if(enemyPrefabOne!=null)
        //     {

        //         x = Random.Range(-0.4f, 0.4f);
        //         y = 0;
        //         z = Random.Range(-0.4f, 0.4f);
        //         randomVec = new Vector3(x, y, z);
        //         // UnityEngine.Debug.Log("spawned an enemy. time = " + Time.time + "   randomVec =  " + randomVec);
        //         Instantiate(enemy, spawnPointOne.position + randomVec, spawnPointOne.rotation);
        //     }

        // }
        // else if(waveNumber == 2)
        // {
            
        //     //enemyPrefabTwo
        //     if(enemyPrefabTwo!=null)
        //     {
        //         x = Random.Range(-0.4f, 0.4f);
        //         y = 0;
        //         z = Random.Range(-0.4f, 0.4f);
        //         randomVec = new Vector3(x, y, z);
        //     Instantiate(enemyPrefabTwo, spawnPointOne.position + randomVec, spawnPointOne.rotation);

        //     }

        // }







    }
}
