using UnityEngine;

//Simon Voss
//Deals damage to the gameObject when colliding

public class DamageToEnemy : MonoBehaviour {
    public int damage;

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<EnemyStats>().RemoveHP(damage);
        Destroy(gameObject);
    }
}
