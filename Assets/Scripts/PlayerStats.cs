using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    [Header("player object")]
    public GameObject playerObject;
    
    
    [Header("Timer")]
    public TextMeshProUGUI timerText;
    public float currentTime;
    public bool countDown;
    public bool hasLimit;
    public float timerLimit;

    [Header("Timer Slider")]
    public Slider timerSlider;
    // public Text timerText;


    [Header("Money")]
    public TextMeshProUGUI moneyText;
       // could not change it in interactable
    public static int Money;
    public int startMoney = 0;
    public float timeForMoney = 5f;
    public bool startTimer = false;

    [Header("Cameras to switch")]
    public Camera playerCamera;
    public Camera tdCamera;

    [Header("Canvase for player and towerDef UI")]
    public GameObject playerCanvas;
    public GameObject towerDefCanvas;

    public GameObject playerCameraObject;
    Interactor interactorObject;


    // Start is called before the first frame update
    void Start()
    {
        timerSlider.maxValue = timerLimit;
        timerSlider.value = 0;


        Money = startMoney;
        moneyText.text = Money.ToString();

        // turn ui on/off so they wouldnt overlap
        playerCanvas.SetActive(true);
        towerDefCanvas.SetActive(false);

        interactorObject = playerCameraObject.GetComponent<Interactor>();
    }

    public void ChangeLeverTime(float time)
    {
        interactorObject.HoldTimerDeadLine = time;

    }


    // make a timer that runs in background and adds 1 to Money
    //    when power is out turn it off, and when power is on turn it on
    public void ChangeTimerLimit(float time)
    {
        timerSlider.maxValue = time;
        timerLimit = time;

    }



    void Update()
    {

        if(startTimer)
        {

            //  text timer part 
                moneyText.text = Money.ToString();

                //timer part
                currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
                timerText.text = currentTime.ToString("0");
                if(currentTime >= timerLimit)
                {
                    Money ++;
                    // UnityEngine.Debug.Log("added more money " + Money);
                    currentTime = 0;
                    


                }
            // text timer part  end

            // gui timer

            timerSlider.value = currentTime;


        }



    }


}
