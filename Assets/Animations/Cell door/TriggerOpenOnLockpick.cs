using UnityEngine;
using System.Collections;

public class TriggerOpenOnLockpick : MonoBehaviour {

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

    void OnMouseDown()
    {
        if (GameObject.Find("Hotbar").GetComponent<newInv>().hasLockpick() &&
            GameObject.Find("Hotbar").GetComponent<newInv>().showLockpick == true)
        {
            if (onTriggerEnterParameterName != null) {
                animator.SetTrigger(onTriggerEnterParameterName);
            }
        }
    }
}
