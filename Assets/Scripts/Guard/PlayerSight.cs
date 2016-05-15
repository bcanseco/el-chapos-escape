using UnityEngine;
using System.Collections;

/// <summary>
/// Anthony
/// 
/// Class that checks if the player is in sight and applies the appropriate actions.
/// </summary>
public class PlayerSight : MonoBehaviour {

	/// <summary>
	/// Feild of View angle of the guard's vision.
	/// </summary>
	public float fovAngle = 160.0f;

	/// <summary>
	/// Has the player been spotted?
	/// </summary>
	public bool playerInSight = false;

	/// <summary>
	/// Track the last sighting of the player found by this guard.
	/// </summary>
	public Vector3 localLastSightingPos;

	/// <summary>
	/// The default coordinates when a player is not being tracked.
	/// </summary>
	private LastPlayerSighting lastPlayerSighting;

	/// <summary>
	/// Last position of the player. Updated on each frame.
	/// </summary>
	private Vector3 previousSighting;


	/// <summary>
	/// Distance at which we will see the player. 
	/// </summary>
	private SphereCollider sphereCol;

	/// <summary>
	/// El Chapo xD 
	/// </summary>
	private GameObject player;

	// Use this for initialization
	void Start () {
		sphereCol = GetComponent<SphereCollider> ();
		lastPlayerSighting = GameObject.FindGameObjectWithTag (Tags.LAST_PLAYER_SIGHTING).GetComponent<LastPlayerSighting>();
		player = GameObject.FindGameObjectWithTag (Tags.PLAYER);
		localLastSightingPos = lastPlayerSighting.unknownPosition;
		previousSighting = lastPlayerSighting.unknownPosition;
	}
	
	// Update is called once per frame
	void Update () {
		if (lastPlayerSighting.globalPlayerPosition != previousSighting) {
			localLastSightingPos = lastPlayerSighting.globalPlayerPosition;
		}

		// update the sighting of the player
		previousSighting = lastPlayerSighting.globalPlayerPosition;

	}

	void OnTriggerStay(Collider collidingObject){
		// check if the colliding object is the player
		if (collidingObject.gameObject != player) {
			return;
		}

		// TODO Get the direction and angle of the guard and player
		// check if the player is in the FOV
		playerInSight = false;

		Vector3 direction = collidingObject.transform.position - transform.position;
		float angle = Vector3.Angle(direction, transform.forward);

		// make sure that the player is within the guard FOV
		if (angle < (fovAngle / 2.0)) { 
			RaycastHit hit;
			if (Physics.Raycast (transform.position + transform.up, direction.normalized, out hit, sphereCol.radius)) {
				if (hit.collider.gameObject == player) {
					playerInSight = true;

					// update this guard's personal sighting
					localLastSightingPos = player.transform.position;

					// set the position of the player to all guards
					lastPlayerSighting.globalPlayerPosition = player.transform.position;
				}
			}
		}
	}

	void OnTriggerExit(Collider collidingObject) {
		if (collidingObject.gameObject == player) {
			playerInSight = false;
		}
	}
}
