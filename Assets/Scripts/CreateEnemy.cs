using UnityEngine;


public class CreateEnemy : MonoBehaviour
{
    [SerializeField] private PlayMyAnimation[] spawnAnimation;

    [SerializeField] private GameObject gameManager;
    [SerializeField] private GameObject[] enemy;
    [SerializeField] private Transform[] spawnPoints;
    private int[] numberOfSpawnsofEnemy;



    public void StartWave(int[] inputNumberofSpawnsofEnemy, float firstSpawnDelay, float spawnTimer)
    {
        numberOfSpawnsofEnemy = inputNumberofSpawnsofEnemy;
        InvokeRepeating("Spawn", firstSpawnDelay, spawnTimer);
    }

    void Spawn()
    {
        int enemyIndex = Random.Range(0, enemy.Length);

        if (numberOfSpawnsofEnemy[enemyIndex] <= 0)
        {
            return;
        }

        if (HpManager.instance.CheckIfLost())
        {
            return;
        }

        GetComponent<WavesManager>().enemiesOnMap++;
        GetComponent<WavesManager>().enemiesToBeSpawned--;
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        //Spawns the enemy
        GameObject enemyObject = Instantiate(enemy[enemyIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].localRotation);
        enemyObject.GetComponent<EnemyMovement>().waypointPath = GameObject.FindGameObjectWithTag("Waypoint" + spawnPointIndex).GetComponent<Checkpoints>();
        numberOfSpawnsofEnemy[enemyIndex]--;




        //Plays animations dependent on which spawnpoint that was used

        if (spawnAnimation[spawnPointIndex] != null)
        {
            spawnAnimation[spawnPointIndex].PlayDefault();

        }
    }
}