using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{

    public bool isFlickering = false;
    public float timeDelay;

    Light lightToStart;

    // Start is called before the first frame update
    void Start()
    {
        lightToStart =  this.GetComponent<Light>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isFlickering == true && lightToStart.enabled == true)
        {
            StartCoroutine(FlickerLight());
        }
        
    }

// when light is disable sound should disapear

   public IEnumerator FlickerLight()
    {
        if(lightToStart.enabled == true)
        {
            isFlickering = false;



            timeDelay = Random.Range(5f, 10f);
            yield return new WaitForSeconds(timeDelay);

            this.gameObject.GetComponent<Light>().enabled = false;
            // play short sound effect
            timeDelay = Random.Range(0.01f, 0.2f);
            yield return new WaitForSeconds(timeDelay);

            this.gameObject.GetComponent<Light>().enabled = true;
            timeDelay = Random.Range(0.01f, 0.2f);
            yield return new WaitForSeconds(timeDelay);

            this.gameObject.GetComponent<Light>().enabled = false;
            // play short sound effect
            timeDelay = Random.Range(0.01f, 0.2f);
            yield return new WaitForSeconds(timeDelay);

            this.gameObject.GetComponent<Light>().enabled = true;
            timeDelay = Random.Range(0.01f, 0.2f);
            yield return new WaitForSeconds(timeDelay);

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