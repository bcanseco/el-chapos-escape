using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class CaughtMenu : MonoBehaviour {

	public void Start() {
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = true;
	}


    // Begins level when user presses play by loading the next scene
    public void StartLevel() {
		SceneManager.LoadScene(1);
    }

    // Exits the game
    public void ExitGame() {
        Application.Quit();
    }

}
