using System.Collections;
using System.Collections.Generic;
using UnityEngine;




// [System.Serializable]
[CreateAssetMenu(fileName = "new WaveBuilderTest", menuName = "WaveBuilderTest")]
public abstract class WaveBuilderTest : ScriptableObject
// public abstract class WaveBuilderBasic : MonoBehaviour
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
    public virtual void onUpdate()
    {
        UnityEngine.Debug.Log(" Hey i m Test ");
    }
    public virtual void onEnemySpawn() { }
    public virtual void onWaveEnd() { }
}

//WaveBuilderTest



// //WaveOneBuilder / .....
// [CreateAssetMenu(fileName = "new WaveOneBuilderTest", menuName = "WaveOneBuilderTest")]
// public class WaveOneBuilderTest : WaveBuilderTest
// {
//     public override void onStartPhase()
//     {
//         // playerStats.ChangeTimerLimit(20f);

//         // // start phaseZero 
//         // UnityEngine.Debug.Log("STARTED FIRST PHASE PART ONE");

//         // //SignalSentObject
//         // SignalSentObject.SetActive(true);

//         // // StartCoroutine(door.BashOnDoor(DoorObject));

//         // //   sound
//         // //    dont forget about sound that pc beeps when wave is spawned
//         // AudioManager.instance.StartGeneratorSFX();
//         // AudioManager.instance.StartWaveDetectedSFX(5f);
//         // AudioManager.instance.StartWaveDetectedSFX(8f);


//         // LampManager.instance.ChangeColorRedAllLamps();

//         //TODO custom logic on wave 1
//     }
//     public override void onStopPhase()
//     {
//         //TODO custom logic on wave 1
//     }
//     public override void onUpdate()
//     {
//         //TODO custom logic on wave 1
//         UnityEngine.Debug.Log(" Hey i m test One ! ");
//     }
//     public override void onEnemySpawn()
//     {
//         //TODO custom logic on wave 1
//     }
//     // public override void onWaveEnd(Contex ctx) {
//     //     ctx.currStage = Stage::Two;
//     // }
// }