﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 4f;
    int index = 1;
    public static int score = 0;
    float targetAngle;
    Bow bow;

    static Player instance;

    public enum State
    {
        ATTACK, STOP, HOME
    }
    static State state = State.ATTACK;

    List<Vector3> path;
    void Start()
    {
        instance = this;
        bow = transform.Find("Bow").GetComponent<Bow>();
    }

    void Update()
    {
        if (path != null && index < path.Count)
        {
            Vector2 pos = Vector2.MoveTowards(transform.position, path[index], speed * Time.deltaTime);
            transform.position = new Vector3(pos.x, pos.y, transform.position.z);
            if (Vector2.Distance(pos, path[index]) < 0.01f)
            {
                if (index < path.Count - 1)
                {
                    index++;
                }
            }
        }
        switch (state)
        {
            case State.STOP:
                break;
            case State.HOME:
                break;
            case State.ATTACK:
                // look for a peasant within x meters and shoot it
                GameObject[] peasants = GameObject.FindGameObjectsWithTag("Enemy");
                GameObject min = null;
                float minDist = 10000f;
                foreach (GameObject peasant in peasants)
                {
                    float distance = Vector2.Distance(peasant.transform.position, transform.position);
                    if (distance < 3f && distance < minDist)
                    {
                        min = peasant;
                        minDist = distance;
                    }
                }
                if (min != null)
                {
                    if (bow.Ready())
                    {
                        bow.Fire(min);
                    }
                    targetAngle = Vector2.SignedAngle(Vector2.right, min.transform.position - transform.position);
                }
                bow.transform.localEulerAngles = new Vector3(0, 0,
                    Mathf.MoveTowardsAngle(bow.transform.localEulerAngles.z, targetAngle, 720 * Time.deltaTime));
                break;
        }
    }

    public void SetPath(List<Vector3> path)
    {
        if (state != State.HOME)
        {
            index = 1;
            this.path = path;
        }
    }

    public static void SetState(State state)
    {
        if (state == State.HOME)
        {
            instance.SetPath(Obstacles.PathTo(instance.transform.position, GameObject.FindGameObjectWithTag("Home").transform.position));
        }
        Player.state = state;
    }
}
