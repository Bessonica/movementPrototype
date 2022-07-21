using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaiviour : MonoBehaviour
{
    public AudioSource doorSound;
    public GameObject gameMaster;
    WaveSpawner waveSpawner;
    public bool keepBashing = true;

    float countdownDoor = 4f;

    Vector3 startingPos;
    float speed = 1.0f; //how fast it shakes
    float amount = 1.0f; //how much it shakes

    float newX, newY, newZ;
    

    void Awake()
    {
      // startingPos.x = transform.position.x;
      // startingPos.y = transform.position.y;
    }

    // Start is called before the first frame update
    void Start()
    {
        waveSpawner = gameMaster.GetComponent<WaveSpawner>();
        
    }

   
    void Update()
    {
        

    }

// half random activation?
  // courutine?

  public IEnumerator BashOnDoor(GameObject doorToShake)
  {
    UnityEngine.Debug.Log("Door Bash time before = " + Time.time + " countdownDoor = " + countdownDoor);
    UnityEngine.Debug.Log("DoorPosition = " + doorToShake.transform.position );
    startingPos.x = doorToShake.transform.position.x;
    startingPos.y = doorToShake.transform.position.y;
    startingPos.z = doorToShake.transform.position.z;
    while(countdownDoor >= 0)
    {
      countdownDoor -= Time.deltaTime;

      // doorToShake.transform.position.x = startingPos.x + (Mathf.Sin(Time.time * speed) * amount) ;

      // doorToShake.transform.position.y = startingPos.y + (Mathf.Sin(Time.time * speed) * amount) ;

//startingPos.x + (Mathf.Sin(Time.time * speed) * amount), startingPos.y + (Mathf.Sin(Time.time * speed) * amount), doorToShake.transform.position.z
      newX =  startingPos.x + (Mathf.Sin(Time.time * speed) * amount);
      newY =  startingPos.y + (Mathf.Sin(Time.time * speed) * amount);
      newZ =  startingPos.z + (Mathf.Sin(Time.time * speed) * amount);
      doorToShake.transform.position = new Vector3(newX, newY, newZ);


      yield return null; 
    }
    
    UnityEngine.Debug.Log("Door Bash time after = " + Time.time + " countdownDoor = " + countdownDoor);

      yield return new WaitForSeconds(2f);
      
      doorSound.Play();

      yield return new WaitForSeconds(3f);

      doorSound.Play();

      yield return new WaitForSeconds(1f);
  


   
  }
    // public void BashOnTheDoor()
    // {
    //     // проигрываем анимацию удара
    //     // проигрываем звук удара
    //     UnityEngine.Debug.Log("BASHING ON DOOR");
    // }
}
