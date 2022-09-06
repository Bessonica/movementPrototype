using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampManager : MonoBehaviour
{

// singleton
  // from here find all objects with tag Lamp and turn them off/on


    public static LampManager instance;
    public GameObject playerLight;


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


    void Start()
    {
        playerLight.SetActive(true);
    }

// change color red/white
// stop all light
    public void StartAllLamps()
    {
        playerLight.SetActive(false);


        foreach(GameObject lampToStart in GameObject.FindGameObjectsWithTag("lamp"))
        {
           Light lightToStart =  lampToStart.GetComponent<Light>();
           Lamp lampComponent = lampToStart.GetComponent<Lamp>();
           
           lightToStart.enabled = true;
           lampComponent.powerOff = false;

           //emisive material
           lampComponent.lightMaterial.EnableKeyword("_EMISSION");

        }
        

    }

    public void StopAllLamps(string final = "notAFinal")
    {
        // UnityEngine.Debug.Log(final);


        foreach(GameObject lampToStart in GameObject.FindGameObjectsWithTag("lamp"))
        {
           Light lightToStart =  lampToStart.GetComponent<Light>();
           Lamp lampComponent = lampToStart.GetComponent<Lamp>();

           

           lampComponent.powerOff = true;

           lampComponent.isFlickering = false;
           StopCoroutine(lampComponent.FlickerLight());
           lampComponent.isFlickering = false;
        
           lightToStart.enabled = false;

           lampComponent.lightMaterial.DisableKeyword("_EMISSION");

        }

        // playerLight.SetActive(true);
        if(final == "final")
        {
            // this is when lampPop happens
            UnityEngine.Debug.Log("light off");
            // StartCoroutine(startPlayerLight(200f));
            stopPlayerLight();
        }
        else
        {
            // this is when doorTear
            StartCoroutine(startPlayerLight(7.5f));
        }
        

    }

    public void stopPlayerLight()
    {
        playerLight.SetActive(false);
    }

    public IEnumerator startPlayerLight(float time)
    {
        yield return new WaitForSeconds(time);
        playerLight.SetActive(true);
        yield break;

    }

    public void ChangeColorRedAllLamps()
    {

        playerLight.SetActive(false);


        foreach(GameObject lampToStart in GameObject.FindGameObjectsWithTag("lamp"))
        {
           Light lightToStart =  lampToStart.GetComponent<Light>();
           Lamp lampComponent = lampToStart.GetComponent<Lamp>();

           // invoke flicker function
        //    StartCoroutine(lampComponent.FlickerLight());
            


           // change color
           lightToStart.color = Color.red;

           lampComponent.lightMaterial.SetColor("_EmissionColor", Color.red * 2.0f);

        }

    }

    public void ChangeColorNormalAllLamps()
    {
        playerLight.SetActive(false);

    

        foreach(GameObject lampToStart in GameObject.FindGameObjectsWithTag("lamp"))
        {
           Light lightToStart =  lampToStart.GetComponent<Light>();
           Lamp lampComponent = lampToStart.GetComponent<Lamp>();

           // invoke flicker function
        //    StartCoroutine(lampComponent.FlickerLight());
            


           // change color
           lightToStart.color = Color.white;
           lampComponent.lightMaterial.SetColor("_EmissionColor", Color.white * 2.0f);

        }

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}





