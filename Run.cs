using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Run : MonoBehaviour {

    [SerializeField]
    private Frame activeFrame;
    [SerializeField]
    private FrameFitter ff;
    [SerializeField]
    private GameObject cursor;
    [SerializeField]
    private Vector3 cursorSpawnLocation;
    [SerializeField]
    private GameObject CStickMap;
    [SerializeField]
    private GameObject CStickDot;
    [SerializeField]
    private List<GameObject> pastSticks = new List<GameObject>();
    [SerializeField]
    private int currentFrame;
    private bool isPlaying;
    private bool isAutoPlaying;
    private bool isPlayOnFirstPress;
    private float currentTime;
    private float frameDuration = 1.0f / 60.0f;
    private float timer;
    
    void Start()
    {
        CStickMap = GameObject.Find("ppaN94b");
        CStickDot = GameObject.Find("Dot");
        CStickDot.GetComponent<SpriteRenderer>().sortingOrder = 2;

        cursor = (GameObject) Resources.Load("Cursor", typeof (GameObject));
        cursor = (GameObject) Instantiate(cursor, cursorSpawnLocation, Quaternion.identity);

        gameObject.GetComponent<MoveController>().Init();

        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 300;

    }

    void Update()
    {
       
        CStickDot.transform.localPosition = roundToValidInput(Input.GetAxis("ControlStickX") * 1.0f, Input.GetAxis("ControlStickY") * 1.0f);

        if(isPlayOnFirstPress && !isPlaying)
        {
            if(Input.GetButtonDown("A") || Input.GetButtonDown("B") || Input.GetButtonDown("X"))
            {
                PlayAtFPS();
            }
        }
        if (isPlaying)
        {
            timer += Time.deltaTime;
            if(timer >= frameDuration)
            {
                Play();
                timer = 0;
            }

        }
        if (Input.GetButton("A"))
        {
            if(ff.getFrameList().Count > 0 && currentFrame < ff.getFrameList().Count)
            {
                ff.colorFrame(ff.getFrameList()[currentFrame], Color.blue);
            }
            
        }
        else if (Input.GetButton("B"))
            {
            if (ff.getFrameList().Count > 0 && currentFrame < ff.getFrameList().Count)
            {
                ff.colorFrame(ff.getFrameList()[currentFrame], Color.red);
            }

        }
        else if (Input.GetButton("X"))
        {
            if (ff.getFrameList().Count > 0 && currentFrame < ff.getFrameList().Count)
            {
                ff.colorFrame(ff.getFrameList()[currentFrame], Color.gray);
            }

        }
        else if (Input.GetButton("L") && currentFrame < ff.getFrameList().Count)
        {
            if (ff.getFrameList().Count > 0 && currentFrame < ff.getFrameList().Count)
            {
                ff.colorFrame(ff.getFrameList()[currentFrame], Color.black);
            }
        }
    }

    public void PlayAtFPS()
    {   
        currentFrame = 0;
        timer = 0;
        
        foreach(GameObject o in pastSticks)
        {
            Destroy(o);

        }
        pastSticks.Clear();
        resetPosition();
        ff.clearFramesColor();
        isPlaying = true;
    }
	public void setFrame(int i)
    {
        if(activeFrame != null)
        {
            activeFrame.setType(i);
        }
        
    }
    public void setActiveFrame(Frame f)
    {
        if(activeFrame != null && activeFrame.getFrameType() == 0)
        {
            activeFrame.GetComponent<SpriteRenderer>().color = Color.white;
        }
        
        f.GetComponent<SpriteRenderer>().color = Color.black;
        activeFrame = f;       
    }
    public void advanceFrame()
    {
        cursor.transform.Translate(new Vector3(ff.getFrameWidth() * .67f, 0));
        GameObject o;
        o = (GameObject) Instantiate(CStickDot, CStickDot.transform.position, Quaternion.identity);

        pastSticks.Add(o);
        if(currentFrame != ff.getFrameList().Count)
        {
            currentFrame++;
        }
        
    }
    public void resetPosition()
    {
        cursor.transform.position = cursorSpawnLocation;
    }

    public void Play()
    {
        if (currentFrame < ff.getFrameList().Count)
        {
            advanceFrame();
        }
        else
        {
            isPlaying = false;
            setDotColors();
            if (isAutoPlaying)
            {
                PlayAtFPS();
            }
        }
    }
    public void Stop()
    {
        resetPosition();
        isPlaying = false;
    }
    public void Pause()
    {
        isPlaying = !isPlaying;
    }

    private Vector3 roundToValidInput(float x, float y)
    {

        x = Mathf.Round(x * 225f) / 225f;
        y = Mathf.Round(y * 225f) / 225f;
        
        if(x >= -.275f && x <= .275f)
        {
            x = 0f;
        }
        if(y >= -.275f && y <= .275f)
        {
            y = 0f;
        }

        return new Vector3(x, y, -1);
    }
    private void setDotColors()
    {
        float c = pastSticks.Count;
        int count = 0;
        foreach(GameObject o in pastSticks)
        {
            Color col = o.GetComponent<SpriteRenderer>().color;

            col.r = (count * (255f/c) / 255);
            col.g = (count * (255f/c) / 255);
            col.b = (count * (255f/c) / 255);

            o.GetComponent<SpriteRenderer>().color = col;
            count++;

        }
    }

    public void setPlaySpeed(float speed)
    {
        frameDuration = 1.0f / speed;
    }
    public void toggleAutoPlay()
    {
        isAutoPlaying = !isAutoPlaying;
    }
    public void togglePlayOnFirstPress()
    {
        isPlayOnFirstPress = !isPlayOnFirstPress;
    }
}
