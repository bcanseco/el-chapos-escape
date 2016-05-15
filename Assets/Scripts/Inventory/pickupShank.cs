using UnityEngine;
using System.Collections;

public class pickupShank : MonoBehaviour {

    void OnMouseDown()
    {
        GameObject.Find("Hotbar").GetComponent<newInv>().getShank();
        GameObject.Find("ShankObj").GetComponent<Renderer>().enabled = false;
        Debug.Log("Shank added to inv");
    }

}
