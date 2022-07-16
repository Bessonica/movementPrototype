using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // variable to check how many turrets player can build
    // placed turret -1 from var
    // deactivated turret +1 to var

    public static int Money;
    public int startMoney = 400;
    // Start is called before the first frame update
    void Start()
    {
        Money = startMoney;
        
    }


}
