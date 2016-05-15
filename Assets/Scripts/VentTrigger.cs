using UnityEngine;
using System.Collections;

public class VentTrigger : MonoBehaviour {
    public void OnTriggerEnter() {
        GameObject.Find("FPSController").GetComponent<Crouch>().canUncrouch = false;
    }

    public void OnTriggerExit() {
        GameObject.Find("FPSController").GetComponent<Crouch>().canUncrouch = true;
    }
}