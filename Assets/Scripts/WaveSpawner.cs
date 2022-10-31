using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO maybe delete
// phaseStringStart = "game..." PhaseStage.BeforeStart

// phaseStringZero = "0";       PhaseStage.FirstPartOne
// phaseStringFirst = "1";      PhaseStage.FirstPartTwo
// phaseStringSecond = "2";     PhaseStage.Second
// phaseStringThird = "3";      PhaseStage.Third
// phaseStringFourth = "4";     PhaseStage.Fourth
// phaseStringFinal = "final";  PhaseStage.Final


// inputs
//    prefabs of enemy for each wave(ways, speed etc)
//    ?amount of iterations for wave? how many times to spawn it
//    time between spawns

//достаточно двух волн, тпереь нужно понять как удобно менять их параметры по ходу игры
public class WaveSpawner : MonoBehaviour
{

    // by Mrill traidmark. all rights recieved, suck my cock faggot
    public enum PhaseStage
    {
        BeforeStart,
        FirstPartOne,
        FirstPartTwo,
        Second,
        Third,
        Fourth,
        Final
    }

    public bool isPhaseEnd = false;


    [Header("Duration of phases")]
    public float phaseZeroDuration;
    public float phaseOneDuration;
    public float phaseTwoDuration;
    public float phaseThreeDuration;
    public float phaseFourDuration;
    // we need it to know when to stop all npc and sounds and start ripping out door
    // turn of light etc
    public float phaseFinalDuration;
    // public float phaseEndDuration; // TODO delete

    float getDuration(PhaseStage stage)
    {
        switch (stage)
        {
            case PhaseStage.BeforeStart:
                return 0;
            case PhaseStage.FirstPartOne:
                return phaseZeroDuration;
            case PhaseStage.FirstPartTwo:
                return phaseOneDuration;
            case PhaseStage.Second:
                return phaseTwoDuration;
            case PhaseStage.Third:
                return phaseThreeDuration;
            case PhaseStage.Fourth:
                return phaseFourDuration;
            case PhaseStage.Final:
                return phaseFinalDuration;
            default:
                return 0;
        }
    }

    [Header("Enemy wave zero")]
    public Transform enemyPrefabZero;
    public Transform spawnPointZero;
    public int waveAmountZero; // how many npc in wave
    public int waveSpawnTimesZero; // how many times wave is spawned
    public float timeBetweenZero;
    public float countdownZero;  // how long wait before starting spawning waves
    int waveOverZero;





    // WaveConstructor waveZero = new WaveConstructor(enemyPrefabZero, waveAmountZero, waveSpawnTimesZero, timeBetweenZero, countdownZero, waveOverZero);


    [Header("Enemy wave one")]
    public Transform enemyPrefabOne;
    public Transform spawnPointOne;
    public int waveAmountOne; // how many npc in wave
    public int waveSpawnTimesOne; // how many times wave is spawned
    public float timeBetweenOne;
    public float countdownOne;
    int waveOverOne;

    // [Header("Enemy wave two")]
    // public Transform enemyPrefabTwo;
    // public Transform spawnPointTwo;

    [Header("Enemy wave one (phase2)")]
    public Transform enemyPrefabSecondOne;
    // public Transform spawnPointSecondOne;
    public int waveAmountSecondOne; // how many npc in wave
    public int waveSpawnTimesSecondOne; // how many times wave is spawned
    public float timeBetweenSecondOne;
    public float countdownSecondOne;
    int waveOverSecondOne;


    [Header("Enemy wave two (phase2)")]
    public Transform enemyPrefabSecondTwo;
    // public Transform spawnPointSecondTwo;
    public int waveAmountSecondTwo; // how many npc in wave
    public int waveSpawnTimesSecondTwo; // how many times wave is spawned
    public float timeBetweenSecondTwo;
    public float countdownSecondTwo;
    int waveOverSecondTwo;


    [Header("Enemy wave one (phase3)")]
    public Transform enemyPrefabThirdOne;
    // public Transform spawnPointThirdOne;
    public int waveAmountThirdOne; // how many npc in wave
    public int waveSpawnTimesThirdOne; // how many times wave is spawned
    public float timeBetweenThirdOne;
    public float countdownThirdOne;
    int waveOverThirdOne;

    [Header("Enemy wave two (phase3)")]
    public Transform enemyPrefabThirdTwo;
    // public Transform spawnPointThirdTwo;
    public int waveAmountThirdTwo; // how many npc in wave
    public int waveSpawnTimesThirdTwo; // how many times wave is spawned
    public float timeBetweenThirdTwo;
    public float countdownThirdTwo;
    int waveOverThirdTwo;


    [Header("Enemy wave one (phase4)")]
    public Transform enemyPrefabFourthOne;
    // public Transform spawnPointFourthOne;
    public int waveAmountFourthOne; // how many npc in wave
    public int waveSpawnTimesFourthOne; // how many times wave is spawned
    public float timeBetweenFourthOne;
    public float countdownFourthOne;
    int waveOverFourthOne;



    [Header("Enemy wave two (phase4)")]
    public Transform enemyPrefabFourthTwo;
    // public Transform spawnPointFourthTwo;
    public int waveAmountFourthTwo; // how many npc in wave
    public int waveSpawnTimesFourthTwo; // how many times wave is spawned
    public float timeBetweenFourthTwo;
    public float countdownFourthTwo;
    int waveOverFourthTwo;

    // final simple - first enemies that are spawned before final enemy is spawned
    // final enemy - enemy that trigers spawn of strong and fast final one/two enemies
    // final one/two - strong enemies that are spawned after final enemy screams
    [Header("final Simple enemy One")]
    public Transform enemyPrefabFinalSimpleOne;
    // public Transform spawnPointFinalSimpleOne;
    public int waveAmountFinalSimpleOne; // how many npc in wave
    public int waveSpawnTimesFinalSimpleOne; // how many times wave is spawned
    public float timeBetweenFinalSimpleOne;
    public float countdownFinalSimpleOne;  // how long wait before starting spawning waves
    int waveOverFinalSimpleOne;

    [Header("final Simple enemy Two")]
    public Transform enemyPrefabFinalSimpleTwo;
    // public Transform spawnPointFinalSimpleTwo;
    public int waveAmountFinalSimpleTwo; // how many npc in wave
    public int waveSpawnTimesFinalSimpleTwo; // how many times wave is spawned
    public float timeBetweenFinalSimpleTwo;
    public float countdownFinalSimpleTwo;  // how long wait before starting spawning waves
    int waveOverFinalSimpleTwo;


    [Header("final STRONG enemy One")]
    public Transform enemyPrefabFinalStrongOne;
    // public Transform spawnPointFinalStrongOne;
    public int waveAmountFinalStrongOne; // how many npc in wave
    public int waveSpawnTimesFinalStrongOne; // how many times wave is spawned
    public float timeBetweenFinalStrongOne;
    public float countdownFinalStrongOne;  // how long wait before starting spawning waves
    int waveOverFinalStrongOne;


    [Header("final STRONG enemy Two")]
    public Transform enemyPrefabFinalStrongTwo;
    // public Transform spawnPointFinalStrongTwo;
    public int waveAmountFinalStrongTwo; // how many npc in wave
    public int waveSpawnTimesFinalStrongTwo; // how many times wave is spawned
    public float timeBetweenFinalStrongTwo;
    public float countdownFinalStrongTwo;  // how long wait before starting spawning waves
    int waveOverFinalStrongTwo;


    [Header("final enemy")]
    public Transform enemyPrefabFinal;
    // public Transform spawnPointFinal;
    public int waveAmountFinal; // how many npc in wave
    public int waveSpawnTimesFinal; // how many times wave is spawned
    public float timeBetweenFinal;
    public float countdownFinal;  // how long wait before starting spawning waves
    // public float countdownFinalToSpawn = 10f; // when to spawn final enemy
    int waveOverFinal;

    bool TimeToSpawnStrongEnemies;


    // for enemy you need (dont forget)
    // set waveOver in start
    // in spawn wave -- waveOver



    [Header("DO NOT TOUCH (courutine that i stop in another code (EnemyMovement.cs))")]
    public Coroutine bashOnDoorHard;
    // [Header("Final Enemy (need to)")]
    // public GameObject finalEnemyObject;

    // this strings are responsible for choosing what phase is right now
    // in (interactable.cs) we reassign phaseString and it changes here
    [Header("phase strings")]
    public PhaseStage currStage;


    // private float countdown = 2f; // wait time before first wave
    // private float countdownOne = 2f;



    Vector3 randomVec;
    float x, y, z;

    PlayerStats playerStats;
    BuildManager buildManager;

    public bool phaseIsOn; //rename to isPhaseOn | rethink

    [Header("Lever and PC interactable objects")]
    public GameObject PC;
    public GameObject Lever;

    [Header("Door")]
    public GameObject DoorObject;
    MeshRenderer DoorObjectRenderer;
    DoorBehaiviour door;
    public GameObject realDoor;
    public GameObject boxCollider;
    BoxCollide boxCollideObject;

    [Header("Box Coliders for final phase")]
    public GameObject FlickerCollider;
    FlickerCollide FlickerCollideObject;
    public GameObject DeathCollider;
    DeathCollide DeathCollideObject;
    public GameObject DeathColliderSecond;
    DeathCollide DeathCollideObjectSecond;
    public GameObject DeathColliderThird;
    DeathCollide DeathCollideObjectThird;

    [Header("Box Coliders for final phase if player exists early")]
    public GameObject DeathColliderSecondEARLY;
    EarlyDeathCollide DeathCollideObjectSecondEARLY;
    public GameObject DeathColliderThirdEARLY;
    EarlyDeathCollide DeathCollideObjectThirdEARLY;


    public GameObject SignalSentObject;

    Interactable pcInteractable, leverInteractable;


    float phaseStartTime;

    // WaveBuilder waveZero = new WaveBuilder();

    void Start()
    {
        // UnityEngine.Debug.Log("started " + Time.time);
        // playerStats.ChangeLeverTime(6.35f);

        //Waves initiaiton
        WaveBuilder waveZero = new WaveBuilder(
            enemyPrefab: enemyPrefabZero,
            amount: waveAmountZero,
            spawnPoint: spawnPointZero,
            respawnTimes: waveSpawnTimesZero,
            timeBetween: timeBetweenZero,
            countdown: countdownZero,
            over: waveOverZero
        );

        // waveZero.amount = 5;


        WaveBuilder waveOne = new WaveBuilder(
            enemyPrefab: enemyPrefabOne,
            amount: waveAmountOne,
            spawnPoint: spawnPointOne,
            respawnTimes: waveSpawnTimesOne,
            timeBetween: timeBetweenOne,
            countdown: countdownOne,
            over: waveOverOne
        );

        x = Random.Range(-0.4f, 0.4f);
        y = 0;
        z = Random.Range(-0.4f, 0.4f);
        randomVec = new Vector3(x, y, z);

        // check how many times to spawn wave

        waveOverZero = waveSpawnTimesZero;
        waveOverOne = waveSpawnTimesOne;

        waveOverSecondOne = waveSpawnTimesSecondOne;
        waveOverSecondTwo = waveSpawnTimesSecondTwo;

        waveOverThirdOne = waveSpawnTimesThirdOne;
        waveOverThirdTwo = waveSpawnTimesThirdTwo;

        waveOverFourthOne = waveSpawnTimesFourthOne;
        waveOverFourthTwo = waveSpawnTimesFourthTwo;

        waveOverFinal = waveSpawnTimesFinal;
        waveOverFinalSimpleOne = waveSpawnTimesFinalSimpleOne;
        waveOverFinalSimpleTwo = waveSpawnTimesFinalSimpleTwo;

        waveOverFinalStrongOne = waveSpawnTimesFinalStrongOne;
        waveOverFinalStrongTwo = waveSpawnTimesFinalStrongTwo;

        // by MrILL
        // isPhaseEnd = false; // may be removed, 'cause declared false as default


        phaseIsOn = false;
        playerStats = this.GetComponent<PlayerStats>();
        buildManager = this.GetComponent<BuildManager>();

        pcInteractable = PC.GetComponent<Interactable>();
        leverInteractable = Lever.GetComponent<Interactable>();

        door = DoorObject.GetComponent<DoorBehaiviour>();
        boxCollideObject = boxCollider.GetComponent<BoxCollide>();


        FlickerCollideObject = FlickerCollider.GetComponent<FlickerCollide>();
        DeathCollideObject = DeathCollider.GetComponent<DeathCollide>();

        DeathCollideObjectSecond = DeathColliderSecond.GetComponent<DeathCollide>();
        DeathCollideObjectThird = DeathColliderThird.GetComponent<DeathCollide>();

        DeathCollideObjectSecondEARLY = DeathColliderSecondEARLY.GetComponent<EarlyDeathCollide>();
        DeathCollideObjectThirdEARLY = DeathColliderThirdEARLY.GetComponent<EarlyDeathCollide>();


        TimeToSpawnStrongEnemies = false;
    }



    // it works only when no new enemies are spawned
    public void StopAllEnemies()
    {
        // stop spawning new enemies
        phaseIsOn = false;

        foreach (GameObject enemyToStop in GameObject.FindGameObjectsWithTag("Enemy"))
        {

            EnemyMovement elementToStop = enemyToStop.GetComponent<EnemyMovement>();
            elementToStop.stopNow = true;

        }
        // UnityEngine.Debug.Log("Enemies numbers = ");


        // take all enemies, change their stopNow to true
        // you can find them by their tag "Enemy"
        // wait some time
        // and then continue (stopNow = false)
    }

    public void StartAllEnemies()
    {
        // start spawning enemies
        phaseIsOn = true;

        foreach (GameObject enemyToStop in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            EnemyMovement elementToStop = enemyToStop.GetComponent<EnemyMovement>();
            elementToStop.stopNow = false;

        }

    }

    public void StartSpawnStrongEnemies()
    {
        TimeToSpawnStrongEnemies = true;
    }

    // playerStats.ChangeLeverTime(3f);
    // playerStats.ChangeTimerLimit(20f);
    // AudioManager.instance.SetDoorBashVolume(0.88f);

    // what we do when player pull the lever
    public void StartPhase()
    {
        // StopCourutine(door.BashOnDoor());
        phaseStartTime = Time.time;
        playerStats.startTimer = true;
        phaseIsOn = true;

        door.keepBashing = false;

        // playerStats = this.GetComponent<PlayerStats>();
        if (currStage != PhaseStage.BeforeStart)
        {
            PlayerStats.Money = 0;
        }

        // Money is static variable, so you can access it from everywhere?
        // read about public static



        AudioManager.instance.StartPCWorkingSFX();

        // if its first time we pulled lever
        switch (currStage)
        {
            case PhaseStage.BeforeStart:
                playerStats.ChangeTimerLimit(20f);

                // start phaseZero 
                UnityEngine.Debug.Log("STARTED FIRST PHASE PART ONE");

                //SignalSentObject
                SignalSentObject.SetActive(true);

                // StartCoroutine(door.BashOnDoor(DoorObject));

                //   sound
                //    dont forget about sound that pc beeps when wave is spawned
                AudioManager.instance.StartGeneratorSFX();
                AudioManager.instance.StartWaveDetectedSFX(5f);
                AudioManager.instance.StartWaveDetectedSFX(8f);


                // LampManager.instance.ChangeColorRedAllLamps();

                currStage = PhaseStage.FirstPartOne;
                break;
            case PhaseStage.FirstPartOne:
                // start phase
                UnityEngine.Debug.Log("STARTED FIRST PHASE PART TWO");

                // no sound changed

                currStage = PhaseStage.FirstPartTwo;
                break;
            case PhaseStage.FirstPartTwo:
                // start phase
                UnityEngine.Debug.Log("STARTED SECOND PHASE ");

                SignalSentObject.SetActive(false);

                playerStats.ChangeTimerLimit(12f);


                AudioManager.instance.StartWaveDetectedSFX(2f);
                AudioManager.instance.StartGeneratorSFX();

                // no sound changed

                currStage = PhaseStage.Second;
                break;
            case PhaseStage.Second:
                // start phase
                UnityEngine.Debug.Log("STARTED THIRD PHASE ");

                playerStats.ChangeTimerLimit(11f);

                AudioManager.instance.StartGeneratorSFX();

                // StartCoroutine(door.BashOnDoor(DoorObject));

                // start checking  to start bashOnDoor when player near
                boxCollideObject.StartChecking = true;

                // sound

                AudioManager.instance.StartWaveDetectedSFX(7.5f);
                AudioManager.instance.StartWaveDetectedSFX(10f);
                AudioManager.instance.StartGeneratorSFX();

                currStage = PhaseStage.Third;
                break;
            case PhaseStage.Third:
                //во время фазы/волны к двери слышно вссе больше и больше ударов
                // то есть запускаем корутину и в завивисмости от длинны волны(phaseThreeDuration)
                // и через определенное время меняем звуковой еффект на новый

                // start phase
                UnityEngine.Debug.Log("STARTED FOURTH PHASE ");

                playerStats.ChangeTimerLimit(9f);
                // phaseString = phaseStringFinal;
                // phaseDeadLine = phaseFinalDuration;
                // UnityEngine.Debug.Log("STARTED FINAL PHASE ");


                // sound
                AudioManager.instance.StartWaveDetectedSFX(1f);
                AudioManager.instance.StartGeneratorSFX();

                currStage = PhaseStage.Fourth;
                break;
            case PhaseStage.Fourth:
                // start phase
                UnityEngine.Debug.Log("STARTED FINAL PHASE ");
                playerStats.ChangeTimerLimit(7.5f);

                //  THIS IS FOR TEST, in end phase we also have stop Courutine
                // StopCoroutine(boxCollideObject.doorBashroutine);
                // bashOnDoorHard = StartCoroutine(door.BashOnDoorHard(DoorObject));

                // sound

                AudioManager.instance.StartGeneratorSFX();

                currStage = PhaseStage.Final;
                break;
            case PhaseStage.Final:
                // turn off earlyDeath colliders
                DeathCollideObjectSecondEARLY.StartChecking = false;
                DeathCollideObjectThirdEARLY.StartChecking = false;



                // for flickering lamp and lamp pop
                FlickerCollideObject.StartChecking = true;
                // this is where we turn off light and "kill player"
                DeathCollideObject.startChecking = true;
                DeathCollideObjectSecond.startChecking = true;
                DeathCollideObjectThird.startChecking = true;

                // when player started generator turn off early death
                DeathCollideObjectSecondEARLY.StartChecking = false;
                DeathCollideObjectThirdEARLY.StartChecking = false;


                // play some beeping sounds, with delay?
                AudioManager.instance.StartWaveDetectedSFX(4f);
                AudioManager.instance.StartGeneratorSFX();

                isPhaseEnd = true;
                break;
            default:
                break;
        }

        //when we started phase player cant use lever
        leverInteractable.isLeverOn = false;

        LampManager.instance.ChangeColorNormalAllLamps();
        LampManager.instance.StartAllLamps();
    }



    // what we do when phase time ends
    public void StopPhase()
    {
        if (currStage != PhaseStage.FirstPartOne)
        {
            // UnityEngine.Debug.Log("added more money ");

            phaseIsOn = false;
            playerStats.startTimer = false;
            PlayerStats.Money = 0;

            AudioManager.instance.GeneratorOffSFX();
            AudioManager.instance.StopPCWorkingSFX();

            pcInteractable.turnOffPC();
            buildManager.DestroyAllTurrets();


            if (currStage != PhaseStage.Final)
            {
                LampManager.instance.ChangeColorRedAllLamps();
            }
            else
            {
                LampManager.instance.StopAllLamps();
            }
        }

        // when phase is stoped player can use lever to turn it on again
        if (currStage != PhaseStage.FirstPartOne) //TODO move into upper if
        {
            leverInteractable.isLeverOn = true;
        }


        //create object monsterSound behind door and activate it here
        // решаем какие звуки ставить, когда выключается свет
        if (currStage == PhaseStage.FirstPartOne) //TODO rewrite to switch
        {
            UnityEngine.Debug.Log("PHASE FIRST PART ONE ENDED ");
            StartPhase();


        }
        else if (currStage == PhaseStage.FirstPartTwo)
        {
            //слышно шум задверью, но ее никто не трогает
            UnityEngine.Debug.Log("PHASE FIRST PART TWO ENDED ");

            playerStats.ChangeLeverTime(4.5f);

            //   sound
            AudioManager.instance.StopGeneratorSFX();

            AudioManager.instance.StartBehindDoorSFX();
            AudioManager.instance.StartGiantMonsterSFX();
            // AudioManager.instance.GeneratorOffSFX();


        }
        else if (currStage == PhaseStage.Second)
        {
            //шум за дверью громче и агрессивнее
            UnityEngine.Debug.Log("PHASE TWO ENDED ");
            playerStats.ChangeLeverTime(7f);

            AudioManager.instance.StopGeneratorSFX();
            AudioManager.instance.StopBehindDoorSFX();
            // AudioManager.instance.StopGiantMonsterSFX();

            // make sound behind door louder
            AudioManager.instance.StartBehindDoorAggressiveSFX();
            // AudioManager.instance.StartGiantMonsterAggressiveSFX();


        }
        else if (currStage == PhaseStage.Third)
        {

            UnityEngine.Debug.Log("PHASE THREE ENDED ");
            playerStats.ChangeLeverTime(13f);
            AudioManager.instance.StopGeneratorSFX();

            StopCoroutine(boxCollideObject.doorBashroutine);
            bashOnDoorHard = StartCoroutine(door.BashOnDoorHard(DoorObject));
        }
        else if (currStage == PhaseStage.Fourth)
        {
            playerStats.ChangeLeverTime(6.5f);
            UnityEngine.Debug.Log("PHASE FOUR ENDED ");
            AudioManager.instance.StopGeneratorSFX();
            AudioManager.instance.StopGiantMonsterSFX();
        }
        // else if (phaseStringTmp == phaseStringFinal) // TODO remove
        else if (currStage == PhaseStage.Final)
        {

            UnityEngine.Debug.Log("PHASE FINAL ENDED ");
            playerStats.ChangeLeverTime(8.8f);

            // make step volume a little louder
            // AudioManager.instance.SetStepVolume();

            // turn off light 
            // play sound of tiring metal
            LampManager.instance.StopAllLamps();
            AudioManager.instance.StopGeneratorSFX();
            AudioManager.instance.StopBehindDoorAggressiveSFX();
            AudioManager.instance.StopAfterFinalRoarSFX();
            AudioManager.instance.DoorTearSFX();


            // when phase ended player can die if he exits the door
            DeathCollideObjectSecondEARLY.StartChecking = true;
            DeathCollideObjectThirdEARLY.StartChecking = true;


            // StopCoroutine(bashOnDoorHard);

            // turn off all light
            // "destroy" door
            DoorObjectRenderer = DoorObject.GetComponent<MeshRenderer>();
            DoorObjectRenderer.enabled = false;
            realDoor.SetActive(false);

            // start and stop sounds 

            // there is also code in StartPhase in final part
        }
    }



    // Update is called once per frame
    private void Update()
    {


        if (!phaseIsOn)
        {
            return;
        }


        //  check if phase time has ended
        float phaseDuration = Time.time - phaseStartTime;
        // && phaseString != phaseStringFinal
        // if (phaseDuration >= getDuration(currStage) && phaseStringTmp != phaseStringFinalEnd)
        if (phaseDuration >= getDuration(currStage) && !isPhaseEnd)
        {
            // UnityEngine.Debug.Log("phaseTime - phaseStartTime = " + (phaseTime - phaseStartTime ));
            // UnityEngine.Debug.Log("phase has ended phasezeroDuration = " + phaseDeadLine );
            StopPhase();
        }



        if (currStage == PhaseStage.FirstPartOne)
        {
            // UnityEngine.Debug.Log("countdown = " + waveZero);

            if (countdownZero <= 0f && waveOverZero > 0)
            {
                StartCoroutine(SpawnWave(enemyPrefabZero, waveAmountZero, 1));
                countdownZero = timeBetweenOne;
            }

            countdownZero -= UnityEngine.Time.deltaTime;
            // UnityEngine.Debug.Log("countdown = " + countdown);



        }
        else if (currStage == PhaseStage.FirstPartTwo)
        {
            // wave1
            if (countdownOne <= 0f && waveOverOne > 0)
            {
                StartCoroutine(SpawnWave(enemyPrefabOne, waveAmountOne, 1));
                countdownOne = timeBetweenOne;
            }

            countdownOne -= UnityEngine.Time.deltaTime;
            // UnityEngine.Debug.Log("countdown = " + countdown);

        }
        else if (currStage == PhaseStage.Second)
        {

            if (countdownSecondOne <= 0f && waveOverSecondOne > 0)
            {
                StartCoroutine(SpawnWave(enemyPrefabSecondOne, waveAmountSecondOne, 10));
                countdownSecondOne = timeBetweenSecondOne;
            }

            countdownSecondOne -= UnityEngine.Time.deltaTime;


            if (countdownSecondTwo <= 0f && waveOverSecondTwo > 0)
            {
                StartCoroutine(SpawnWave(enemyPrefabSecondTwo, waveAmountSecondTwo, 11));
                countdownSecondTwo = timeBetweenSecondTwo;
            }

            countdownSecondTwo -= UnityEngine.Time.deltaTime;
        }
        else if (currStage == PhaseStage.Third)
        {
            if (countdownThirdOne <= 0f && waveOverThirdOne > 0)
            {
                StartCoroutine(SpawnWave(enemyPrefabThirdOne, waveAmountThirdOne, 12));
                countdownThirdOne = timeBetweenThirdOne;
            }

            countdownThirdOne -= UnityEngine.Time.deltaTime;


            if (countdownThirdTwo <= 0f && waveOverThirdTwo > 0)
            {
                StartCoroutine(SpawnWave(enemyPrefabThirdTwo, waveAmountThirdTwo, 13));
                countdownThirdTwo = timeBetweenThirdTwo;
            }

            countdownThirdTwo -= UnityEngine.Time.deltaTime;
        }
        else if (currStage == PhaseStage.Fourth)
        {
            // !!! I MISTAKEN FOURTH WITH FINAL FUCK, need to test it out

            // in fourth wave we spawn the last final enemy, that stands in one place
            // we have bool isFinal for that in enemy
            // after some strong waves he appears, and after a little time it spawns massive wave

            if (countdownFourthOne <= 0f && waveOverFourthOne > 0)
            {
                StartCoroutine(SpawnWave(enemyPrefabFourthOne, waveAmountFourthOne, 14));
                countdownFourthOne = timeBetweenFourthOne;
            }

            countdownFourthOne -= UnityEngine.Time.deltaTime;

            if (countdownFourthTwo <= 0f && waveOverFourthTwo > 0)
            {
                StartCoroutine(SpawnWave(enemyPrefabFourthTwo, waveAmountFourthTwo, 15));
                countdownFourthTwo = timeBetweenFourthTwo;
            }

            countdownFourthTwo -= UnityEngine.Time.deltaTime;
        }
        else if (currStage == PhaseStage.Final)
        {
            //countdownFinal

            // scenario:
            // spawn enemy same as last wave
            // after some time spawn final enemy, wait a little
            // play his sound, make all enemy on level stop, after small pause
            // make all of them faster and spawn even more enemies


            // spawne simple enemies
            if (countdownFinalSimpleOne <= 0f && waveOverFinalSimpleOne > 0)
            {
                StartCoroutine(SpawnWave(enemyPrefabFinalSimpleOne, waveAmountFinalSimpleOne, 6));
                countdownFinalSimpleOne = timeBetweenFinalSimpleOne;
            }

            countdownFinalSimpleOne -= UnityEngine.Time.deltaTime;


            if (countdownFinalSimpleTwo <= 0f && waveOverFinalSimpleTwo > 0)
            {
                StartCoroutine(SpawnWave(enemyPrefabFinalSimpleTwo, waveAmountFinalSimpleTwo, 7));
                countdownFinalSimpleTwo = timeBetweenFinalSimpleTwo;
            }

            countdownFinalSimpleTwo -= UnityEngine.Time.deltaTime;

            // spawn final enemy
            // start timer, when it reaches the end. spawn final enemy
            // after they reach end and wait for some time + sound spawn strong enemies

            if (countdownFinal <= 0f && waveOverFinal > 0)
            {
                StartCoroutine(SpawnWave(enemyPrefabFinal, waveAmountFinal, 5));
                countdownFinal = timeBetweenFinal;
                // RoarAndSpawnStrongEnemies function in EnemyMovement.cs
            }

            countdownFinal -= UnityEngine.Time.deltaTime;



            //spawn final one/two enemy (strong ones)
            //TimeToSpawnStrongEnemies
            if (TimeToSpawnStrongEnemies)
            {
                if (countdownFinalStrongOne <= 0f && waveOverFinalStrongOne > 0)
                {
                    StartCoroutine(SpawnWave(enemyPrefabFinalStrongOne, waveAmountFinalStrongOne, 8));
                    countdownFinalStrongOne = timeBetweenFinalStrongOne;
                }

                countdownFinalStrongOne -= UnityEngine.Time.deltaTime;


                if (countdownFinalStrongTwo <= 0f && waveOverFinalStrongTwo > 0)
                {
                    StartCoroutine(SpawnWave(enemyPrefabFinalStrongTwo, waveAmountFinalStrongTwo, 9));
                    countdownFinalStrongTwo = timeBetweenFinalStrongTwo;
                }

                countdownFinalStrongTwo -= UnityEngine.Time.deltaTime;
            }
        }
    }



    // waveNumber - choose what wave to spawn
    IEnumerator SpawnWave(Transform enemyPrefabToSpawn, int waveAmountToSpawn, int waveNumber)
    {

        // this section is for stoping all processes, when we need
        if (!phaseIsOn)
        {
            yield return null;
        }


        for (int i = 0; i < waveAmountToSpawn; i++)
        {

            SpawnEnemy(enemyPrefabToSpawn, waveNumber);
            // UnityEngine.Debug.Log("spawned enemy waveIndex = " + waveAmountToSpawn);

            yield return new WaitForSeconds(0.5f);

        }

        //  check how many times we spawned wave
        // it works only when you have one wave to spawn
        //TODO move to switch-case
        if (currStage == PhaseStage.FirstPartOne)
        {
            waveOverZero--;

        }
        else if (currStage == PhaseStage.FirstPartTwo)
        {
            waveOverOne--;

        }
        else if (currStage == PhaseStage.Second && waveNumber == 10)
        {
            waveOverSecondOne--;

        }
        else if (currStage == PhaseStage.Second && waveNumber == 11)
        {
            waveOverSecondTwo--;

        }
        else if (currStage == PhaseStage.Third && waveNumber == 12)
        {
            waveOverThirdOne--;

        }
        else if (currStage == PhaseStage.Third && waveNumber == 13)
        {
            waveOverThirdTwo--;

        }
        else if (currStage == PhaseStage.Fourth && waveNumber == 14)
        {
            waveOverFourthOne--;

        }
        else if (currStage == PhaseStage.Fourth && waveNumber == 15)
        {
            waveOverFourthTwo--;

        }
        else if (currStage == PhaseStage.Final && waveNumber == 5)
        {
            waveOverFinal--;
        }
        else if (currStage == PhaseStage.Final && waveNumber == 6)
        {
            waveOverFinalSimpleOne--;
        }
        else if (currStage == PhaseStage.Final && waveNumber == 7)
        {
            waveOverFinalSimpleTwo--;
        }
        else if (currStage == PhaseStage.Final && waveNumber == 8)
        {
            waveOverFinalStrongOne--;
        }
        else if (currStage == PhaseStage.Final && waveNumber == 9)
        {
            waveOverFinalStrongTwo--;
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

        // this section is for stoping all processes, when we need
        if (!phaseIsOn)
        {
            return;
        }
        // if it is final enemy spawn him in exact position
        if (waveNumber == 5)
        {


            x = 0;
            y = 0;
            z = 0;
            randomVec = new Vector3(x, y, z);
            // UnityEngine.Debug.Log("spawned an enemy. time = " + Time.time + "   randomVec =  " + randomVec);
            Instantiate(enemy, spawnPointOne.position + randomVec, spawnPointOne.rotation);


        }
        else
        {
            x = Random.Range(-0.4f, 0.4f);
            y = 0;
            z = Random.Range(-0.4f, 0.4f);
            randomVec = new Vector3(x, y, z);
            // UnityEngine.Debug.Log("spawned an enemy. time = " + Time.time + "   randomVec =  " + randomVec);
            Instantiate(enemy, spawnPointOne.position + randomVec, spawnPointOne.rotation);
        }


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
