using UnityEngine;
using System.Collections.Generic;

public class MoveController : MonoBehaviour {

    [SerializeField]
    private GameObject AButton;
    [SerializeField]
    private GameObject BButton;
    [SerializeField]
    private GameObject XButton;
    [SerializeField]
    private GameObject YButton;
    [SerializeField]
    private GameObject RButton;
    [SerializeField]
    private GameObject LButton;
    [SerializeField]
    private GameObject ZButton;
    [SerializeField]
    private GameObject startButton;
    [SerializeField]
    private GameObject controlStick;
    [SerializeField]
    private GameObject cStick;
    [SerializeField]
    private GameObject DPad;
    private List<Color> colorList =  new List<Color>();
    private List<GameObject> buttonList = new List<GameObject>();
    private bool isMinimized;
    [SerializeField]
    private float minimizedX;
    [SerializeField]
    private float minimizedY;
    private Vector3 oldScale;
    private Vector3 oldPos;

    // Use this for initialization
    public void Init () {
        AButton = GameObject.Find("A Button");
        BButton = GameObject.Find("B Button");
        XButton = GameObject.Find("X Button");
        YButton = GameObject.Find("Y Button");
        ZButton = GameObject.Find("Z Button");
        RButton = GameObject.Find("R Button");
        LButton = GameObject.Find("L Button");
        startButton = GameObject.Find("Start");
        controlStick = GameObject.Find("Control Stick");
        cStick = GameObject.Find("C Stick");
        DPad = GameObject.Find("D Pad");
        addButtons();
        addColors();

    }
	
	// Update is called once per frame
	void Update () {
        if (!isMinimized)
        {
            controlStick.transform.localPosition = new Vector3(Input.GetAxis("Horizontal") / 2, -Input.GetAxis("Vertical") / 2, -1);
            cStick.transform.localPosition = new Vector3(Input.GetAxis("Axis6") / 2, -Input.GetAxis("Axis3") / 2, -1);
            if (Input.GetButton("A"))
            {
                AButton.GetComponent<SpriteRenderer>().color = Color.gray;
            }
            else if (Input.GetButtonUp("A"))
            {
                AButton.GetComponent<SpriteRenderer>().color = colorList[0];
            }
            if (Input.GetButton("B"))
            {
                BButton.GetComponent<SpriteRenderer>().color = Color.gray;
            }
            else if (Input.GetButtonUp("B"))
            {
                BButton.GetComponent<SpriteRenderer>().color = colorList[1];
            }
            if (Input.GetButton("R"))
            {
                RButton.GetComponent<SpriteRenderer>().color = Color.gray;
            }
            else if (Input.GetButtonUp("R"))
            {
                RButton.GetComponent<SpriteRenderer>().color = colorList[4];
            }
            if (Input.GetButton("L"))
            {
                LButton.GetComponent<SpriteRenderer>().color = Color.gray;
            }
            else if (Input.GetButtonUp("L"))
            {
                LButton.GetComponent<SpriteRenderer>().color = colorList[5];
            }
            if (Input.GetButton("X"))
            {
                XButton.GetComponent<SpriteRenderer>().color = Color.gray;
            }
            else if (Input.GetButtonUp("X"))
            {
                XButton.GetComponent<SpriteRenderer>().color = colorList[5];
            }
            if (Input.GetButton("Z"))
            {
                ZButton.GetComponent<SpriteRenderer>().color = Color.gray;
            }
            else if (Input.GetButtonUp("Z"))
            {
                ZButton.GetComponent<SpriteRenderer>().color = colorList[4];
            }
            if (Input.GetButton("Start"))
            {
                startButton.GetComponent<SpriteRenderer>().color = Color.gray;
            }
            else if (Input.GetButtonUp("Start"))
            {
                startButton.GetComponent<SpriteRenderer>().color = colorList[7];
            }
        }
    }
    private void addButtons()
    {
        buttonList.Add(AButton);
        buttonList.Add(BButton);
        buttonList.Add(RButton);
        buttonList.Add(LButton);
        buttonList.Add(ZButton);
        buttonList.Add(XButton);
        buttonList.Add(YButton);
        buttonList.Add(startButton);
        
    }

    private void addColors()
    {
        foreach(GameObject g in buttonList)
        {
            colorList.Add(g.GetComponent<SpriteRenderer>().color);
        }
    }
    public void minimize()
    {
        isMinimized = true;
        oldScale = transform.localScale;
        oldPos = transform.position;
        transform.localScale = new Vector3(.1f, .1f, .1f);
        transform.position = new Vector3(minimizedX, minimizedY);

    }
    public void maximize()
    {
        isMinimized = false;
        transform.localScale = oldScale;
        transform.position = oldPos;
    }
}
