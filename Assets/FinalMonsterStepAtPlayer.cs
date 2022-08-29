using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalMonsterStepAtPlayer : MonoBehaviour
{

    [Header("Sound Sources Around Player")]
    public Transform SoundSource1;
    public Transform SoundSource2;
    public Transform SoundSource3;
    public Transform SoundSource4;

    public bool StartRunning;

    public Transform PlayerObject;

    public int Speed;

    Vector3 dir1, dir2, dir3, dir4;



    // Start is called before the first frame update
    void Start()
    {
        StartRunning = false;
    }


    public void RunAtPlayer(GameObject Player)
    {

    }

    // Update is called once per frame
    void Update()
    {

        if(StartRunning)
        {

            dir1 = PlayerObject.position - SoundSource1.position;
            dir2 = PlayerObject.position - SoundSource2.position;
            dir3 = PlayerObject.position - SoundSource3.position;
            dir4 = PlayerObject.position - SoundSource4.position;

            SoundSource1.Translate(dir1.normalized * Speed * Time.deltaTime, Space.World);

        }
        
    }
}
