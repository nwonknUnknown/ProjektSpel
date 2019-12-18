using UnityEngine;

//Alexander Kourie
//Gets the main camera

public class MyCamera : MonoBehaviour {

    private void Awake()
    {
        GetComponent<Canvas>().worldCamera = Camera.main;
    }
}
