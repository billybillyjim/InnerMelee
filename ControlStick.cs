using UnityEngine;
using System.Collections;

public class ControlStick : MonoBehaviour {

    public void setImage(Sprite s)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = s;
    }
}
