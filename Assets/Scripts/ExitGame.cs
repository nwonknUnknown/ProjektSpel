using UnityEngine;

//Simon Voss
//Quits the game when played as a standalone application

public class ExitGame : MonoBehaviour {

	public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game was exited");
    }
}
