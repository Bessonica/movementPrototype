using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class WaveSpawner : MonoBehaviour
{

// возможность создавать насколько разных волн с разным маршрутом
//(?всьтавлять разные префабы врагов enemy1, enemy2 и тд)
//и у них будут разные маршруты


// we have ways as prefabs, and then we put them into
// enemy prefab.sso we need several enemyprefabs for different ways

// its really clunky and overall bad solution(difficult to edit)
// better way is to create enemy prefabs in EnemyGroup1
// and then put ways into this instances of prefab
// after this we take this prefabs and put them into game manager
// but this enemies in EnemyGroup1 shouldnt move or get destroid
// otherwis they will dissapear and code will break

// need to have several variables for several different waves
//  waveOne
//  wave Two
//  ...
    public Transform enemyPrefabOne;
    public Transform enemyPrefabTwo;

// its variables for different enemy assignment type
    public Waypoints testOne;
    public Waypoints testTwo;

    public Transform spawnPoint;

    public float timeBetweenWaves = 10f;
    private float countdown = 2f;

    private int waveNumber = 0;

    Vector3 randomVec;
    float x, y, z;

    



    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Debug.Log("started " + Time.time);

        x = Random.Range(-0.4f, 0.4f);
        y = 0;
        z = Random.Range(-0.4f, 0.4f);
        randomVec = new Vector3(x, y, z);

    }

    // Update is called once per frame
    private void Update()
    {
        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            
            
        }

        countdown -= UnityEngine.Time.deltaTime;
        // UnityEngine.Debug.Log("countdown = " + countdown);
        
    }

    IEnumerator SpawnWave()
    {
        waveNumber++;
        // UnityEngine.Debug.Log("wave spawned");

        //почему то после waveNumber=2 в волнах нпс спавнять через 1 секунду
        //а не 2, как должно быть  (WaitForSeconds(2.0f);)

        // !!! возможно нам не нужны корутины
        //  просто спавним каждого в полурандомной локации, кучкой
        for(int i=0; i<waveNumber; i++)
        {
            
            SpawnEnemy();
            UnityEngine.Debug.Log("spawned enemy waveIndex = " + waveNumber);
            yield return new WaitForSeconds(0.5f);
            
            //WaitForSecondsRealtime
        }
        

        //      when npc spawn in groups
        // SpawnEnemy();
        // UnityEngine.Debug.Log("spawned enemy waveIndex = " + waveNumber);


        // yield return new WaitForSeconds(0.5f);
        // UnityEngine.Debug.Log("Hellow");
        
    }

    void SpawnEnemy()
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
        UnityEngine.Debug.Log("spawned an enemy. time = " + Time.time);
        Instantiate(enemyPrefabOne, spawnPoint.position, spawnPoint.rotation);

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
