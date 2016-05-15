using UnityEngine;
using System.Collections;

public class TriggerAnimationOnTrigger : MonoBehaviour
{
    public Animator animator;
    public string onTriggerEnterParameterName;
    public string onTriggerExitParameterName;
    public bool winState = false;

    void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
            if (animator == null)
            {
                Debug.LogError("No animator component on automatic door script!", gameObject);
            }
        }
        
    }

    void OnTriggerEnter()
    {
        if (onTriggerEnterParameterName != null)
        {
            animator.SetTrigger(onTriggerEnterParameterName);
            if (!winState)
            {
                GameObject.Find("UIManager").GetComponent<WinScript>().WalkOutsideTrigger();
                winState = true;
            }
        }
    }

    void OnTriggerExit()
    {
        if (onTriggerExitParameterName != null)
        {
            animator.SetTrigger(onTriggerExitParameterName);
        }
    }
}
