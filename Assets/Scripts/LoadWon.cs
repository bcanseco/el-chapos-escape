using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadWon : MonoBehaviour {


    void OnTriggerEnter()
    {
		LastPlayerSighting lastPlayerSighting = GameObject.FindGameObjectWithTag (Tags.LAST_PLAYER_SIGHTING).GetComponent<LastPlayerSighting> ();
		lastPlayerSighting.globalPlayerPosition = lastPlayerSighting.unknownPosition;
		GameObject[] cameras = GameObject.FindGameObjectsWithTag (Tags.CAMERA_DETECTION);

		foreach (GameObject cam in cameras) {
			cam.GetComponent<MeshCollider> ().enabled = false;
			Debug.Log ("removed");
		}

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        (GameObject.Find("FPSController").GetComponent("FirstPersonController") as MonoBehaviour).enabled = false;
        SceneManager.LoadScene(3);
    }
}
