using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class newInv : MonoBehaviour {

    //Start with no items
    public bool lockpick = false;
    public bool shank = false;
    public bool key = false;

    //Holding up item or not
    public bool showLockpick = false;
    public bool showShank = false;
    public bool showKey = false;

    void Start() {
        //Initially hide all items from toolbar
        GameObject sprite1 = GameObject.Find("Lockpick_slot_sprite");
        sprite1.GetComponent<CanvasRenderer>().SetAlpha(0);

        GameObject sprite2 = GameObject.Find("Shank_slot_sprite");
        sprite2.GetComponent<CanvasRenderer>().SetAlpha(0);

        GameObject sprite3 = GameObject.Find("Key_slot_sprite");
        sprite3.GetComponent<CanvasRenderer>().SetAlpha(0);

        //Initially hide all arms
        GameObject arms1 = GameObject.Find("LockpickArm");
        arms1.GetComponent<Renderer>().enabled = false;
        GameObject hand1 = GameObject.Find("LockpickHeld");
        hand1.GetComponent<Renderer>().enabled = false;

        GameObject arms2 = GameObject.Find("KeyArm");
        arms2.GetComponent<Renderer>().enabled = false;
        GameObject hand2 = GameObject.Find("KeyHeld");
        hand2.GetComponent<Renderer>().enabled = false;

        GameObject arms3 = GameObject.Find("ShankArm");
        arms3.GetComponent<Renderer>().enabled = false;
        GameObject hand3 = GameObject.Find("ShankHeld");
        hand3.GetComponent<Renderer>().enabled = false;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (lockpick)   //Has found lockpick
            {
                if (!showLockpick)  //Not holding lockpick
                {
                    showLockpick = true;
                    showShank = false;
                    showKey = false;
                }
                else     //Already holding lockpick
                {
                    showLockpick = false;
                    showShank = false;
                    showKey = false;
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (shank)   //Has found shank
            {
                if (!showShank)  //Not holding shank
                {
                    showLockpick = false;
                    showShank = true;
                    showKey = false;
                }
                else     //Already holding shank
                {
                    showLockpick = false;
                    showShank = false;
                    showKey = false;
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (key)   //Has found key
            {
                if (!showKey)  //Not holding key
                {
                    showLockpick = false;
                    showShank = false;
                    showKey = true;
                }
                else     //Already holding key
                {
                    showLockpick = false;
                    showShank = false;
                    showKey = false;
                }
            }
        }
        //Show or hide arms depending on previously set bools
        if (showLockpick)
        {
            Debug.Log("Show Lockpick");
            GameObject arms1 = GameObject.Find("LockpickArm");
            arms1.GetComponent<Renderer>().enabled = true;
            GameObject hand1 = GameObject.Find("LockpickHeld");
            hand1.GetComponent<Renderer>().enabled = true;

            GameObject arms2 = GameObject.Find("KeyArm");
            arms2.GetComponent<Renderer>().enabled = false;
            GameObject hand2 = GameObject.Find("KeyHeld");
            hand2.GetComponent<Renderer>().enabled = false;

            GameObject arms3 = GameObject.Find("ShankArm");
            arms3.GetComponent<Renderer>().enabled = false;
            GameObject hand3 = GameObject.Find("ShankHeld");
            hand3.GetComponent<Renderer>().enabled = false;
        }
        else if (showKey)
        {
            Debug.Log("Show Key");
            GameObject arms1 = GameObject.Find("LockpickArm");
            arms1.GetComponent<Renderer>().enabled = false;
            GameObject hand1 = GameObject.Find("LockpickHeld");
            hand1.GetComponent<Renderer>().enabled = false;

            GameObject arms2 = GameObject.Find("KeyArm");
            arms2.GetComponent<Renderer>().enabled = true;
            GameObject hand2 = GameObject.Find("KeyHeld");
            hand2.GetComponent<Renderer>().enabled = true;

            GameObject arms3 = GameObject.Find("ShankArm");
            arms3.GetComponent<Renderer>().enabled = false;
            GameObject hand3 = GameObject.Find("ShankHeld");
            hand3.GetComponent<Renderer>().enabled = false;
        }
        else if (showShank)
        {
            Debug.Log("Show Shank");
            GameObject arms1 = GameObject.Find("LockpickArm");
            arms1.GetComponent<Renderer>().enabled = false;
            GameObject hand1 = GameObject.Find("LockpickHeld");
            hand1.GetComponent<Renderer>().enabled = false;

            GameObject arms2 = GameObject.Find("KeyArm");
            arms2.GetComponent<Renderer>().enabled = false;
            GameObject hand2 = GameObject.Find("KeyHeld");
            hand2.GetComponent<Renderer>().enabled = false;

            GameObject arms3 = GameObject.Find("ShankArm");
            arms3.GetComponent<Renderer>().enabled = true;
            GameObject hand3 = GameObject.Find("ShankHeld");
            hand3.GetComponent<Renderer>().enabled = true;
        }
        else
        {
            //Debug.Log("Show None");
            GameObject arms1 = GameObject.Find("LockpickArm");
            arms1.GetComponent<Renderer>().enabled = false;
            GameObject hand1 = GameObject.Find("LockpickHeld");
            hand1.GetComponent<Renderer>().enabled = false;

            GameObject arms2 = GameObject.Find("KeyArm");
            arms2.GetComponent<Renderer>().enabled = false;
            GameObject hand2 = GameObject.Find("KeyHeld");
            hand2.GetComponent<Renderer>().enabled = false;

            GameObject arms3 = GameObject.Find("ShankArm");
            arms3.GetComponent<Renderer>().enabled = false;
            GameObject hand3 = GameObject.Find("ShankHeld");
            hand3.GetComponent<Renderer>().enabled = false;
        }
    }

    public void getLockpick()
    {
        lockpick = true;
        GameObject sprite = GameObject.Find("Lockpick_slot_sprite");
        sprite.GetComponent<CanvasRenderer>().SetAlpha(1);
        Debug.Log("Picked up lockpick");
    }

    public void getShank()
    {
        shank = true;
        GameObject sprite = GameObject.Find("Shank_slot_sprite");
        sprite.GetComponent<CanvasRenderer>().SetAlpha(1);
        Debug.Log("Picked up shank");
    }

    public void getKey()
    {
        key = true;
        GameObject sprite = GameObject.Find("Key_slot_sprite");
        sprite.GetComponent<CanvasRenderer>().SetAlpha(1);
        Debug.Log("Picked up key");
    }

    public bool hasKey()
    {
        if (key)
            return true;
        return false;
    }
    public bool hasLockpick()
    {
        if (lockpick)
            return true;
        return false;
    }

    public bool hasShank()
    {
        if (shank)
            return true;
        return false;
    }
}
