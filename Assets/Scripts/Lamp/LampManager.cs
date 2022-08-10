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

        }
        

    }

    public void StopAllLamps()
    {


        foreach(GameObject lampToStart in GameObject.FindGameObjectsWithTag("lamp"))
        {
           Light lightToStart =  lampToStart.GetComponent<Light>();
           Lamp lampComponent = lampToStart.GetComponent<Lamp>();

           

           lampComponent.powerOff = true;

           lampComponent.isFlickering = false;
           StopCoroutine(lampComponent.FlickerLight());
           lampComponent.isFlickering = false;
        
           lightToStart.enabled = false;

        }

        // playerLight.SetActive(true);
        StartCoroutine(startPlayerLight(5f));

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

        }

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





