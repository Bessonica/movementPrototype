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
    int waveOverZero;


    [Header("Enemy wave one")]
    public Transform enemyPrefabOne;
    public Transform spawnPointOne;
    public int waveAmountOne; // how many npc in wave
    public int waveSpawnTimesOne; // how many times wave is spawned
    public float timeBetweenOne;
    int waveOverOne;

    [Header("Enemy wave two")]
    public Transform enemyPrefabTwo;
    public Transform spawnPointTwo;


    
    public float timeBetweenWaves = 10f;

// this strings are responsible for choosing what phase is right now
    // in (interactable.cs) we reassign phaseString and it changes here
    public string phaseString,phaseStringStart, phaseStringZero, phaseStringFirst, phaseStringSecond;

    private float countdown = 2f; // wait time before first wave

    int waveOverIndex;



    Vector3 randomVec;
    float x, y, z;


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


    }

    // Update is called once per frame
    private void Update()
    {
//  I FOUND A WAY TO MANAGE PHASE IN BEGINING
    // when you didnt pull lever phase string is "zero"
    // or ttwo variables(pcIsOn, phaseString)
        //if phaseString == zero {return;}

        //  phase changing
        //     probably use    case:
        if(phaseString == phaseStringZero)
        {

            if(countdown <= 0f && waveOverZero > 0)
            {
                StartCoroutine(SpawnWave(enemyPrefabZero,waveAmountZero, 1));
                countdown = timeBetweenOne;
            }

            countdown -= UnityEngine.Time.deltaTime;
            // UnityEngine.Debug.Log("countdown = " + countdown);



        }
        else if (phaseString == phaseStringFirst)
        {
            // and we keep changing all of it

            // wave1
            if(countdown <= 0f && waveOverOne > 0)
            {
                StartCoroutine(SpawnWave(enemyPrefabOne,waveAmountOne, 1));
                countdown = timeBetweenOne;
            }

            countdown -= UnityEngine.Time.deltaTime;
            // UnityEngine.Debug.Log("countdown = " + countdown);
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
