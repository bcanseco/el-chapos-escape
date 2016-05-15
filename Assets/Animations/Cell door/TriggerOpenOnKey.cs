using UnityEngine;
using System.Collections;

public class TriggerOpenOnKey : MonoBehaviour {

    public Animator animator;
    public string onTriggerEnterParameterName;

    void Start() {
        if (animator == null) {
            animator = GetComponent<Animator>();
            if (animator == null) {
                Debug.LogError("No animator component on cell door script!", gameObject);
            }
        }

    }

    void OnMouseDown() {
        if (GameObject.Find("Hotbar").GetComponent<newInv>().hasKey() &&
            GameObject.Find("Hotbar").GetComponent<newInv>().showKey == true) {
            if (onTriggerEnterParameterName != null) {
                animator.SetTrigger(onTriggerEnterParameterName);
            }
        }
    }
}
