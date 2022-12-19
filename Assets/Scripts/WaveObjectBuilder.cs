using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new WaveObject", menuName = "WaveObjectBuilder")]
public class WaveObjectBuilder : ScriptableObject
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
        UnityEngine.Debug.Log(" Hey i exist ! ");
    }
    public virtual void onEnemySpawn() { }
    public virtual void onWaveEnd() { }

}



// [CreateAssetMenu(fileName = "new WaveObjectBuilder", menuName = "WaveObjectBuilder")]
// public class WaveObjectBuilder : ScriptableObject
// {

//     public int amount;
//     public Transform enemyPrefab;
//     public Transform spawnPoint;
//     public int respawnTimes;
//     public float timeBetween;

//     public float countdown;
//     public int over;
// }