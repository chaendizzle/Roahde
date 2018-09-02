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

       if ((button.GetComponent<Image>().sprite == knife_1)){
            button.GetComponent<Image>().sprite = knife_2;
        }

       else if ((button.GetComponent<Image>().sprite == knife_2))
        {
            button.GetComponent<Image>().sprite = knife_3;
        }

        else if ((button.GetComponent<Image>().sprite == knife_3))
        {
            button.GetComponent<Image>().sprite = knife_4;
        }

        else if ((button.GetComponent<Image>().sprite == knife_4))
        {
            button.GetComponent<Image>().sprite = knife_1;
        }
    }


    public void changeArmor()
    {
        button = GameObject.Find("btn_armor").GetComponent<UnityEngine.UI.Button>();

        if ((button.GetComponent<Image>().sprite == armor_1))
        {
            button.GetComponent<Image>().sprite = armor_2;
        }

        else if ((button.GetComponent<Image>().sprite == armor_2))
        {
            button.GetComponent<Image>().sprite = armor_3;
        }

        else if ((button.GetComponent<Image>().sprite == armor_3))
        {
            button.GetComponent<Image>().sprite = armor_1;
        }
    }

    public void changebow()
    {
        button = GameObject.Find("btn_bow").GetComponent<UnityEngine.UI.Button>();

        if ((button.GetComponent<Image>().sprite == bow_1))
        {
            button.GetComponent<Image>().sprite = bow_2;
        }

        else if ((button.GetComponent<Image>().sprite == bow_2))
        {
            button.GetComponent<Image>().sprite = bow_3;
        }

        else if ((button.GetComponent<Image>().sprite == bow_3))
        {
            button.GetComponent<Image>().sprite = bow_1;
        }
    }

}
