using UnityEngine;

//Simon Voss
//Disables or enables a whole array of gameobjects when called on

public class ToggleActiveInactive : MonoBehaviour {

    public GameObject[] targetsToMakeActive;
    public GameObject[] targetsToMakeInactive;

    public void SetTargetsObjectActive()
    {
        for (int i = 0; i < targetsToMakeActive.Length; i++)
        {
            targetsToMakeActive[i].SetActive(true);
        }
    }
    public void SetTargetsObjectInactive()
    {
        for (int i = 0; i < targetsToMakeInactive.Length; i++)
        {
            targetsToMakeInactive[i].SetActive(false);
        }
    }
}
