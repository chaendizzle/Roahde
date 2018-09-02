using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Units : MonoBehaviour {

    public List<Unit> units;
    static Dictionary<string, GameObject> prefabs = new Dictionary<string, GameObject>();

    void Awake()
    {
		foreach (var unit in units)
        {
            prefabs[unit.name] = unit.prefab;
        }
	}

    public static GameObject Create(string name)
    {
        return Instantiate(prefabs[name]);
    }
}

[Serializable]
public class Unit
{
    public string name;
    public GameObject prefab;
}