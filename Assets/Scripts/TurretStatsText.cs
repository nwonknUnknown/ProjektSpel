using UnityEngine;
using UnityEngine.UI;

//Simon Voss
//Displays the turret stats taken from turret prefabs

public class TurretStatsText : MonoBehaviour {

    [SerializeField] private GameObject turretWithStats;
    [SerializeField] private string turretName;
    [SerializeField] private string range;



    private void Start()
    {
        GetComponent<Text>().text = turretName + "\n\n" + "Range: " + range + turretWithStats.GetComponentInChildren<TurretActions>().GetTurretStats();
    }
}
