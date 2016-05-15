using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class WinScript : MonoBehaviour {

    public GameObject winScreen;

    public Button explore;
    public Button toMenu;
    public Button exit;

    public bool isInWinScreen;

    // Use this for initialization
    void Start() {
        isInWinScreen = false;

        // Get all components
        explore = explore.GetComponent<Button>();
        toMenu = toMenu.GetComponent<Button>();
        exit = exit.GetComponent<Button>();

        winScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        if (isInWinScreen)
        {
            WalkOutsideTrigger();
        }
    }

    public void WalkOutsideTrigger() {
        isInWinScreen = true;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        (GameObject.Find("FPSController").GetComponent("FirstPersonController") as MonoBehaviour).enabled = false;
        winScreen.SetActive(true);
		Time.timeScale = 0.0f;
    }

	// Lets the user explore the outside
	public void Explore() {
		isInWinScreen = false;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		(GameObject.Find("FPSController").GetComponent("FirstPersonController") as MonoBehaviour).enabled = true;
		winScreen.SetActive(false);
		Time.timeScale = 1.0f;
	}

    // return to title screen
    public void LoadTitleScreen() {
        isInWinScreen = false;
        SceneManager.LoadScene(0);
    }

    // Exits the game
    public void ExitGame() {
        isInWinScreen = false;
        Application.Quit();
    }
}
