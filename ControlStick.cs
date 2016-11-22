using UnityEngine;
using System.Collections;

public class ControlStick : MonoBehaviour {

//Sets the background image of the control stick map.
    public void setImage(Sprite s)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = s;
    }
}
