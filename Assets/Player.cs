using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {
    public float CameraSpeed = 0.01f;
    public GameObject StartCameraPoint;
    public GameObject GameCameraPoint;
    public Camera camera;
    public GameObject Model;
    public GameObject Button;
    public GameObject Button2;
    public GameObject ResetButton;
    public GameObject TimeText;
    public float LoseLineSide = -10.0f;
    public AudioClip OnGameVoice;
    public AudioClip StartVoice;
    public AudioClip LoseVoice;
    public AudioClip WinVoice;

    private int Flag = 0;
    private UnityChan_Control unitychan;
    private bool ButtonFlag = false;
    private AudioSource audio;
    private Text resettext;
    private Text timetext;
    private float starttime;
	// Use this for initialization
	void Start () {
        camera.transform.position = StartCameraPoint.transform.position;
        unitychan = Model.GetComponent<UnityChan_Control>();
        ResetButton.SetActive(false);
        resettext = ResetButton.transform.Find("Text").gameObject.GetComponent<Text>();
        TimeText.SetActive(false);
        timetext = TimeText.GetComponent<Text>();
        audio = GetComponent<AudioSource>();
        audio.clip = OnGameVoice;
        audio.Play();
	}
	
	// Update is called once per frame
	void Update () {
        switch (Flag)
        {
            case 0:
                Init();
                break;
            case 1:
                Set();
                break;
            case 2:
                Run();
                break;
            case 3://Lose
                Lose();
                break;
            case 4://Win
                Win();
                break;
            case 5:
                Reset();
                break;
            default:
                break;
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
	}

    private void Init()
    {
        Flag++;
    }

    private void Set()
    {
        if (ButtonFlag)
        {
            camera.transform.position = GameCameraPoint.transform.position;
            unitychan.SetFlag();
            Flag++;

            Button.SetActive(false);
            Button2.SetActive(false);
            ButtonFlag = false;
            audio.clip = StartVoice;
            audio.Play();
            starttime = Time.time;
        }
    }

    private void Run()
    {
        Vector3 v = transform.position;
        v.x += CameraSpeed;
        transform.position = v;
        if (Model.transform.position.x-transform.position.x<LoseLineSide)
        {
            unitychan.SetFlag();
        }
        if (unitychan.GetFlag() == 3)
        {
            Flag = 3;
        }
        if (unitychan.GetFlag() == 4)
        {
            Flag = 4;
        }
    }

    private void Lose()
    {
        camera.transform.position = StartCameraPoint.transform.position;
        transform.position.Set(0, 0, 0);
        Flag = 5;
        ResetButton.SetActive(true);
        TimeText.SetActive(true);
        float t = Time.time - starttime;
        timetext.text = "記録:" + t.ToString("f1") + "秒";
        resettext.text = "やり直し";
        audio.clip = LoseVoice;
        audio.Play();
    }

    private void Win()
    {
        camera.transform.position = StartCameraPoint.transform.position;
        transform.position.Set(0, 0, 0);
        Flag = 5;
        ResetButton.SetActive(true);
        TimeText.SetActive(true);
        float t = Time.time - starttime;
        timetext.text = "記録:" + t.ToString("f1") + "秒";
        resettext.text = "もう一回";
        audio.clip = WinVoice;
        audio.Play();
    }

    private void Reset()
    {
        if (ButtonFlag)
        {
            Application.LoadLevel(Application.loadedLevelName);
        }
    }



    public void ButtonClick()
    {
        ButtonFlag = true;
    }

    public void LevelUPButtonClick()
    {
        unitychan.SetRunFlag(true);
        ButtonFlag = true;
    }
}
