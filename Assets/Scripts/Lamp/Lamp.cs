using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{

    public bool isFlickering = false;
    public float timeDelay;
    public bool powerOff;

    public Material lightMaterial;


    public bool IsFinalLight;

    Light lightToStart;

    [Header("gameMaster")]
    public GameObject gameMaster;

    PlayerStats playerStats;
    GameObject playerObjectInteract;
    MouseLook mouseLook;
    InputManager inputManager;

    // Start is called before the first frame update

    void Awake()
    {
        lightMaterial.DisableKeyword("_EMISSION");
    }
    void Start()
    {
        lightToStart =  this.GetComponent<Light>();
        powerOff = false;


        playerStats = gameMaster.GetComponent<PlayerStats>();
        playerObjectInteract = playerStats.playerObject;
        
        mouseLook = playerObjectInteract.GetComponent<MouseLook>();
        inputManager = playerObjectInteract.GetComponent<InputManager>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if(isFlickering == true && lightToStart.enabled == true)
        {
            // UnityEngine.Debug.Log("Started flickering");
            // UnityEngine.Debug.Log("isFlickering = " + isFlickering);
            // UnityEngine.Debug.Log("lightToStart.enabled = " + lightToStart.enabled);

            StartCoroutine(FlickerLight());
        }
        
    }



    public IEnumerator PopFinalLight()
    {
        // flicker a little
        // make sound of breaking glass


        if(lightToStart.enabled == true)
        {
            isFlickering = false;

            

            // should we isFlickering = false; put BEFORE yield break???
            if(powerOff)
            { 
                yield break;
                isFlickering = false;
            }

            this.gameObject.GetComponent<Light>().enabled = false;
            this.lightMaterial.DisableKeyword("_EMISSION");

            // play short sound effect
            timeDelay = Random.Range(0.01f, 0.2f);
            yield return new WaitForSeconds(timeDelay);

            if(powerOff)
            { 
                yield break;
                isFlickering = false;
            }


            this.gameObject.GetComponent<Light>().enabled = true;
            this.lightMaterial.EnableKeyword("_EMISSION");

            timeDelay = Random.Range(0.01f, 0.2f);
            yield return new WaitForSeconds(timeDelay);

            if(powerOff)
            { 
                yield break;
                isFlickering = false;
            }

            isFlickering = true;


        }

        // turn off lamp 
        LampManager.instance.StopAllLamps();
        AudioManager.instance.StopGeneratorSFX();
        // AudioManager.instance.FinalLampPopSFX();
        yield return new WaitForSeconds(5f);
    // play sound of monsters running at player

    // take away player movement
        AudioManager.instance.SetStepVolume(-80f);
        mouseLook.enabled = false;
        inputManager.enabled = false;

    // play sound of player getting eaten 
    




    }

    public IEnumerator FlickerFinalLight()
    {
        // if(IsFinalLight)
        // {
        //     // do flicker stuff
        // }
        


        if(lightToStart.enabled == true)
        {
            isFlickering = false;

            // should we isFlickering = false; put BEFORE yield break???
            if(powerOff)
            { 
                yield break;
                isFlickering = false;
            }

            this.gameObject.GetComponent<Light>().enabled = false;
            this.lightMaterial.DisableKeyword("_EMISSION");

            // play short sound effect
            timeDelay = Random.Range(0.01f, 0.1f);
            yield return new WaitForSeconds(timeDelay);

            if(powerOff)
            { 
                yield break;
                isFlickering = false;
            }


            this.gameObject.GetComponent<Light>().enabled = true;
            this.lightMaterial.EnableKeyword("_EMISSION");

            timeDelay = Random.Range(0.01f, 0.1f);
            yield return new WaitForSeconds(timeDelay);

            if(powerOff)
            { 
                yield break;
                isFlickering = false;
            }


            this.gameObject.GetComponent<Light>().enabled = false;
            this.lightMaterial.DisableKeyword("_EMISSION");

            // play short sound effect
            timeDelay = Random.Range(0.01f, 0.1f);
            yield return new WaitForSeconds(timeDelay);

            if(powerOff)
            { 
                yield break;
                isFlickering = false;
            }


            this.gameObject.GetComponent<Light>().enabled = true;
            this.lightMaterial.EnableKeyword("_EMISSION");

            timeDelay = Random.Range(0.01f, 0.2f);
            yield return new WaitForSeconds(timeDelay);

            if(powerOff)
            { 
                yield break;
                isFlickering = false;
            }


            this.gameObject.GetComponent<Light>().enabled = false;
            this.lightMaterial.DisableKeyword("_EMISSION");

            timeDelay = Random.Range(0.01f, 0.1f);
            yield return new WaitForSeconds(timeDelay);

            if(powerOff)
            { 
                yield break;
                isFlickering = false;
            }



            this.gameObject.GetComponent<Light>().enabled = true;
            this.lightMaterial.EnableKeyword("_EMISSION");

            timeDelay = Random.Range(0.01f, 0.2f);
            yield return new WaitForSeconds(timeDelay);

            if(powerOff)
            { 
                yield break;
                isFlickering = false;
            }




            this.gameObject.GetComponent<Light>().enabled = false;
            this.lightMaterial.DisableKeyword("_EMISSION");


            timeDelay = Random.Range(0.01f, 0.1f);
            yield return new WaitForSeconds(timeDelay);

            if(powerOff)
            { 
                yield break;
                isFlickering = false;
            }


            this.gameObject.GetComponent<Light>().enabled = true;
            this.lightMaterial.EnableKeyword("_EMISSION");

            timeDelay = Random.Range(0.01f, 0.1f);
            yield return new WaitForSeconds(timeDelay);

            if(powerOff)
            { 
                yield break;
                isFlickering = false;
            }



            isFlickering = true;


        }





    }


// when light is disable sound should disapear

   public IEnumerator FlickerLight()
    {
        // while(!powerOff)
        // {}

        // UnityEngine.Debug.Log("powerOff = " + powerOff);


        if(lightToStart.enabled == true)
        {
            isFlickering = false;



            timeDelay = Random.Range(5f, 10f);
            yield return new WaitForSeconds(timeDelay);
            

            // should we isFlickering = false; put BEFORE yield break???
            if(powerOff)
            { 
                yield break;
                isFlickering = false;
            }


            this.gameObject.GetComponent<Light>().enabled = false;
            this.lightMaterial.DisableKeyword("_EMISSION");
            

            // play short sound effect
            timeDelay = Random.Range(0.01f, 0.2f);
            yield return new WaitForSeconds(timeDelay);

            if(powerOff)
            { 
                yield break;
                isFlickering = false;
            }


            this.gameObject.GetComponent<Light>().enabled = true;
            this.lightMaterial.EnableKeyword("_EMISSION");

            timeDelay = Random.Range(0.01f, 0.2f);
            yield return new WaitForSeconds(timeDelay);

            if(powerOff)
            { 
                yield break;
                isFlickering = false;
            }


            this.gameObject.GetComponent<Light>().enabled = false;
            this.lightMaterial.DisableKeyword("_EMISSION");

            // play short sound effect
            timeDelay = Random.Range(0.01f, 0.2f);
            yield return new WaitForSeconds(timeDelay);

            if(powerOff)
            { 
                yield break;
                isFlickering = false;
            }


            this.gameObject.GetComponent<Light>().enabled = true;
            this.lightMaterial.EnableKeyword("_EMISSION");

            timeDelay = Random.Range(0.01f, 0.2f);
            yield return new WaitForSeconds(timeDelay);

            if(powerOff)
            { 
                yield break;
                isFlickering = false;
            }


            isFlickering = true;


        }

    }
}



// courutine to flicker half randomly


////////////////
// Light myLight = lightPoint.GetComponent("Light");


// if (Input.GetButtonDown("Fire1")) {
//     myLight.enabled = !myLight.enabled;
// }
////////////////

//buildManager = this.GetComponent<BuildManager>();