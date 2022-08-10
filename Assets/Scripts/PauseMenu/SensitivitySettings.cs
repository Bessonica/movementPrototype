using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SensitivitySettings : MonoBehaviour
{
    // Start is called before the first frame update

    //[SerializeField] float sensitivityX = 8f;
    // MouseLook
    //Lamp lampComponent = lampToStart.GetComponent<Lamp>();

    public GameObject PlayerObject;
    public Slider sensitivityXSlider;
    public Slider sensitivityYSlider;

    MouseLook mouseLookComponent;

    void Awake()
    {
        sensitivityXSlider.onValueChanged.AddListener(SetXSensitivity);
        sensitivityYSlider.onValueChanged.AddListener(SetYSensitivity);

    }


    void Start()
    {
       mouseLookComponent= PlayerObject.GetComponent<MouseLook>();
    }

    void SetXSensitivity(float value)
    {
        UnityEngine.Debug.Log("PlayerX value is  = " + mouseLookComponent.sensitivityX);
        UnityEngine.Debug.Log("X value is  = " + value);
        mouseLookComponent.sensitivityX = value;

    }

    void SetYSensitivity(float value)
    {
        UnityEngine.Debug.Log("PlayerY value is  = " + mouseLookComponent.sensitivityY);
        UnityEngine.Debug.Log("Y value is  = " + value);
        mouseLookComponent.sensitivityY = value;
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
