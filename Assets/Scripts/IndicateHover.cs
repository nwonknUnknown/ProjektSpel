using UnityEngine;
using UnityEngine.EventSystems;

//Simon Voss, Rasmus Tukia
//Changes the color/materials of turretsplots when hovered over dependent on if the player has enough gold to build the turret. Also handles logic related to building turrets on this specific plot

public class IndicateHover : MonoBehaviour {

    [Header("Optional")]
    public GameObject turret;
    public Vector3 positionOffset;
    BuildManager buildManager;
    public GameObject[] nearbyPlots;
    public bool builtOn = false;
    TurretActions turretActions;
    public GameObject indicateShootingAreaPrefab;
    private GameObject indicateShootingArea;
    public Material[] towerMaterials;
    Renderer rend;

    void Start()
    {
        //Fetch the mesh renderer component from the GameObject
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = towerMaterials[0];

        buildManager = BuildManager.instance;

        
    }


    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    private void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("This Cant Be Built Here");
            return;
        }

        buildManager.BuildTurretOn(this);

        if (!buildManager.CanBuild)
        {
            Debug.Log("Turret can't be built");
            return;
        }
        gameObject.SetActive(false);
        builtOn = true;
        for (int i = 0; i < nearbyPlots.Length; i++)
        {
            nearbyPlots[i].GetComponent<IndicateHover>().builtOn = true;
        }
    }
  
    void OnMouseOver()
    {
        // If you have enough gold to buy the selected turret
        if (GoldManager.instance.Gold >= BuildManager.instance.turretToBuild.GetComponentInChildren<TurretActions>().turretCost)
        {
            rend.sharedMaterial = towerMaterials[1];
            indicateShootingArea.GetComponent<Animator>().SetBool("HasEnoughMoney", true);
            
        }
        else
        {
            rend.sharedMaterial = towerMaterials[2];
            indicateShootingArea.GetComponent<Animator>().SetBool("HasEnoughMoney", false);
        }
    }
    private void OnMouseEnter()
    {
        // If you have enough gold to buy the selected turret
        if (GoldManager.instance.Gold >= BuildManager.instance.turretToBuild.GetComponentInChildren<TurretActions>().turretCost)
        {
            indicateShootingArea = Instantiate(indicateShootingAreaPrefab, GetComponent<Transform>());

        }
        else
        {
            indicateShootingArea = Instantiate(indicateShootingAreaPrefab, GetComponent<Transform>());
        }
    }

    void OnMouseExit()
    {
        // Reset the material of the GameObject back to normal
        rend.sharedMaterial = towerMaterials[0];
        Destroy(indicateShootingArea);
    }
}
