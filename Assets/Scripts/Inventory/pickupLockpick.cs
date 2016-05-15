using UnityEngine;
using System.Collections;

public class pickupLockpick : MonoBehaviour {

	void OnMouseDown () {
        GameObject.Find("Hotbar").GetComponent<newInv>().getLockpick();
        GameObject.Find("LockpickObj").GetComponent<Renderer>().enabled = false;
        Debug.Log("Lockpick added to inv");
    }

}
