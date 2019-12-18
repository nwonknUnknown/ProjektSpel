using UnityEngine;

//Alexander Kourie, Simon Voss
//Handles UI-elements of turrets

public class TheTurretsUI : MonoBehaviour {

    TurretActions turretActions;
    public GameObject ui;
    private GameObject myTurret;
    private GameObject turret;
    IndicateHover indicateHover;
    public GameObject turretRangeIndicator;

    private void Start()
    {
        myTurret = gameObject;
    }

    private void OnMouseDown()
    {
        //hides all normal TurretUIs of all turrets
        foreach (GameObject turretUI in GameObject.FindGameObjectsWithTag("turretUI"))
        {
            turretUI.SetActive(false);
        }
        SetTarget(gameObject);          
    }
    public void SetTarget(GameObject clickedOnTurret)
    {
        myTurret = clickedOnTurret;
        BuildManager.instance.SelectTurret(myTurret);
    }

    public void ShowUI()
    {
        turretRangeIndicator.SetActive(true);
        ui.SetActive(true);
        Debug.Log("Showing UI");
    }

    public void HideUI()
    {
        turretRangeIndicator.SetActive(false);
        ui.SetActive(false);
        Debug.Log("Hiding UI");
     
    }
    public void RefillAmmo()
    {
        BuildManager.instance.RefillTurretsAmmo(myTurret);
    }

    /*
    public void Sell()
    {
        Debug.Log("Trying to sell turret");

        BuildManager.instance.SellTurret(target);
        BuildManager.instance.UnselectTurret();
    }
    */




}
