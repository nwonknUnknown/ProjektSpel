using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Erik Neuhofer
//Returns to main menu

public class ReturnToMainMenu_Script : MonoBehaviour
{
    public void ReturnToMainMenuButton(string sceneToChange)
    {
        SceneManager.LoadScene(sceneToChange);
    }
}
