using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

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

    public Card currentCard;



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

    public void Receive(Card card)
    {
        card.transform.SetParent(HeapPos);
        card.transform.localScale=Vector3.one;
        cards.Add(card);
        card.GetComponent<Button>().onClick.AddListener(()=> {

           

        });
    }


    public void Action()
    {
        cards[game.currentRound].transform.DOScale(new Vector3(1.2f,1.2f,1.2f),0.3f);

    }


}
