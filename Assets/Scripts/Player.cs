using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player 
{

    public int Hp;

    public int Index;

    public List<Card> cards = new List<Card>();

    public Transform trans;

    public Transform HeapPos;

    public Transform CountDown;

    public Text CountTxt;

    public Text hpText;

    public Game game;

    public void Init()
    {
        cards.Clear();
        Hp = 5;


        UpdateUI();
    }

    public void UpdateUI()
    {

        hpText.text = Hp.ToString();
        CountDown.gameObject.SetActive(game.currentPlayer == Index);

       
    }


    public  Player(int index, Transform tran,Game game)
    {
        this.Index = index;
        this.trans = tran;
        this.game = game;

        HeapPos = tran.Find("HeapPos");
        CountDown = tran.Find("CountDown");
        CountTxt = CountDown.Find("CountTxt").GetComponent<Text>();
        hpText = tran.Find("hp").GetComponent<Text>();

        Init();
    }



    
}
