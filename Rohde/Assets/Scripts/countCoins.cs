using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countCoins : MonoBehaviour {
    public Text text;
    public Player player1;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        text.text = player1.getScore()+"";
    }
}
