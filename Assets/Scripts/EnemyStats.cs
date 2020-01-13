using UnityEngine;

//Simon Voss
//Includes stats of the enemy such as gold and hp, also calles for the script "EnemyDeath" when enemy reaches 0hp

public class EnemyStats : MonoBehaviour
{

    public float hp;//Changed to f from int
    [SerializeField] private int goldWorth;
    bool isDead = false;

    //Removed increase HP?

    public void RemoveHP(float hpToRemove)//Changed to float
    {
        hp -= hpToRemove;
        if (hp <= 0 && !isDead)
        {
            isDead = true;
            GoldManager.instance.IncreaseGold(goldWorth);
            GetComponent<EnemyDeath>().Death();
            
        }
    }
}
