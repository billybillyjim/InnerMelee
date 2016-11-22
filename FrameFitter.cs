using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class FrameFitter : MonoBehaviour
{

    [SerializeField]
    private GameObject frame;
    [SerializeField]
    private List<GameObject> frameList = new List<GameObject>();
    [SerializeField]
    private Vector3 lastFrameLocation;
    [SerializeField]
    private Vector3 startLocation;
    [SerializeField]
    private float width;
    [SerializeField]
    public Vector3 scrollLocation;
    [SerializeField]
    private Scrollbar scrollbar;

    private float w;

    // Use this for initialization
    void Start()
    {
        frame = (GameObject)Resources.Load("Squares/FrameButton") as GameObject;
        w = frame.GetComponent<SpriteRenderer>().bounds.size.x;
        lastFrameLocation = startLocation;
    }

    public void addFrame()
    {
        GameObject newFrame = Instantiate(frame, lastFrameLocation + frame.transform.right + new Vector3(transform.position.x,0), Quaternion.identity) as GameObject;
        newFrame.transform.SetParent(gameObject.GetComponent<Transform>());
        newFrame.GetComponent<Frame>().Init(frameList.Count + 1);        
        lastFrameLocation += new Vector3(w, 0, 0);
        //scrollbar.size /= 1.1f;
        frameList.Add(newFrame);
    }

    public void colorFrame(GameObject frame, Color c)
    {
        frame.GetComponent<Frame>().setChildColor(c);        
    }

    public void addTenFrames()
    {
        for(int i = 0; i < 10; i++)
        {
            addFrame();
        }
    }
    public void deleteFrame()
    {
        if(frameList.Count > 0)
        {
            GameObject f = frameList[frameList.Count - 1];
            frameList.RemoveAt(frameList.Count - 1);
            lastFrameLocation -= new Vector3(w, 0, 0);
            Destroy(f);
        }
        
    }
    public void deleteTenFrames()
    {
        for (int i = 0; i < 10; i++)
        {
            deleteFrame();
        }
    }
    public void clearFramesColor()
    {
        foreach(GameObject f in frameList)
        {
            f.GetComponent<Frame>().getChildRenderer().color = Color.white;
        }
    }

    public float getFrameWidth()
    {
        return frame.transform.right.x;
    }
    public List<GameObject> getFrameList()
    {
        return frameList;
    }

}

