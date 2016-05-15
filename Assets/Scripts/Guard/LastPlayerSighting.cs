using UnityEngine;
using System.Collections;

/// <summary>
/// Anthony
/// 
/// Class to track the sighting of the player and control music/lights when found.
/// </summary>
public class LastPlayerSighting : MonoBehaviour {

	/// <summary>
	/// The default coordinates when a player is not being tracked.
	/// </summary>
	public Vector3 unknownPosition = new Vector3(5000f, 5000f, 5000f);

	/// <summary>
	/// Store the position of the player when found.
	/// All guards reference this variable.
	/// </summary>
	public Vector3 globalPlayerPosition = new Vector3(5000f, 5000f, 5000f);

}
