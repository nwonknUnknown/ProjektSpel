using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//Simon Voss
//Loads the game scene from the main menu

public class LoadNextScene : MonoBehaviour {

	public void StartGame()
    {
        StartCoroutine(LoadInSeconds());
    }

    IEnumerator LoadInSeconds()
    {
        yield return new WaitForSeconds(1.7f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Next scene is loaded");
        yield return null;
    }
}
