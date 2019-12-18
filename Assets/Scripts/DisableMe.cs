using UnityEngine;

//Simon Voss
//Disables the gameObject when called. Obsolete but included since it's too deep inbedded in other places to be removed

public class DisableMe : MonoBehaviour {

	public void DoDisable()
    {
        gameObject.SetActive(false);
    }
}
