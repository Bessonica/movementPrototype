using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    public AudioSource playerSource;
    [Header("Door sounds")]
    public AudioSource doorSource;
    public AudioSource doorSourceHard;
    public AudioSource DoorTearSource;

    [Header("Behind the door sounds")]
    public AudioSource behindTheDoorSource;
    public AudioSource behindTheDoorSourceStronger;
    
    [Header("Turret sounds")]
    public AudioSource TurretSource;

    [Header("generatorOff sounds")]
    public AudioSource generatorOffSource;

    [Header("sounds after final phase")]
    public AudioSource FinalRoarSource;
    public AudioSource FinalLampPopSource;
    public AudioSource PlayerIsKilledSource;

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

// here we can create functions to change volume in mixer
// and then activate when we need it

    public void StepOnFloorSFX()
    {
        playerSource.Play();
    }


//turret sounds

    public void TurretShootSFX()
    {
        TurretSource.Play();

    }

    public void StopTurretShootSFX()
    {
        TurretSource.Stop();

    }

// door sounds

    public void DoorTearSFX()
    {
        DoorTearSource.Play();

    }

    public void BashOnDoorSFX()
    {
        doorSource.Play();

    }

    public void BashOnDoorHardSFX()
    {
        doorSourceHard.Play();

    }


    public void StopBashOnDoorHardSFX()
    {
        doorSourceHard.Stop();

    }




    public void FinalLampPopSFX()
    {
        FinalLampPopSource.Play();

    }

    public void StartThePlayerIsKilledSFX()
    {
        // ? Activate it from PopFinalLight ?
        
        // player hears hundreds of steps around him running at him
        // and maybe above
        //sound of claws, tearing meat, breaking bones etc

        PlayerIsKilledSource.Play();


    }


//pc

    public void StartPCWorkingSFX()
    {
        
        PCSource.Play();


    }

    public void StopPCWorkingSFX()
    {
        
        PCSource.Stop();


    }


// behind the door 
    public void StartBehindTheDoorSFX()
    {
        
        behindTheDoorSource.Play();


    }

    public void StopBehindTheDoorSFX()
    {
        
        behindTheDoorSource.Stop();


    }

    public void StartBehindTheDoorStrongerSFX()
    {
        
        behindTheDoorSourceStronger.Play();


    }

    public void StopBehindTheDoorStrongerSFX()
    {
        
        behindTheDoorSourceStronger.Stop();


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
        yield break;
        

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



    public void SoundFinalRoarSFX()
    {
        FinalRoarSource.Play();

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
