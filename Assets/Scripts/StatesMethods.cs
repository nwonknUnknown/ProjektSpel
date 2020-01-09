using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

//Simon Voss
//Plays UI animations at appropriate times, called from other scripts 

public class StatesMethods : MonoBehaviour
{

    [SerializeField] private GameObject _lightning;
    [SerializeField] private GameObject _camera;
    [SerializeField] private GameObject _youLostUI;
    [SerializeField] private GameObject _nomalUI;
    [SerializeField] private GameObject _loosingEffectLightning;
    [SerializeField] private GameObject _waveCompleteUI;
    [SerializeField] private GameObject _gameCompletedUI;

    [SerializeField] private GameObject defaultMusic;
    [SerializeField] private GameObject winningMusic;
    [SerializeField] private GameObject lostStinger;
    [SerializeField] private GameObject winStinger;


    public void ShowCompleteUI()
    {
        _waveCompleteUI.SetActive(true);
        _waveCompleteUI.GetComponent<PlayMyAnimation>().PlayDefault();
    }

    public void ShowLoosingState()
    {
        StartCoroutine(Die());
        lostStinger.GetComponent<Soundcontroller>().PlaySound();
    }

    public void ShowWinningState()
    {
        StartCoroutine(Win());
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator Die()
    {
        GetComponent<ToggleActiveInactive>().SetTargetsObjectInactive();
        _nomalUI.SetActive(false);
        foreach (GameObject turretUI in GameObject.FindGameObjectsWithTag("turretUI"))
        {
            turretUI.SetActive(false);
            Debug.Log("Hiding turretUI");
        }
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("enemy"))
        {
            if (enemy.GetComponent<BoxCollider>() != null)
            {
                enemy.GetComponent<BoxCollider>().enabled = false;
            }
            enemy.GetComponent<EnemyMovement>().startMovementspeed = 0;
            //enemy.GetComponent<EnemyMovement>().currentRotating = Rotation.Continue;
            enemy.layer = 0;
        }
        _camera.GetComponent<PlayMyAnimation>().PlayDefault();
        yield return new WaitForSeconds(5);
        _loosingEffectLightning.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("enemy"))
        {
            enemy.transform.LookAt(_camera.transform.position);
        }
        
        _youLostUI.SetActive(true);
        _lightning.GetComponent<PlayMyAnimation>().PlayDefault();
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("enemy"))
        {
            enemy.GetComponent<EnemyMovement>().startMovementspeed = 5;
        }
        yield return null;
    }
    IEnumerator Win()
    {
        _nomalUI.SetActive(false);
        foreach (GameObject turretUI in GameObject.FindGameObjectsWithTag("turretUI"))
        {
            turretUI.SetActive(false);
            Debug.Log("Hiding turretUI");
        }
        GetComponent<ToggleActiveInactive>().SetTargetsObjectInactive();
        _gameCompletedUI.SetActive(true);
        defaultMusic.GetComponent<Soundcontroller>().PauseSound();
        winStinger.GetComponent<Soundcontroller>().PlaySound();
        yield return new WaitForSeconds(19.5f);
        winningMusic.GetComponent<Soundcontroller>().PlaySound();
    }
}
