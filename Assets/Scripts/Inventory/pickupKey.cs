using UnityEngine;
using System.Collections;

public class pickupKey : MonoBehaviour {

    void OnMouseDown()
    {
        GameObject.Find("Hotbar").GetComponent<newInv>().getKey();
        GameObject.Find("KeyObj").GetComponent<Renderer>().enabled = false;
        Debug.Log("Key added to inv");
    }

}
