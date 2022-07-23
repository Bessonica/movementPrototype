using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    public AudioSource playerSource;
    public AudioSource doorSource;
    public AudioSource behindTheDoorSource;
    public AudioSource generatorOffSource;
    public AudioSource PCSource;
    public AudioSource GeneratorSource;
    public AudioSource LeverSource;

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

    public void StepOnFloorSFX()
    {
        playerSource.Play();
    }

    public void BashOnDoorSFX()
    {
        doorSource.Play();

    }

    public void LeverSFX()
    {
        LeverSource.Play();

    }

    public void LeverStopSFX()
    {
        LeverSource.Stop();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
