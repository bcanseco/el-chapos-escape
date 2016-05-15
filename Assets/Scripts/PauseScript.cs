using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PauseScript : MonoBehaviour {

	public GameObject pauseScreen;

	public Canvas optionMenu;
	public Canvas returnMenu;
	public Canvas quitMenu;

	public Button resume;
	public Button options;
	public Button titleScreen;
	public Button exit;

	public Slider volumeSlider;

	public Toggle muteToggle;

	public bool isPaused;

	// Use this for initialization
	void Start() {
		isPaused = false;

		// Get all components
		optionMenu = optionMenu.GetComponent<Canvas>();
		returnMenu = returnMenu.GetComponent<Canvas>();
		quitMenu = quitMenu.GetComponent<Canvas>();
		resume = resume.GetComponent<Button>();
		options = options.GetComponent<Button>();
		titleScreen = titleScreen.GetComponent<Button>();
		exit = exit.GetComponent<Button>();
		volumeSlider = volumeSlider.GetComponent<Slider>();
		muteToggle = muteToggle.GetComponent<Toggle>();

		// have option and exit menu disables by default
		optionMenu.enabled = false;
		returnMenu.enabled = false;
		quitMenu.enabled = false;

		// set preferences
		AudioListener.volume = PlayerPrefs.GetFloat("Master Volume Level");
		volumeSlider.normalizedValue = PlayerPrefs.GetFloat("Master Volume Level");
		if (PlayerPrefs.GetString("Master Volume Mute").Equals("true")) {
			AudioListener.volume = 0.0f;
			muteToggle.isOn = true;
			volumeSlider.interactable = false;
		}
	}
	
	// Update is called once per frame
	void Update() {
	    if (GameObject.Find("UIManager").GetComponent<WinScript>().isInWinScreen == true) return;

		if (isPaused) {
			PauseGame(true);
		} else {
			PauseGame(false);
		}

		if (Input.GetButtonDown("Cancel")) {
			SwitchPause();
		}
	}

	void PauseGame(bool state) {
		if (state) {
            //Cursor.lockState = CursorLockMode.Confined;
			Cursor.visible = true;
			(GameObject.Find("FPSController").GetComponent("FirstPersonController") as MonoBehaviour).enabled = false;
			pauseScreen.SetActive(true);
			Time.timeScale = 0.0f;
		} else {
			(GameObject.Find("FPSController").GetComponent("FirstPersonController") as MonoBehaviour).enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
			Time.timeScale = 1.0f;
		}
		pauseScreen.SetActive(state);
	}

	public void SwitchPause() {
		if (isPaused) {
			isPaused = false;
		} else {
			isPaused = true;
		}
	}

	// Brings up the option menu
	public void OnOptionPress() {
		optionMenu.enabled = true;
		resume.gameObject.SetActive(false);
		options.gameObject.SetActive(false);
		titleScreen.gameObject.SetActive(false);
		exit.gameObject.SetActive(false);
	}

	// Closes the submenus
	public void OnBackPress() {
		if (optionMenu.enabled)
			optionMenu.enabled = false;
		if (returnMenu.enabled)
			returnMenu.enabled = false;
		if (quitMenu.enabled)
			quitMenu.enabled = false;
		resume.gameObject.SetActive(true);
		options.gameObject.SetActive(true);
		titleScreen.gameObject.SetActive(true);
		exit.gameObject.SetActive(true);
	}

	// bring up return to title screen prompt
	public void OnReturnPress() {
		returnMenu.enabled = true;
		resume.gameObject.SetActive(false);
		options.gameObject.SetActive(false);
		titleScreen.gameObject.SetActive(false);
		exit.gameObject.SetActive(false);
	}

	// Brings up the exit menu/prompt
	public void OnExitPress() {
		quitMenu.enabled = true;
		resume.gameObject.SetActive(false);
		options.gameObject.SetActive(false);
		titleScreen.gameObject.SetActive(false);
		exit.gameObject.SetActive(false);
	}

	// Mutes or unmutes the game audio
	public void OnMuteToggle() {
		if (muteToggle.isOn) {
			PlayerPrefs.SetString("Master Volume Mute", "true");
			AudioListener.volume = 0.0f;
			volumeSlider.interactable = false;
		}
		if (!muteToggle.isOn) {
			PlayerPrefs.SetString("Master Volume Mute", "false");
			AudioListener.volume = 1.0f;
			volumeSlider.interactable = true;
		}
		PlayerPrefs.Save();
	}

	// Adjusts the volume based on user input
	public void OnSliderChange() {
		PlayerPrefs.SetFloat("Master Volume Level", volumeSlider.normalizedValue);
		AudioListener.volume = volumeSlider.normalizedValue;
	}

	// return to title screen
	public void LoadTitleScreen() {
		// Save preferences when the next scene is loaded
		PlayerPrefs.Save();
		SceneManager.LoadScene(0);
	}

	// Exits the game
	public void ExitGame() {
		Application.Quit();
	}
}
