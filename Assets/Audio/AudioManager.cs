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

    [Header("PC sounds")]
    public AudioSource PCSource;
    public AudioSource PCWaveDetectedSource;

    [Header("'corridor' sounds")]
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

// pc sounds
    public void StartWaveDetectedSFX(float countdown)
    {
        
        StartCoroutine(StartWaveDetectedSFXwithTimer(countdown));


    }

    IEnumerator StartWaveDetectedSFXwithTimer(float countdown)
    {
        yield return new WaitForSeconds(countdown);
        PCWaveDetectedSource.Play();
        

    }

    public void StopWaveDetectedSFX()
    {
        PCWaveDetectedSource.Stop();


    }


//  generator sounds
    public void StartGeneratorSFX()
    {
        GeneratorSource.Play();


    }

    public void StopGeneratorSFX()
    {
        GeneratorSource.Stop();

    }

    public void GeneratorOffSFX()
    {
        generatorOffSource.Play();
    }

//  behind the door sound
    public void SoundBehindTheDoorOneSFX()
    {

    }

    public void SoundBehindTheDoorTwoSFX()
    {

    }

    public void SoundBehindTheDoorThreeSFX()
    {

    }

//  lever sounds
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
