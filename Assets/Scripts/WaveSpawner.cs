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



// we have ways as prefabs, and then we put them into
// enemy prefab.sso we need several enemyprefabs for different ways

// its really clunky and overall bad solution(difficult to edit)
// better way is to create enemy prefabs in EnemyGroup1
// and then put ways into this instances of prefab
// after this we take this prefabs and put them into game manager
// but this enemies in EnemyGroup1 shouldnt move or get destroid
// otherwis they will dissapear and code will break


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

// its variables for different enemy assignment type/method
    // public Waypoints testOne;
    // public Waypoints testTwo;


    

    

    public float timeBetweenWaves = 10f;

    private float countdown = 2f; // wait time before first wave

    // private int waveNumber = 3;
    // private Transform enemy;

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
        UnityEngine.Debug.Log("started " + Time.time);

        x = Random.Range(-0.4f, 0.4f);
        y = 0;
        z = Random.Range(-0.4f, 0.4f);
        randomVec = new Vector3(x, y, z);

        waveOverOne = waveSpawnTimesOne;

    }

    // Update is called once per frame
    private void Update()
    {
        // how to manage spawn in specific time, or after some event?

        // wave1
        if(countdown <= 0f && waveOverOne > 0)
        {
            StartCoroutine(SpawnWave(enemyPrefabOne,waveAmountOne));
            countdown = timeBetweenOne;
            
            
        }

        countdown -= UnityEngine.Time.deltaTime;
        // UnityEngine.Debug.Log("countdown = " + countdown);
        
    }

    IEnumerator SpawnWave(Transform enemyPrefabToSpawn, int waveAmountToSpawn)
    {
        // waveNumber++;
        //waveAmountOne
        
        // UnityEngine.Debug.Log("wave spawned");

        //почему то после waveNumber=2 в волнах нпс спавнять через 1 секунду
        //а не 2, как должно быть  (WaitForSeconds(2.0f);)

        // !!! возможно нам не нужны корутины
        //  просто спавним каждого в полурандомной локации, кучкой

        for(int i=0; i<waveAmountToSpawn; i++)
        {
            
            SpawnEnemy(enemyPrefabToSpawn);
            UnityEngine.Debug.Log("spawned enemy waveIndex = " + waveAmountToSpawn);
            
            yield return new WaitForSeconds(0.5f);
            
            //WaitForSecondsRealtime
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

        // prefab: enemyEmptyPrefab
        // this method assigns param inside code, and i dont like it
        // to create new way now i would need assign new ways here every goddamn time
        // Transform test = Instantiate(enemyPrefabOne, spawnPoint.position, spawnPoint.rotation);
        // test.GetComponent<EnemyMovement>().WayOne = testOne;
        // test.GetComponent<EnemyMovement>().WayTwo = testTwo;

        // prefab: Enemy
        // all ways are prefabs and they were assigned to prefab itself
        // i dont like it as well becausse now i have to create new prefabs
        // and assign them every time
        // Instantiate(enemyPrefabOne, spawnPoint.position, spawnPoint.rotation);


        // i need solution where i give instance of prefab with assigned ways
        // in editor

        if(enemyPrefabOne!=null)
        {

            x = Random.Range(-0.4f, 0.4f);
            y = 0;
            z = Random.Range(-0.4f, 0.4f);
            randomVec = new Vector3(x, y, z);
            // UnityEngine.Debug.Log("spawned an enemy. time = " + Time.time + "   randomVec =  " + randomVec);
            Instantiate(enemy, spawnPointOne.position + randomVec, spawnPointOne.rotation);
        }
        //     x = Random.Range(-0.4f, 0.4f);
        //     y = 0;
        //     z = Random.Range(-0.4f, 0.4f);
        //     randomVec = new Vector3(x, y, z);
        // UnityEngine.Debug.Log("spawned an enemy. time = " + Time.time + "   randomVec =  " + randomVec);
        // Instantiate(enemyPrefabOne, spawnPointOne.position + randomVec, spawnPointOne.rotation);



        //enemyPrefabTwo
        if(enemyPrefabTwo!=null)
        {
            x = Random.Range(-0.4f, 0.4f);
            y = 0;
            z = Random.Range(-0.4f, 0.4f);
            randomVec = new Vector3(x, y, z);
           Instantiate(enemyPrefabTwo, spawnPointOne.position + randomVec, spawnPointOne.rotation);

        }
        // Instantiate(enemyPrefabTwo, spawnPointOne.position + randomVec, spawnPointOne.rotation);

        //      when npc spawn in groups
        // for(int i=0; i<waveNumber; i++)
        // {
        //     x = Random.Range(-0.4f, 0.4f);
        //     y = 0;
        //     z = Random.Range(-0.4f, 0.4f);
        //     randomVec = new Vector3(x, y, z);

        //     UnityEngine.Debug.Log("spawned an enemy. time = " + Time.time);
        //     Instantiate(enemyPrefabOne, spawnPoint.position + randomVec, spawnPoint.rotation);
            
        //     UnityEngine.Debug.Log("spawned enemy waveIndex = " + waveNumber);
        //     // yield return new WaitForSeconds(0.5f);
            
        //     //WaitForSecondsRealtime
        // }



    }
}
