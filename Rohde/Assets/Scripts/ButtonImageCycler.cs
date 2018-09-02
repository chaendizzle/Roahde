using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonImageCycler : MonoBehaviour {
    public Sprite knife_1;
    public Sprite knife_2;
    public Sprite knife_3;
    public Sprite knife_4;

    public Sprite bow_1;
    public Sprite bow_2;
    public Sprite bow_3;

    public Sprite armor_1;
    public Sprite armor_2;
    public Sprite armor_3;

    public Button button;
    

    //initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update () {
		
	}


    public void changeKnife(){
        button = GameObject.Find("btn_knife").GetComponent<UnityEngine.UI.Button>();
        button.GetComponent<Image>().sprite = knife_2;
    }
}
