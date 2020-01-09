using UnityEngine;

//Simon Voss, Alexander Kourie
//Holds the prefabs for the different turrets

public class Shop : MonoBehaviour
{


    [SerializeField] private GameObject strongTurret;
    [SerializeField] private GameObject weakTurret;
    [SerializeField] private GameObject slowTurret;
    [SerializeField] private GameObject aoeTurret;
    [SerializeField] private GameObject piercingTurret;
    [SerializeField] private GameObject superTurret;


    public void SelectWeakTurret()
    {
        Debug.Log("Weak Turret Selected");
        BuildManager.instance.SelectTurretToBuild(weakTurret);
    }

    public void SelectStrongTurret()
    {
        Debug.Log("Strong Turret Selected");
        BuildManager.instance.SelectTurretToBuild(strongTurret);
    }

    public void SelectSlowTurret()
    {
        Debug.Log("Slow Turret Selected");
        BuildManager.instance.SelectTurretToBuild(slowTurret);
    }

    public void SelectAoeTurret()
    {
        Debug.Log("Aoe Turret Selected");
        BuildManager.instance.SelectTurretToBuild(aoeTurret);
    }

    public void SelectPiercingTurret()
    {
        Debug.Log("Piercing Turret Selected");
        BuildManager.instance.SelectTurretToBuild(piercingTurret);
    }

    public void SelectSuperTurret()
    {
        Debug.Log("Super Turret Selected");
        BuildManager.instance.SelectTurretToBuild(superTurret);
    }

}
