using UnityEngine;
using System.Collections;

public class openGrate : MonoBehaviour {

    void OnMouseDown()
    {
        if (GameObject.Find("Hotbar").GetComponent<newInv>().hasShank() &&
            GameObject.Find("Hotbar").GetComponent<newInv>().showShank == true)
        {
            Debug.Log("Has shank, open grate");
            GameObject.Find("Slats").GetComponent<Renderer>().enabled = false;
            GameObject.Find("Slats").GetComponent<Collider>().enabled = false;
        }
        else
        {
            Debug.Log("No shank");
        }
    }
}
