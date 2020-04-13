using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Player :MonoBehaviour
{

    public int Hp;

    public int Index;

    public List<Card> cards = new List<Card>();

    public Transform HeapPos;

    public Transform CountDown;

    public Text CountTxt;

    public Text hpText;

    public Game game;

    public Card currentCard;

    public bool isTiming=false;

    private float timer;

    public void Init(int index, Game game)
    {
        cards.Clear();
        Hp = 5;

        this.Index = index;
        this.game = game;

        HeapPos =transform .Find("HeapPos");
        CountDown = transform.Find("CountDown");
        CountTxt = CountDown.Find("CountTxt").GetComponent<Text>();
        hpText = transform.Find("hp").GetComponent<Text>();
        UpdateUI();
    }

    public void UpdateUI()
    {

        hpText.text = Hp.ToString();
        CountDown.gameObject.SetActive(game.currentPlayer == Index);
    }


    public  Player()
    {
       

       
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
        if (game.currentRound < cards.Count)
        {
            currentCard = cards[game.currentRound];
            currentCard.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.3f);
        }

        timer = 12;

        isTiming = true;

        CountDown.gameObject.SetActive(true);
        CountTxt.text = timer.ToString();
       
    }

    private void Update()
    {
        if (isTiming)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                isTiming = false;
                CountDown.gameObject.SetActive(false);
                game.Next();
            }
            CountTxt.text = (int)timer + "";
        }
    }

    /// <summary>
    /// 猜牌
    /// </summary>
    public void GuessCard(int type)
    {
        if (type == (int)currentCard.type)
        {
            currentCard.GetComponent<Image>().color = Color.green;

        }
        else
        {
            currentCard.GetComponent<Image>().color = Color.red;
            Hit(1);
        }
    }

    public void Hit(int value)
    {
        Hp -= value;
        game.root.UpdateUI();
        UpdateUI();
        //游戏结束
        if (Hp <= 0)
        {
            //输了
            if (Index == 0)
            {

            }
            else
            {
                //胜利

            }
        }
    }

    public void Gain(int value)
    {
        Hp += value;
        game.root.UpdateUI();
        

    }


}
