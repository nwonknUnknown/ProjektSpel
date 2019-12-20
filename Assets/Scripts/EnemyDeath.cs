using System.Collections;
using UnityEngine;

//Simon Voss
//Destroys the gameObject of type enemy after playing deathanimation etc.

public class EnemyDeath : MonoBehaviour {


	public void Death()
    {
        GetComponent<EnemyMovement>().startMovementspeed = 0;
        
        gameObject.layer = 13;

        WavesManager.instance.enemiesOnMap--;

        StartCoroutine(Die());
    }
    
    //remove collider, and later destroy object
    IEnumerator Die ()
    {
        GetComponent<Soundcontroller>().PlaySound();
        GetComponent<PlayMyAnimation>().PlayDeath();
        yield return new WaitForSeconds(3);
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<BoxCollider>().enabled = false;
        Destroy(gameObject, .1f);
        yield return null;
    }
    
}
