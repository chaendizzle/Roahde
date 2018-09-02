using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour {

    public GameObject arrow;
    GameObject target;
    bool firing = false;
    bool fired = false;

    Animator anim;
    float fireTimer = 0f;
    float fireDelay = 0.3f;
    float totalFireDelay = 0.8f;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
        if (!firing)
        {
            return;
        }
        if (target == null)
        {
            firing = false;
            return;
        }
        fireTimer += Time.deltaTime;
        if (fireTimer > fireDelay && !fired)
        {
            Instantiate(arrow, transform.position, Quaternion.identity).GetComponent<Arrow>().Initialize(target);
            fired = true;
        }
        if (fireTimer > totalFireDelay)
        {
            firing = false;
        }
    }
    public void Fire(GameObject target)
    {
        if (firing)
        {
            return;
        }
        fireTimer = 0f;
        this.target = target;
        anim.SetTrigger("Fire");
        firing = true;
        fired = false;
    }

    public bool Ready()
    {
        return firing == false;
    }
}
