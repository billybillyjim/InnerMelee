using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

    public Text t1;
    public Text t2;
    public Text t3;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {

        t1.text = Input.GetAxis("Horizontal") + ", " + Input.GetAxis("Vertical") + ", " + Input.GetAxis("Axis3") + ", "
            + Input.GetAxis("Axis4") + ", " + Input.GetAxis("Axis5") + ", " + Input.GetAxis("Axis6") + ", "
            + Input.GetAxis("Axis7") + ", " + Input.GetButton("A");
        t2.text = Input.GetAxis("Axis8") + ", " + Input.GetAxis("Axis9") + ", " + Input.GetAxis("Axis10") + ", "
            + Input.GetAxis("Axis11") + ", " + Input.GetAxis("Axis12") + ", " + Input.GetAxis("Axis13") + ", "
            + Input.GetAxis("Axis14");
        /*  t2.text = Input.GetAxis("Axis15") + ", " + Input.GetAxis("Axis16") + ", " + Input.GetAxis("Axis17") + ", "
            + Input.GetAxis("Axis18") + ", " + Input.GetAxis("Axis19") + ", " + Input.GetAxis("Axis20") + ", "
            + Input.GetAxis("Axis21");
            */
    }
}
