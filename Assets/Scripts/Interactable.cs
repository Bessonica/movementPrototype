using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public UnityEvent onInteract;
    public Sprite interactIcon;
    public int ID;
    public bool isLever;

    [Header("size of Icons")]
    public Vector2 iconSize;


    [Header("gameMaster")]
    public GameObject gameMaster;
    WaveSpawner waveSpawner;
  
    // Start is called before the first frame update
    void Start()
    {
        ID = Random.Range(0, 99999);

    }

    public void StartWave(GameObject gameMaster)
    {
        // UnityEngine.Debug.Log("WAVE is SPAWNED" + gameMaster);
        waveSpawner = gameMaster.GetComponent<WaveSpawner>();
        UnityEngine.Debug.Log("WAVE is SPAWNED" + waveSpawner.phaseString);
        
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
