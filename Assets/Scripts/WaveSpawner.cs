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


    [Header("turret variables")]
    public float turretPrice;   // how much money turret cost
    public float moneyInSecond; // how much money player gets in second

// need to have several variables for several different waves
//  waveOne
//  wave Two
//  ...
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

    public string phaseString, phaseStringZero, phaseStringFirst;

    private float countdown = 2f; // wait time before first wave



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

        waveOverOne = waveSpawnTimesOne;
    
    // variables for phases
        phaseString = "game has not began yet";

        phaseStringZero = "0";
        phaseStringFirst = "1";

    }

    // Update is called once per frame
    private void Update()
    {
        // how to manage spawn in specific time, or after some event?



//  I FOUND A WAY TO MANAGE PHASE IN BEGINING
    // when you didnt pull lever phase string is "zero"
    // or ttwo variables(pcIsOn, phaseString)
        //if phaseString == zero {return;}

        //  phase changing
        //     probably use    case:
        if(phaseString == "0")
        {

        // wave1
        if(countdown <= 0f && waveOverOne > 0)
        {
            //start phase0

            //if phasString == "1"
            // start phase1

            //if phaseString == "2"
            // start phase 2

            StartCoroutine(SpawnWave(enemyPrefabOne,waveAmountOne));
            countdown = timeBetweenOne;
            
            
        }

        countdown -= UnityEngine.Time.deltaTime;
        // UnityEngine.Debug.Log("countdown = " + countdown);

        }
        else if (phaseString == phaseStringFirst)
        {
            // and we keep changing all of it
        }




        
    }

    IEnumerator SpawnWave(Transform enemyPrefabToSpawn, int waveAmountToSpawn)
    {

        for(int i=0; i<waveAmountToSpawn; i++)
        {
            
            SpawnEnemy(enemyPrefabToSpawn);
            // UnityEngine.Debug.Log("spawned enemy waveIndex = " + waveAmountToSpawn);
            
            yield return new WaitForSeconds(0.5f);
            
        }

        waveOverOne--;

        
        

        //      when npc spawn in groups
        // SpawnEnemy();
        // UnityEngine.Debug.Log("spawned enemy waveIndex = " + waveNumber);


        // yield return new WaitForSeconds(0.5f);
        // UnityEngine.Debug.Log("Hellow");
        
    }

    void SpawnEnemy(Transform enemy)
    {


        if(enemyPrefabOne!=null)
        {

            x = Random.Range(-0.4f, 0.4f);
            y = 0;
            z = Random.Range(-0.4f, 0.4f);
            randomVec = new Vector3(x, y, z);
            // UnityEngine.Debug.Log("spawned an enemy. time = " + Time.time + "   randomVec =  " + randomVec);
            Instantiate(enemy, spawnPointOne.position + randomVec, spawnPointOne.rotation);
        }

        //enemyPrefabTwo
        if(enemyPrefabTwo!=null)
        {
            x = Random.Range(-0.4f, 0.4f);
            y = 0;
            z = Random.Range(-0.4f, 0.4f);
            randomVec = new Vector3(x, y, z);
           Instantiate(enemyPrefabTwo, spawnPointOne.position + randomVec, spawnPointOne.rotation);

        }



    }
}
