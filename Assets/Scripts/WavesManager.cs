using UnityEngine;

//Simon Voss, Erik Neuhofer
//Handles the current wave actions such as how many enemies to spawn, and enables this to be changed in the inspector. 
//Also includes the logic behind when to change to the next wave, and gives gold when a wave is active

public class WavesManager : MonoBehaviour
{
    enum State { WaveOne, WaveTwo, WaveThree, WaveFour, WaveFive, Winningscreen, BetweenWaves }
    [SerializeField] private State _currentWave = State.WaveOne;

    [SerializeField] private GameObject _gameManager;
    [SerializeField] private GameObject _lightning;
    [SerializeField] private GameObject _waveCompleteUI;
    [SerializeField] private GameObject _startNextWaveUI;
    [SerializeField] private GameObject _startNextWaveUIButton;
    [SerializeField] private GameObject nextWaveSound;

    public int enemiesOnMap;
    public int enemiesToBeSpawned;

    [SerializeField] private float timeToFirstSpawn;
    [SerializeField] private float timeBetweenSpawns;

    [SerializeField] private int goldRewardAfterWave = 200;

    [SerializeField] private int[] numberOfEnemiesWave1;
    [SerializeField] private int[] numberOfEnemiesWave2;
    [SerializeField] private int[] numberOfEnemiesWave3;
    [SerializeField] private int[] numberOfEnemiesWave4;
    [SerializeField] private int[] numberOfEnemiesWave5;



    private bool spawnHasStarted = false;
    private bool onWinningScreen = false;
    private bool betweenWaves = false;

    private float time;

    public static WavesManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void CreateWave(int[] _waveEnemies)
    {
        for (int i = 0; i < _waveEnemies.Length; i++)
        {
            enemiesToBeSpawned += _waveEnemies[i];
        }
        GetComponent<CreateEnemy>().StartWave(_waveEnemies, timeToFirstSpawn, timeBetweenSpawns);
        _lightning.GetComponent<PlayMyAnimation>().PlayDefault();
        NewWaveText.ins.DoMenuThings((int)_currentWave); 

        spawnHasStarted = true;
        time = 0;
    }

    private void WaveCompleted()
    {
        if (!HpManager.instance.CheckIfLost())
        {
            GoldManager.instance.IncreaseGold(goldRewardAfterWave);
            _gameManager.GetComponent<StatesMethods>().ShowCompleteUI();
            _startNextWaveUI.SetActive(true);
            _startNextWaveUIButton.SetActive(true);
        }
    }

    public void ChangeWaveToNext()
    {
        _startNextWaveUIButton.SetActive(false);
        nextWaveSound.GetComponent<Soundcontroller>().PlaySound();
        _currentWave++;
        spawnHasStarted = false;
        Debug.Log("Getting next wave");
        betweenWaves = false;
    }


    private void GiveGoldEachSecond()
    {
        if (time >= timeToFirstSpawn)
        {
            time += Time.deltaTime;
            if (time >= timeToFirstSpawn + 1)
            {
                time -= 1;
                GoldManager.instance.IncreaseGold(1);
            }
        }
        else
        {
            time += Time.deltaTime;
        }
    }
   
    // Update is called once per frame
    void Update ()
    {
        switch (_currentWave)
        {
            case State.WaveOne:
                {
                    //creates a wave if we just started the wave
                    if (!spawnHasStarted)
                    {
                        Debug.Log("Wave One");
                        CreateWave(numberOfEnemiesWave1);
                    }

                    if(!betweenWaves)
                    {
                        GiveGoldEachSecond();
                    }

                    //change wave when enemies reaches 0
                    if (enemiesOnMap == 0 && enemiesToBeSpawned == 0 && !betweenWaves)
                    {
                        betweenWaves = true;
                        WaveCompleted();
                    }
                    break;
                }
            case State.WaveTwo:
                {
                    //creates a wave if we just started the wave
                    if (!spawnHasStarted)
                    {
                        Debug.Log("Wave Two");
                        CreateWave(numberOfEnemiesWave2);
                    }

                    if (!betweenWaves)
                    {
                        GiveGoldEachSecond();
                    }


                    //change wave when enemies reaches 0
                    if (enemiesOnMap == 0 && enemiesToBeSpawned == 0 && !betweenWaves)
                    {
                        betweenWaves = true;
                        WaveCompleted();
                    }
                    break;
                }
            case State.WaveThree:
                {
                    //creates a wave if we just started the wave
                    if (!spawnHasStarted)
                    {
                        CreateWave(numberOfEnemiesWave3);
                    }

                    if (!betweenWaves)
                    {
                        GiveGoldEachSecond();
                    }

                    //change wave when enemies reaches 0
                    if (enemiesOnMap == 0 && enemiesToBeSpawned == 0 && !betweenWaves)
                    {
                        betweenWaves = true;
                        WaveCompleted();
                    }
                    break;
                }
            case State.WaveFour:
                {
                    //creates a wave if we just started the wave
                    if (!spawnHasStarted)
                    {
                        
                        CreateWave(numberOfEnemiesWave4);
                    }

                    if (!betweenWaves)
                    {
                        GiveGoldEachSecond();
                    }

                    //change wave when enemies reaches 0
                    if (enemiesOnMap == 0 && enemiesToBeSpawned == 0 && !betweenWaves)
                    {
                        betweenWaves = true;
                        WaveCompleted();
                    }
                    break;
                }
            case State.WaveFive:
                {
                    //creates a wave if we just started the wave
                    if (!spawnHasStarted)
                    {
                        CreateWave(numberOfEnemiesWave5);
                    }

                    if (!betweenWaves)
                    {
                        GiveGoldEachSecond();
                    }

                    //change wave when enemies reaches 0
                    if (enemiesOnMap == 0 && enemiesToBeSpawned == 0)
                    {
                        _currentWave = State.Winningscreen;
                    }
                    break;
                }
            case State.Winningscreen:
                {
                    if (!onWinningScreen && !HpManager.instance.CheckIfLost())
                    {
                        Debug.Log("Winning Screen");
                        _gameManager.GetComponent<StatesMethods>().ShowWinningState();
                        onWinningScreen = true;
                    }
                    break;
                }
        }
    }
}
