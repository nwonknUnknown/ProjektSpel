using UnityEngine;

//Simon Voss, Rasmus Tukia
//Removes HP of the player when an enemy reaches the defending area, also destroys the enemy that reached the area

public class TriggerDefendingArea : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        other.gameObject.layer = 13;
        WavesManager.instance.enemiesOnMap--;
        Destroy(other.gameObject);

        HpManager.instance.RemoveHP(1);
        GetComponent<Soundcontroller>().PlaySound();
        Debug.Log("Enemy hit Defending Area, removing from enemies on map");
    }
}
