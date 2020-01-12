using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Simon Voss, Alexander Kourie
//Shows or hides plots that can be built on

public class BuildingMode : MonoBehaviour
{


    public GameObject[] weakTurretPlots;
    //public GameObject[] slowTurretPlots;
    public GameObject[] strongTurretPlots;
    //public GameObject[] aoeTurretPlots;

    public void ShowWeakBuildablePlots()
    {
        for (int i = 0; i < weakTurretPlots.Length; i++)
        {
            if (weakTurretPlots[i].GetComponent<IndicateHover>().builtOn == false)
            {
                weakTurretPlots[i].SetActive(true);
            }
        }
    }

    public void ShowStrongBuildablePlots()
    {
        for (int i = 0; i < strongTurretPlots.Length; i++)
        {
            if (strongTurretPlots[i].GetComponent<IndicateHover>().builtOn == false)
            {
                strongTurretPlots[i].SetActive(true);
            }
        }
    }

    /*public void ShowAoeBuildablePlots()
    {
        for (int i = 0; i < aoeTurretPlots.Length; i++)
        {
            if (aoeTurretPlots[i].GetComponent<IndicateHover>().builtOn == false)
            {
                aoeTurretPlots[i].SetActive(true);
            }
        }
    }
    
    public void ShowSlowBuildablePlots()
    {
        for (int i = 0; i < slowTurretPlots.Length; i++)
        {
            if (slowTurretPlots[i].GetComponent<IndicateHover>().builtOn == false)
            {
                slowTurretPlots[i].SetActive(true);
            }
        }
    }*/

    public void HideWeakBuildablePlots()
    {
        for (int i = 0; i < weakTurretPlots.Length; i++)
        {
            weakTurretPlots[i].SetActive(false);
        }
    }

    public void HideStrongBuildablePlots()
    {
        for (int i = 0; i < strongTurretPlots.Length; i++)
        {
            strongTurretPlots[i].SetActive(false);
        }
    }

    /*public void HideAoeBuildablePlots()
    {
        for (int i = 0; i < aoeTurretPlots.Length; i++)
        {
            aoeTurretPlots[i].SetActive(false);
        }
    }

    public void HideSlowBuildablePlots()
    {
        for (int i = 0; i < weakTurretPlots.Length; i++)
        {
            weakTurretPlots[i].SetActive(false);
        }
    }*/
}
