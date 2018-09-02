using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopMess : MonoBehaviour {
    public GameObject shop;
    public GameObject bow;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void openShop()
    {
        shop.SetActive(true);
        bow.SetActive(false);
    }

    public void closeShop()
    {
        shop.SetActive(false);
        bow.SetActive(true);
    }
}
