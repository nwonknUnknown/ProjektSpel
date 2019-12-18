using UnityEngine;

//Simon Voss
//Includes stats of the enemy such as gold and hp, also calles for the script "EnemyDeath" when enemy reaches 0hp

public class EnemyStats : MonoBehaviour {

    public int hp;
    [SerializeField] private int goldWorth;
    bool isDead = false;

    public void IncreaseHP(int hpToAdd)
    {
        hp += hpToAdd;
    }

    public void RemoveHP(int hpToRemove)
    {
        hp -= hpToRemove;
        if (hp <=0 && !isDead)
        {
            isDead = true;
            GoldManager.instance.IncreaseGold(goldWorth);
            GetComponent<EnemyDeath>().Death();
        }
    }
}
