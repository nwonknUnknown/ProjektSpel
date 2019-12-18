using UnityEngine;

//Simon Voss
//Enables the ability to click on objects marked as default layer to unselect the turret and hide the active turrets UI (not the request for refill ammo)

public class RaycastActions : MonoBehaviour
{
    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.layer == 0)
                {
                    
                    foreach (GameObject turretUI in GameObject.FindGameObjectsWithTag("turretUI"))
                    {
                        turretUI.SetActive(false);
                        Debug.Log("Hiding UI");
                    }
                    
                    BuildManager.instance.DeselectTurret();
                }
            }
        }
    }
    
}
