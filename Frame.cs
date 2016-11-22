using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Frame : MonoBehaviour {

    int[,] controlStickVal;
    int number;
    int type;
    bool isReceivingNewValue = false;
    GameObject inputFrame;

    public SpriteRenderer childRenderer;
    [SerializeField]
    private Color AColor = new Color();
    [SerializeField]
    private Color BColor = new Color();
    [SerializeField]
    private Color ZColor = new Color();
    [SerializeField]
    private Color RColor = new Color();
    [SerializeField]
    private Color CColor = new Color();

    [SerializeField]
    enum buttonType {A, B, X, L, Z, S, C, D, Stick}

    public void Init(int i)
    {
        number = i;
        transform.Find("NumberText").GetComponent<Text>().text = "" + i;
        
    }

    public void setType(int i)
    {
        type = i;
        setColor(i);

    }
    public int getFrameType()
    {
        return type;
    }
    void OnMouseUp()
    {
        GameObject.Find("ControllerBaseAndSticks").GetComponent<Run>().setActiveFrame(this);
        
    }
    private void setColor(int i)
    {
        Color c = gameObject.GetComponent<SpriteRenderer>().color;

        if (i == 0)
        {
            c = AColor;
            transform.Find("LetterText").GetComponent<Text>().text = "A";          
        }
        else if (i == 1)
        {
            c = BColor;
            transform.Find("LetterText").GetComponent<Text>().text = "B";
        }
        else if (i == 2)
        {
            c = ZColor;
            transform.Find("LetterText").GetComponent<Text>().text = "Z";
        }
        else if (i == 3)
        {
            c = RColor;
            transform.Find("LetterText").GetComponent<Text>().text = "R";
        }
        else if (i == 4)
        {
            c = CColor;
            transform.Find("LetterText").GetComponent<Text>().text = "C";
        }
        else if (i == 5)
        {
            c = RColor;
            transform.Find("LetterText").GetComponent<Text>().text = "D";
        }
        else if (i == 6)
        {
            c = RColor;
            transform.Find("LetterText").GetComponent<Text>().text = "X";
        }
        else if (i == 7)
        {
            c = RColor;
            transform.Find("LetterText").GetComponent<Text>().text = "S";
        }
        else if (i == 8)
        {
            c = RColor;
        }
        else
        {
            c = Color.white;
        }
        gameObject.GetComponent<SpriteRenderer>().color = c;
    }
    public void setChildColor(Color c)
    {
        childRenderer.color = c;
    }
    public SpriteRenderer getChildRenderer()
    {
        return childRenderer;
    }
}
