using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuScript : MonoBehaviour {

    public Canvas optionMenu;
    public Canvas quitMenu;

	public Camera creditsScreen;

    public Button playButton;
    public Button optionButton;
    public Button exitButton;
	public Button creditsButton;

    public Slider volumeSlider;

    public Toggle muteToggle;

	// Use this for initialization
	void Start() {
        // Get all components
        optionMenu = optionMenu.GetComponent<Canvas>();
        quitMenu = quitMenu.GetComponent<Canvas>();
		creditsScreen = creditsScreen.GetComponent<Camera>();
        playButton = playButton.GetComponent<Button>();
        optionButton = optionButton.GetComponent<Button>();
        exitButton = exitButton.GetComponent<Button>();
		creditsButton = creditsButton.GetComponent<Button>();
        volumeSlider = volumeSlider.GetComponent<Slider>();
        muteToggle = muteToggle.GetComponent<Toggle>();

        // have option and exit menu disabled by default
        optionMenu.enabled = false;
        quitMenu.enabled = false;

		// also have credits disabled
		creditsScreen.enabled = false;

		// start animation
		if (!gameObject.GetComponentInParent<Animation>().isPlaying)
			gameObject.GetComponentInParent<Animation>().Play();
        
        // Set preferences if they don't exist. Retrieve them if they do
        if (!PlayerPrefs.HasKey("Master Volume Mute")) {
            PlayerPrefs.SetString("Master Volume Mute", "false");
        } else {
            if (PlayerPrefs.GetString("Master Volume Mute").Equals("true")) {
                muteToggle.isOn = true;
                volumeSlider.interactable = false;
            }
            if (PlayerPrefs.GetString("Master Volume Mute").Equals("false")) {
                muteToggle.isOn = false;
                volumeSlider.interactable = true;
            }
        }
        if (!PlayerPrefs.HasKey("Master Volume Level")) {
            PlayerPrefs.SetFloat("Master Volume Level", 1.0f);
        } else {
            volumeSlider.normalizedValue = PlayerPrefs.GetFloat("Master Volume Level");
        }
    }

    // Brings up the option menu
    public void OnOptionPress() {
        optionMenu.enabled = true;
        playButton.gameObject.SetActive(false);
        optionButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
    }

    // Closes the option menu
    public void OnBackPress()
    {
        optionMenu.enabled = false;
        playButton.gameObject.SetActive(true);
        optionButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
    }

    // Brings up the exit menu/prompt
    public void OnExitPress() {
        quitMenu.enabled = true;
        playButton.gameObject.SetActive(false);
        optionButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
    }

    // Closes exit menu. Does not exit game
    public void OnNoPress() {
        quitMenu.enabled = false;
        playButton.gameObject.SetActive(true);
        optionButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
    }

	// Brings up credits screen
	public void OnCreditsPress() {
		creditsScreen.enabled = true;
	}

	// close credits screen
	public void OnCreditsBackPress() {
		creditsScreen.enabled = false;
	}

    // Mutes or unmutes the game audio
    public void OnMuteToggle() {
        if (muteToggle.isOn) {
            PlayerPrefs.SetString("Master Volume Mute", "true");
            volumeSlider.interactable = false;
        }
        if (!muteToggle.isOn) {
            PlayerPrefs.SetString("Master Volume Mute", "false");
            volumeSlider.interactable = true;
        }
        PlayerPrefs.Save();
    }

    // Adjusts the volume based on user input
    public void OnSliderChange() {
        PlayerPrefs.SetFloat("Master Volume Level", volumeSlider.normalizedValue);
    }

    // Begins level when user presses play by loading the next scene
    public void StartLevel() {
		// Save preferences when the next scene is loaded
		PlayerPrefs.Save();
        SceneManager.LoadScene(1);
    }

    // Exits the game
    public void ExitGame() {
        Application.Quit();
    }

}
