using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    // variable to check how many turrets player can build
    // placed turret -1 from var
    // deactivated turret +1 to var
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
    public static int Money;
    public int startMoney = 1;
    public float timeForMoney = 5f;

    // Start is called before the first frame update
    void Start()
    {
        timerSlider.maxValue = timerLimit;
        timerSlider.value = 0;


        Money = startMoney;
        moneyText.text = Money.ToString();
    }


    // make a timer that runs in background and adds 1 to Money
    //    when power is out turn it off, and when power is on turn it on

    void Update()
    {
    //  text timer part 
        moneyText.text = Money.ToString();

        //timer part
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
        timerText.text = currentTime.ToString("0");
        if(currentTime >= timerLimit)
        {
            Money ++;
            UnityEngine.Debug.Log("added more money " + Money);
            currentTime = 0;
            


        }
    // text timer part  end

    // gui timer

    timerSlider.value = currentTime;


    }


}
