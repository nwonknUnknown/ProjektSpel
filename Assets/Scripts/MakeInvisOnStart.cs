using UnityEngine;

//Simon Voss
//Hides this gameobject on start

public class MakeInvisOnStart : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        gameObject.SetActive(false);
	}
	
}
