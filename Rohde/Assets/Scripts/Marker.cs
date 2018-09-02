using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour {

    public GameObject target;
    GameObject arrow;

	// Use this for initialization
	void Start () {
        arrow = transform.Find("Arrow").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null)
        {
            arrow.transform.localEulerAngles = new Vector3(0, 0,
                Vector2.SignedAngle(Vector2.right, target.transform.position - transform.position));
            arrow.transform.localScale = new Vector3((target.transform.position - transform.position).magnitude * (2.5f/2f), 5f, 1);
        }
        else
        {
            arrow.transform.localScale = new Vector3(0, 1, 1);
        }
	}

    public void SetColor(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
        if (arrow != null)
        {
            SpriteRenderer sr = arrow.GetComponent<SpriteRenderer>();
            sr.color = color;
        }
    }
}
