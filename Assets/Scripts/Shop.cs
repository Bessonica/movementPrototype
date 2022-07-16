using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standartTurret;


//  important code. we reference another object
    BuildManager buildManager;

    // попробуй так
    // public GameObject standartTurretPrefabForShop;

    void Start()
    {
        
        buildManager = BuildManager.instance;
        if(buildManager == null)
        {
            UnityEngine.Debug.Log("buildmanager instance is NULL");
        }
    }

    // public void PurchaseStandardTurret()
    // {
    //     buildManager.SetTurretToBuild(buildManager.standartTurretPrefab);
    //     // or standartTurretPrefabForShop
    // }

    public void SelectStandardTurret()
    {
        buildManager.SetTurretToBuild(standartTurret);
        // or standartTurretPrefabForShop
    }

}
