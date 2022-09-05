using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaiviour : MonoBehaviour
{
    public AudioSource doorSound;
    public GameObject gameMaster;
    WaveSpawner waveSpawner;
    public bool keepBashing = true;
    
    [Header("how long/strong door shakes")]
    public float countdownDoor = 0.065f;
    public float powerOfShake = 0.1f;

    [Header("how long wait between strikes at door !!!(Check code, its randomRnage)!!!")]
    public float randomTime;

    float countdownDoorNow;

    Vector3 startingPos;
    float speed = 1.0f; //how fast it shakes
    float amount = 1.0f; //how much it shakes

    float newX, newY, newZ;

    public bool stopBash;

    

    

    void Awake()
    {
      // startingPos.x = transform.position.x;
      // startingPos.y = transform.position.y;
    }

    // Start is called before the first frame update
    void Start()
    {
        waveSpawner = gameMaster.GetComponent<WaveSpawner>();
        stopBash = true;
    }

   
    void Update()
    {
        

    }

    public IEnumerator BashOnDoorHard(GameObject doorToShake)
    {

      while(true)
      {

        randomTime = UnityEngine.Random.Range(2f, 5f);

              

      //   animation of door 
        countdownDoorNow = countdownDoor;
        startingPos = doorToShake.transform.position;
        while(countdownDoorNow >= 0)
        {
          countdownDoorNow -= Time.deltaTime;

          newX = doorToShake.transform.position.x + UnityEngine.Random.Range(-0.9f, 0.9f) * powerOfShake;
          newZ = doorToShake.transform.position.z + UnityEngine.Random.Range(-0.9f, 0.9f) * powerOfShake;

          doorToShake.transform.position = new Vector3(newX, startingPos.y, newZ);
          yield return null; 
          doorToShake.transform.position = startingPos;
        }
        
        // doorSound.Play();
        AudioManager.instance.BashOnDoorHardSFX();
        yield return new WaitForSeconds(randomTime);
        


        
      }

    }


    //BashOnDoorHardHardestSFX


    public IEnumerator BashOnDoorHardest(GameObject doorToShake)
    {

      while(true)
      {

        randomTime = UnityEngine.Random.Range(1f, 2f);

              

      //   animation of door 
        countdownDoorNow = countdownDoor;
        startingPos = doorToShake.transform.position;
        while(countdownDoorNow >= 0)
        {
          countdownDoorNow -= Time.deltaTime;

          newX = doorToShake.transform.position.x + UnityEngine.Random.Range(-0.9f, 0.9f) * powerOfShake;
          newZ = doorToShake.transform.position.z + UnityEngine.Random.Range(-0.9f, 0.9f) * powerOfShake;

          doorToShake.transform.position = new Vector3(newX, startingPos.y, newZ);
          yield return null; 
          doorToShake.transform.position = startingPos;
        }
        
        // doorSound.Play();
        AudioManager.instance.BashOnDoorHardHardestSFX();
        yield return new WaitForSeconds(randomTime);
        


        
      }

    }



    public IEnumerator BashOnDoor(GameObject doorToShake)
    {

      // parametrs, can use them as parametrs that are put in function
        //countdownDoor  0.065f;
        //powerOfShake   0.1f;
        //randomTime


    // UnityEngine.Debug.Log("Door Bash time before = " + Time.time + " countdownDoor = " + countdownDoor);
      
    // i can repeat this one time to make it scripted(WaitForSeconds(3f);) and etc
        // or make another function for first wave

      while(true)
      {

        while(stopBash)
        {


        randomTime = UnityEngine.Random.Range(4f, 7f);

              

      //   animation of door 
        countdownDoorNow = countdownDoor;
        startingPos = doorToShake.transform.position;
        while(countdownDoorNow >= 0)
        {
          countdownDoorNow -= Time.deltaTime;

          newX = doorToShake.transform.position.x + UnityEngine.Random.Range(-0.5f, 0.5f) * powerOfShake;
          newZ = doorToShake.transform.position.z + UnityEngine.Random.Range(-0.7f, 0.7f) * powerOfShake;

          doorToShake.transform.position = new Vector3(newX, startingPos.y, newZ);
          yield return null; 
          doorToShake.transform.position = startingPos;
        }
        
        // doorSound.Play();
        AudioManager.instance.BashOnDoorSFX();
        yield return new WaitForSeconds(randomTime);

        }


      

        
      }
    
    }



    // public void BashOnTheDoor()
    // {
    //     // проигрываем анимацию удара
    //     // проигрываем звук удара
    //     UnityEngine.Debug.Log("BASHING ON DOOR");
    // }
}



