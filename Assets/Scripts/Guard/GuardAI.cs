using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


/// <summary>
/// Anthony
/// 
/// Brains of the guard. Control what actions to do based on the state of the game.
/// </summary>
public class GuardAI : MonoBehaviour {

	public float walkSpeed = 2f;
	public float runSpeed = 5f;
	public float chaseWaitTime = 5f;
	public float patrolWaitTime = 1f;

	public Transform[] waypoints;

	private PlayerSight playerSight;
	private NavMeshAgent nav;
	private LastPlayerSighting lastPlayerSighting;
	private float chaseTimer;
	private float patrolTimer;
	private int wayPointIndex;
	private Animation animation;



	// Use this for initialization
	void Start () {
		playerSight = GetComponent<PlayerSight> ();
		nav = GetComponent<NavMeshAgent> ();
		lastPlayerSighting = GameObject.FindGameObjectWithTag (Tags.LAST_PLAYER_SIGHTING).GetComponent<LastPlayerSighting> ();
		animation = GetComponent<Animation> ();
		animation.wrapMode = WrapMode.Loop;
	}
	
	// Update is called once per frame
	void Update () {

		if (Vector3.Distance(transform.position, lastPlayerSighting.globalPlayerPosition) < 3f) { // player has been caught
			SceneManager.LoadScene(2);  // start the caught scene
			// TODO create a caught scene
		} else if (playerSight.localLastSightingPos != lastPlayerSighting.unknownPosition) { // chase after the player
			Chasing ();
		} else { // walk the patrol route
			Patrolling ();
		}
	}

	/// <summary>
	/// Actions to do when chasing. Run to the last sighting position of the player.
	/// </summary>
	void Chasing(){
		Vector3 sightingDiff = playerSight.localLastSightingPos - transform.position;
		if (sightingDiff.sqrMagnitude > 4f) {
			nav.destination = playerSight.localLastSightingPos;
		}

		nav.speed = runSpeed;

		if (nav.remainingDistance < nav.stoppingDistance || nav.remainingDistance != 0) {
			chaseTimer += Time.deltaTime;

			if (chaseTimer > chaseWaitTime) {
				lastPlayerSighting.globalPlayerPosition = lastPlayerSighting.unknownPosition;
				playerSight.localLastSightingPos = lastPlayerSighting.unknownPosition;
				chaseTimer = 0f;
			}
		} else {
			chaseTimer = 0f;
		}
	}

	/// <summary>
	/// Actions to do when patrolling. Set the next destination of the waypoints
	/// </summary>
	void Patrolling() {
		nav.speed = walkSpeed;

		if (nav.destination == lastPlayerSighting.unknownPosition || nav.remainingDistance < nav.stoppingDistance) {
			patrolTimer += Time.deltaTime;

			if (patrolTimer >= patrolWaitTime) {
				int oldIndex = wayPointIndex;
				while (wayPointIndex == oldIndex) {
					wayPointIndex = Random.Range (0, waypoints.Length - 1);
				}

				patrolTimer = 0f;
			}
		} else {
			patrolTimer = 0f;
		}

		nav.destination = waypoints [wayPointIndex].position;
	}
}
