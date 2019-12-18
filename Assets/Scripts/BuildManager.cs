using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Alexander Kourie, Simon Voss
//Methods to build towers or refill ammo on built turrets. Also includes methods to select, deselect or deselect and hide a turret and its UI

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    public GameObject buildWeakTowerButton;
    public GameObject buildWeakTowerButtonCancel;
    public GameObject buildWeakTowerButtonStats;

    public GameObject buildStrongTowerButton;
    public GameObject buildStrongTowerButtonCancel;
    public GameObject buildStrongTowerButtonStats;


    private void Awake()
    {
        instance = this;
    }

    public GameObject WeakTurretPrefab;
    public GameObject StrongTurretPrefab;
    TheTurretsUI theTurretsUI;
    public GameObject turretToBuild;
    private GameObject selectedTurret;

    public bool CanBuild = true;


    public void BuildTurretOn(IndicateHover indicateHover)
    {
        if (GoldManager.instance.Gold < turretToBuild.GetComponentInChildren<TurretActions>().turretCost)
        {
            Debug.Log("Not Enough Gold");
            CanBuild = false;
            return;
        }
        CanBuild = true;
        GoldManager.instance.RemoveGold(turretToBuild.GetComponentInChildren<TurretActions>().turretCost);
        GameObject turret = (GameObject)Instantiate(turretToBuild, indicateHover.GetBuildPosition(), Quaternion.identity);
        indicateHover.turret = turret;
        Debug.Log("Turret Built");
    }

    public void DeselectTurret()
    {
        selectedTurret = null;
    }

    public void SelectTurret(GameObject turret)
    {
        if (selectedTurret != null && selectedTurret == turret)
        {
            UnselectTurret();
            return;
        }

        selectedTurret = turret;
        selectedTurret.GetComponent<TheTurretsUI>().ShowUI();
        GetComponent<BuildingMode>().HideWeakBuildablePlots();
        GetComponent<BuildingMode>().HideStrongBuildablePlots();
        buildWeakTowerButton.SetActive(true);
        buildWeakTowerButtonCancel.SetActive(false);
        buildStrongTowerButton.SetActive(true);
        buildStrongTowerButtonCancel.SetActive(false);
        buildStrongTowerButtonStats.SetActive(false);
        buildWeakTowerButtonStats.SetActive(false);

        turretToBuild = null;
    }


    public void UnselectTurret()
    {
        selectedTurret.GetComponent<TheTurretsUI>().HideUI();
        selectedTurret = null;
    }

  
    public void SelectTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }

      
    public void RefillTurretsAmmo(GameObject selectedTurret)
    {
        int refillAmmoCost = (selectedTurret.GetComponentInChildren<TurretActions>().startAmmo - selectedTurret.GetComponentInChildren<TurretActions>().currentAmmo) * selectedTurret.GetComponentInChildren<TurretActions>().bulletCost;
        if (GoldManager.instance.Gold >= refillAmmoCost)
        {
            if (selectedTurret.transform.Find("NoAmmoUI").gameObject.activeSelf)
            {
                selectedTurret.GetComponentInChildren<OnHoverEnlarge>().ReturnSizeUI();
            }
            GoldManager.instance.RemoveGold(refillAmmoCost);
            if (selectedTurret.transform.Find("TurretUI").gameObject.activeSelf)
            {
                selectedTurret.GetComponentInChildren<TurretActions>().currentAmmo = selectedTurret.GetComponentInChildren<TurretActions>().startAmmo;
                selectedTurret.transform.Find("TurretUI").Find("Choices").Find("RefillAmmo").GetComponentInChildren<UpdateMyText>().UpdateRefillCostAsInt(0);
                selectedTurret.transform.Find("TurretUI").Find("Choices").Find("CurrentAmmo").GetComponentInChildren<UpdateMyText>().UpdateMyTextAsInt(selectedTurret.GetComponentInChildren<TurretActions>().startAmmo);
            }
            else
            {
                selectedTurret.transform.Find("TurretUI").gameObject.SetActive(true);
                selectedTurret.GetComponentInChildren<TurretActions>().currentAmmo = selectedTurret.GetComponentInChildren<TurretActions>().startAmmo;
                selectedTurret.transform.Find("TurretUI").Find("Choices").Find("RefillAmmo").GetComponentInChildren<UpdateMyText>().UpdateRefillCostAsInt(0);
                selectedTurret.transform.Find("TurretUI").Find("Choices").Find("CurrentAmmo").GetComponentInChildren<UpdateMyText>().UpdateMyTextAsInt(selectedTurret.GetComponentInChildren<TurretActions>().startAmmo);
                selectedTurret.transform.Find("TurretUI").gameObject.SetActive(false);
            }
            selectedTurret.transform.Find("NoAmmoUI").gameObject.SetActive(false);
            selectedTurret.transform.Find("AmmoReloadSound").gameObject.GetComponent<Soundcontroller>().PlaySound();
            Debug.Log("Refilling ammo");
        }
        else
        {
            Debug.Log("Not enough gold");
        }
    }


    /*
    public void SellTurret(GameObject selectedTurret)         
    {
        Debug.Log("Increasing gold");

        GoldManager.instance.IncreaseGold(10); //change to a good number
        Destroy(selectedTurret);
        turretBluePrint = null;
        //add plots back to unbuilt so they can be built on again
    }
    */
}
