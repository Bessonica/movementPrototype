using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;




[System.Serializable]
public class WaveBuilder
{
    public int amount;
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public int respawnTimes;
    public float timeBetween;

    public float countdown;
    public int over;

    public WaveBuilder(
        int amount = 0,
        Transform enemyPrefab = null,
        Transform spawnPoint = null,
        int respawnTimes = 0,
        float timeBetween = 0,
        float countdown = 0,
        int over = 0
    )
    {
        this.amount = amount;
        this.enemyPrefab = enemyPrefab;
        this.spawnPoint = spawnPoint;
        this.respawnTimes = respawnTimes;
        this.timeBetween = timeBetween;
        this.countdown = countdown;
        this.over = over;
    }

}

[System.Serializable]
public abstract class WaveBuilderBasic : MonoBehaviour
{
    public int amount;
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public int respawnTimes;
    public float timeBetween;

    public float countdown;
    public int over;

    public virtual void onStartPhase() { }
    public virtual void onStopPhase() { }
    public virtual void onUpdate() { }
    public virtual void onEnemySpawn() { }
    public virtual void onWaveEnd() { }
}

public class WaveOneBuilder : WaveBuilderBasic
{
    public override void onStartPhase()
    {

        //TODO custom logic on wave 1
    }
    public override void onStopPhase()
    {
        //TODO custom logic on wave 1
    }
    public override void onUpdate()
    {
        //TODO custom logic on wave 1
    }
    public override void onEnemySpawn()
    {
        //TODO custom logic on wave 1
    }
    // public override void onWaveEnd(Contex ctx) {
    //     ctx.currStage = Stage::Two;
    // }
}

public class WaveTwoBuilder : WaveBuilderBasic
{
    public override void onStartPhase()
    {
        //TODO custom logic on wave 2
    }
    public override void onStopPhase()
    {
        //TODO custom logic on wave 2
    }
    public override void onUpdate()
    {
        //TODO custom logic on wave 2
    }
    public override void onEnemySpawn()
    {
        //TODO custom logic on wave 2
    }
}



// [Header("Enemy wave one (phase2)")]
// public Transform enemyPrefabSecondOne;
// // public Transform spawnPointSecondOne;
// public int waveAmountSecondOne; // how many npc in wave
// public int waveSpawnTimesSecondOne; // how many times wave is spawned
// public float timeBetweenSecondOne;
// public float countdownSecondOne;
// int waveOverSecondOne;


// [Header("Enemy wave two (phase2)")]
// public Transform enemyPrefabSecondTwo;
// // public Transform spawnPointSecondTwo;
// public int waveAmountSecondTwo; // how many npc in wave
// public int waveSpawnTimesSecondTwo; // how many times wave is spawned
// public float timeBetweenSecondTwo;
// public float countdownSecondTwo;
// int waveOverSecondTwo;







// [Header("Enemy wave one")]
// public Transform enemyPrefabOne;
// public Transform spawnPointOne;
// public int waveAmountOne; // how many npc in wave
// public int waveSpawnTimesOne; // how many times wave is spawned
// public float timeBetweenOne;
// public float countdownOne;
// int waveOverOne;





// public Transform enemyPrefabZero;
// // public Transform spawnPointZero;
// public int waveAmountZero; // how many npc in wave
// public int waveSpawnTimesZero; // how many times wave is spawned
// public float timeBetweenZero;
// public float countdownZero;  // how long wait before starting spawning waves
// int waveOverZero;



// public struct WaveConstructor
// {

//     public Transform Prefab { get; set; }
//     public Transform SpawnPoint { get; set; }
//     public int WaveAmount { get; set; }
//     public int SpawnTimes { get; set; }
//     public float TimeBetween { get; set; }
//     public float countdown { get; set; }
//     public int WaveOver { get; set; }

//     public WaveConstructor(Transform prefab, Transform spawnPoint, int waveAmount, int spawnTimes, float timeBetween, float countdown, int waveOver)
//     {
//         this.Prefab = prefab;
//         this.SpawnPoint = spawnPoint;
//         this.WaveAmount = waveAmount;
//         this.SpawnTimes = spawnTimes;
//         this.TimeBetween = timeBetween;
//         this.countdown = countdown;
//         this.WaveOver = waveOver;
//     }

// }
