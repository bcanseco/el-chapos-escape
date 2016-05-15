using UnityEngine;
using System.Collections;

public class SoundFX : MonoBehaviour {

	CharacterController cc;

	// Use this for initialization
	void Start () {
		cc = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (cc.isGrounded == true && cc.velocity.magnitude > 2) {
			GetComponent<AudioSource>().Play ();
		} 
	}
}
