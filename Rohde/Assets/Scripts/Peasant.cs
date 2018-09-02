using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peasant : MonoBehaviour
{
    public float speed = 4f;
    float growSpeed = 3.5f;
    int index = 1;
    bool destroy = false;

    List<Vector3> path;
    public void Initialize(List<Vector3> path)
    {
        this.path = path;
        transform.localScale = Vector2.zero;
    }

    void Update()
    {
        Vector2 pos = Vector2.MoveTowards(transform.position, path[index], speed * Time.deltaTime);
        transform.position = new Vector3(pos.x, pos.y, transform.position.z);
        if (Vector2.Distance(pos, path[index]) < 0.01f)
        {
            if (index < path.Count - 1)
            {
                index++;
            }
            else
            {
                destroy = true;
            }
        }
        transform.localScale = Vector2.MoveTowards(transform.localScale, destroy ? Vector2.zero : Vector2.one, growSpeed * Time.deltaTime);
        if (destroy && (Vector2)transform.localScale == Vector2.zero)
        {
            Destroy(gameObject);
        }
    }
}
