using UnityEngine;
using System.Collections;

public class openGrate2 : MonoBehaviour {

    void OnMouseDown()
    {
        if (GameObject.Find("Hotbar").GetComponent<newInv>().hasShank() &&
            GameObject.Find("Hotbar").GetComponent<newInv>().showShank == true)
        {
            Debug.Log("Has shank, open grate");
            GameObject.Find("Slats2").GetComponent<Renderer>().enabled = false;
            GameObject.Find("Slats2").GetComponent<Collider>().enabled = false;
        }
        else
        {
            Debug.Log("No shank");
        }
    }
}
