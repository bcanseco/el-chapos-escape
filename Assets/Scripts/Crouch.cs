using UnityEngine;
using System.Collections;

/* Added a condition in FirstPersonController.cs:
 * if (transform.localScale.y >= 1.9F)
   {
       PlayLandingSound();
   }
 * to avoid playing a landing sound when crouching.
 */

public class Crouch : MonoBehaviour {
    public bool crouch;
    public bool canUncrouch = true;

    public void Update() {
        if (Input.GetKey(KeyCode.LeftControl)) {
            if (!crouch) {
                crouch = true;
                transform.localScale -= new Vector3(0.75F, 1.0F, 0.75F);
            }

        } else {
            if (crouch && canUncrouch) {
                crouch = false;
                transform.localScale += new Vector3(0.75F, 1.0F, 0.75F);
            }
        }
    }
}