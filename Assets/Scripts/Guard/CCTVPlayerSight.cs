using UnityEngine;
using System.Collections;

/// <summary>
/// Anthony
/// 
/// Class that checks if the player is in sight through the camera's eyes
/// </summary>
public class CCTVPlayerSight : MonoBehaviour {

	private GameObject player;
	private LastPlayerSighting lastPlayerSighting;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag (Tags.PLAYER);
		lastPlayerSighting = GameObject.FindGameObjectWithTag (Tags.LAST_PLAYER_SIGHTING).GetComponent<LastPlayerSighting> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider collidingObject){
		// check if the colliding object is the player
		if (collidingObject.gameObject != player) {
			return;
		}


		// get the pos of the player to check if it is within the cone radius
		Vector3 playerPos = player.transform.position - transform.position;

		RaycastHit hit;
		// make sure that the player is within the camera view
		if (Physics.Raycast (transform.position, playerPos, out hit)) {
			if (hit.collider.gameObject == player) { // make sure the object is the player
				// set the position of the player to all guards
				lastPlayerSighting.globalPlayerPosition = player.transform.position;
			}
		}
	}
}
