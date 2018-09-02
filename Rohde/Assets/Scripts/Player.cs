using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 4f;
    float growSpeed = 3.5f;
    int index = 1;

    List<Vector3> path;
    public void Initialize(List<Vector3> path)
    {
        this.path = path;
        transform.localScale = Vector2.zero;
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
    }

    public void SetPath(List<Vector3> path)
    {
        index = 1;
        this.path = path;
    }
}
