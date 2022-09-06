using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class FinalMonsterStepAtPlayer : MonoBehaviour
{

    public static FinalMonsterStepAtPlayer instance;

    [Header("Sound Sources Around Player")]
    public Transform SoundSource1;
    public Transform SoundSource2;
    public Transform SoundSource3;
    public Transform SoundSource4;

    public bool StartRunning;

    public Transform PlayerObject;

    public float Speed;

    public bool killPlayer;

   

    Vector3 dir1, dir2, dir3, dir4;

    float distance;

 

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        dir1 = new Vector3(20, 20, 20);
        StartRunning = false;
        killPlayer = false;
    }


    public void RunAtPlayer()
    {
        StartRunning = true;
        // StartCoroutine(RunAtPlayerCourutine(200f));

        AudioManager.instance.MonstersRunAtPlayerSFX();

    }

    // Update is called once per frame

    IEnumerator EndGame(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("MainMenu");
    }

    public void StartPlayerKilledSound()
    {
        if(killPlayer)
        { 
            return;
        }
        
        AudioManager.instance.StartPlayerIsKilledSFX();
        killPlayer = true;
        StartCoroutine(EndGame(29f));
    }
    void Update()
    {

        distance = Vector3.Distance(PlayerObject.position, SoundSource1.position);
        

        if(StartRunning && distance >2.45f)
        {
//Dir1 = (-1.2, 0.0, 2.1)
//Vector3.Distance(PlayerObject.position, dir1)
            dir1 = PlayerObject.position - SoundSource1.position;
            // UnityEngine.Debug.Log("Dir1 = " + Vector3.Distance(PlayerObject.position, SoundSource1.position));
            dir2 = PlayerObject.position - SoundSource2.position;
            dir3 = PlayerObject.position - SoundSource3.position;
            dir4 = PlayerObject.position - SoundSource4.position;

            SoundSource1.Translate(dir1.normalized * Speed * Time.deltaTime, Space.World);
            SoundSource2.Translate(dir2.normalized * Speed * Time.deltaTime, Space.World);
            SoundSource3.Translate(dir3.normalized * Speed * Time.deltaTime, Space.World);
            SoundSource4.Translate(dir4.normalized * Speed * Time.deltaTime, Space.World);

        }

        //StopMonstersRunAtPlayerSFX
        if(distance < 2.5f)
        {
            AudioManager.instance.StopMonstersRunAtPlayerSFX();
            StartPlayerKilledSound();
            

            
        }

        // if(killPlayer)
        // {
        //     AudioManager.instance.StartPlayerIsKilledSFX();
        //     killPlayer = false;
        // }


    }

    //  public IEnumerator RunAtPlayerCourutine(float time)
    //  {
        

    //     while(StartRunning)
    //     {

    //         dir1 = PlayerObject.position - SoundSource1.position;
    //         dir2 = PlayerObject.position - SoundSource2.position;
    //         dir3 = PlayerObject.position - SoundSource3.position;
    //         dir4 = PlayerObject.position - SoundSource4.position;

    //         SoundSource1.Translate(dir1.normalized * Speed * Time.deltaTime, Space.World);
    //         SoundSource2.Translate(dir2.normalized * Speed * Time.deltaTime, Space.World);
    //         SoundSource3.Translate(dir3.normalized * Speed * Time.deltaTime, Space.World);
    //         SoundSource4.Translate(dir4.normalized * Speed * Time.deltaTime, Space.World);

    //     }
       

    //  }



}
