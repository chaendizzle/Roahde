using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;

public class ButtonImageCycler : MonoBehaviour
{

    public Player player;
    public Bow bow;

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
    public Button button2;

    SpriteRenderer playerRender;
    SpriteRenderer bowRender;

    //initialization
    void Start()
    {
        playerRender = player.GetComponent<SpriteRenderer>();
        bowRender = bow.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void changeKnife()
    {
        button = GameObject.Find("btn_knife").GetComponent<UnityEngine.UI.Button>();
        button2 = GameObject.Find("btn_buy_knife").GetComponent<UnityEngine.UI.Button>();



        if ((button.GetComponent<Image>().sprite == knife_1) && Player.score >= 200)
        {
            Player.score = Player.score - 200;
            button.GetComponent<Image>().sprite = knife_2;
            button2.GetComponent<Image>().sprite = knife_2;
        }

        else if ((button.GetComponent<Image>().sprite == knife_2) && Player.score >= 500)
        {
            Player.score = Player.score - 500;
            button.GetComponent<Image>().sprite = knife_3;
            button2.GetComponent<Image>().sprite = knife_3;
        }

        else if ((button.GetComponent<Image>().sprite == knife_3) && Player.score >= 750)
        {
            Player.score = Player.score - 750;
            button.GetComponent<Image>().sprite = knife_4;
            button2.GetComponent<Image>().sprite = knife_4;
        }

        else if ((button.GetComponent<Image>().sprite == knife_4))
        {
            button.GetComponent<Image>().sprite = knife_1;
            button2.GetComponent<Image>().sprite = knife_1;
        }
    }


    public void changeArmor()
    {
        button = GameObject.Find("btn_armor").GetComponent<UnityEngine.UI.Button>();
        button2 = GameObject.Find("btn_buy_armor").GetComponent<UnityEngine.UI.Button>();

        if ((button.GetComponent<Image>().sprite == armor_1) && Player.score >= 200)
        {
            Player.score = Player.score - 200;
            playerRender.color = Color.green;
            button.GetComponent<Image>().sprite = armor_2;
            button2.GetComponent<Image>().sprite = armor_2;
        }

        else if ((button.GetComponent<Image>().sprite == armor_2) && Player.score >= 500)
        {
            Player.score = Player.score - 500;
            playerRender.color = Color.red;
            button.GetComponent<Image>().sprite = armor_3;
            button2.GetComponent<Image>().sprite = armor_3;
        }

        else if ((button.GetComponent<Image>().sprite == armor_3))
        {
            playerRender.color = Color.white;
            button.GetComponent<Image>().sprite = armor_1;
            button2.GetComponent<Image>().sprite = armor_1;
        }
    }

    public void changebow()
    {
        button = GameObject.Find("btn_bow").GetComponent<UnityEngine.UI.Button>();

        if ((button.GetComponent<Image>().sprite == bow_1) && Player.score >= 200)
        {
            button2 = GameObject.Find("btn_buy_bow").GetComponent<UnityEngine.UI.Button>();
            Player.score = Player.score - 200;
            button.GetComponent<Image>().sprite = bow_2;
            button2.GetComponent<Image>().sprite = bow_2;
            bowRender.color = Color.green;
        }

        else if ((button.GetComponent<Image>().sprite == bow_2) && Player.score >= 500)
        {
            Player.score = Player.score - 500;
            button.GetComponent<Image>().sprite = bow_3;
            button2.GetComponent<Image>().sprite = bow_3;
            bowRender.color = Color.red;

        }

        else if ((button.GetComponent<Image>().sprite == bow_3))
        {
            button.GetComponent<Image>().sprite = bow_1;
            button2.GetComponent<Image>().sprite = bow_1;
            bowRender.color = Color.white;
        }
    }

    public void Attack()
    {
        Player.SetState(Player.State.ATTACK);
    }
    public void Home()
    {
        Player.SetState(Player.State.HOME);
    }
    public void Hide()
    {
        Player.SetState(Player.State.STOP);
    }
}
