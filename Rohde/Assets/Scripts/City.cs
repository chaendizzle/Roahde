using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour
{
    public string city;
    public List<string> roads;
    Dictionary<string, List<Vector3>> paths = new Dictionary<string, List<Vector3>>();

    float timerSeconds = 0f;
    public float duration = 1.5f;
    public string last;

    void Start()
    {
        GameObject[] cities = GameObject.FindGameObjectsWithTag("City");
        foreach (GameObject cityObj in cities)
        {
            string cityName = cityObj.GetComponent<City>().city;
            if (roads.Contains(cityName))
            {
                paths[cityName] = Obstacles.PathTo(transform.position, cityObj.transform.position);
            }
        }
    }

    void Update()
    {
        timerSeconds += Time.deltaTime;
        if (timerSeconds >= duration)
        {
            timerSeconds = 0f;
            string targetCity = roads[UnityEngine.Random.Range(0, roads.Count)];
            last = targetCity;
             Peasant p = Units.Create("UnarmedPeasant").GetComponent<Peasant>();
            p.transform.position = transform.position;
            p.Initialize(paths[targetCity]);
        }
    }
}
