using UnityEngine;
using System.Collections;

public class UnityChan_Control : MonoBehaviour {

    public bool runflag = false;
    public float walkingSpeed = 0.01f;
    public float runningSpeed = 0.05f;
    public float LoseLine = -5.0f;

    private Animator anime;
    private float speed;
    private int Flag = 0;
	// Use this for initialization
	void Start () {
        anime = GetComponent<Animator>();
        anime.SetBool("runflag", runflag);
        if (runflag)
        {
            speed = runningSpeed;
        }
        else
        {
            speed = walkingSpeed;
        }
        transform.Rotate(0, 90, 0);
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
                break;
            default:
                break;
        }
	}

    private void Init()
    {

    }

    private void Set()
    {
        transform.Rotate(0, -90, 0);
        anime.SetTrigger("start");
        SetFlag();
    }

    private void Run()
    {
        transform.position += transform.forward * speed;
        if (transform.position.y < LoseLine )
        {
            SetFlag();
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Vector3 v=transform.position;
            v.y += speed;
            transform.position = v;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (runflag)
            {
                speed = runningSpeed/2;
            }
            else
            {
                speed = walkingSpeed/2;
            }
        }
        else
        {
            if (runflag)
            {
                speed = runningSpeed;
            }
            else
            {
                speed = walkingSpeed;
            }
        }
    }

    private void Lose()
    {
        transform.position = Vector3.zero;
        transform.Rotate(0, 90, 0);
        anime.SetTrigger("lose");
        SetFlag(5);
    }

    private void Win()
    {
        transform.position = Vector3.zero;
        transform.Rotate(0, 90, 0);
        anime.SetTrigger("win");
        SetFlag(5);
    }

    public void SetFlag(int flag=-1)
    {
        if (flag == -1) Flag++;
        else Flag = flag;
    }

    public int GetFlag()
    {
        return Flag;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            SetFlag(4);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            SetFlag(3);
        }
    }

    public void SetRunFlag(bool flag)
    {
        runflag = flag;
        if (runflag)
        {
            speed = runningSpeed;
        }
        else
        {
            speed = walkingSpeed;
        }
        anime.SetBool("runflag", runflag);
    }

}
