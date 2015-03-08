using UnityEngine;
using System.Collections;

public class MoveBlock_Control : MonoBehaviour {
    public bool side = true;
    public float speed = 0.01f;

    private int power = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 v = transform.position;
        if (side)
        {
            v.x += speed * power;
        }
        else
        {
            v.y += speed * power;
        }
        transform.position = v;
	}

    void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            power *= -1;
        }
    }
}
