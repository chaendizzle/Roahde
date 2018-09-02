using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    public GameObject target;
    float spd = 15f;

    public void Initialize(GameObject target)
    {
        this.target = target;
        transform.localEulerAngles = new Vector3(0, 0,
            Vector2.SignedAngle(Vector2.right, target.transform.position - transform.position));
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (target != null)
        {
            Vector2 pos = Vector2.MoveTowards(transform.position, target.transform.position, spd * Time.deltaTime);
            if (Vector2.Distance(transform.position, target.transform.position) < 0.1f)
            {
                Player.score += 50;
                Destroy(gameObject);
                return;
            }
            transform.position = new Vector3(pos.x, pos.y, transform.position.z);
        }
        else
        {
            Destroy(gameObject);
        }
	}
}
