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

    private Text increase;

    public Game game;

    public Card currentCard;

    public bool isTiming=false;

    private float timer;

    private int delay;

    public void Init(int index, Game game)
    {
        cards.Clear();
        Hp = 6;

        this.Index = index;
        this.game = game;

        HeapPos =transform .Find("HeapPos");
        CountDown = transform.Find("CountDown");
        CountTxt = CountDown.Find("CountTxt").GetComponent<Text>();
        hpText = transform.Find("hp").GetComponent<Text>();
        increase= transform.Find("increase").GetComponent<Text>();
        CountDown.gameObject.SetActive(false);
        increase.gameObject.SetActive(false);
        UpdateUI();
    }

    public void UpdateUI()
    {
        hpText.text = Hp.ToString();
    }


    public void Receive(Card card)
    {
        card.transform.SetParent(HeapPos);
        card.transform.localScale=Vector3.one;
        card.owner = this.Index;

        if (this.Index != 0)
        {
            Sprite sprite = Resources.Load<Sprite>("Images/Cards/Card_" + (int)card.type);
            card.gameObject.GetComponent<Image>().sprite = sprite;
        }

        cards.Add(card);
    }

    public void Action()
    {
        if (!game.isStart) return;

        if (game.currentRound < cards.Count)
        {
            currentCard = cards[game.currentRound];
            currentCard.transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.3f);
        }

        timer = 12;

        isTiming = true;

        CountDown.gameObject.SetActive(true);
        CountTxt.text = timer.ToString();

        if (Index != 0)
        {
            delay = Random.Range(1,5);
        }
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

            if (Index != 0)
            {
                if ((12 - timer) >= delay)
                {
                    isTiming = false;

                    int level = App.Ins.currentLevel * 30;
                    int range = Random.Range(0,100);
                    if (range<level)
                    {
                        GuessCard((int)currentCard.type);
                    }
                    else
                    {
                        GuessCard((int)currentCard.type+1);
                    }
                }
            }
        }
    }

    /// <summary>
    /// 猜牌
    /// </summary>
    public void GuessCard(int type)
    {
        isTiming = false;

        CountDown.gameObject.SetActive(false);

        if (Index == 0)
        {
            Sprite sprite = Resources.Load<Sprite>("Images/Cards/Card_" + (int)currentCard.type);
            currentCard.gameObject.GetComponent<Image>().sprite = sprite;
        }

        if (type == (int)currentCard.type)
        {
            currentCard.GetComponent<Image>().color = Color.green;
            currentCard.User();
        }
        else
        {
            currentCard.GetComponent<Image>().color = Color.red;
            Hit(1);
        }

        game.Next();
    }

    /// <summary>
    /// 受击
    /// </summary>
    /// <param name="value"></param>
    public void Hit(int value)
    {
        Hp -= value;
        game.root.UpdateUI();
        UpdateUI();
        //游戏结束
        if (Hp <= 0)
        {
            game.root.GameOver(Index);
        }

        IncreaseAni(-value);
    }

    /// <summary>
    /// 增益
    /// </summary>
    /// <param name="value"></param>
    public void Gain(int value)
    {
        Hp += value;
        game.root.UpdateUI();
        UpdateUI();

        IncreaseAni( value);
    }


    void IncreaseAni(int value)
    {
        if (value > 0)
        {
            increase.color = Color.green;
            increase.text = "+" + value;
        }
        else
        {
            increase.color = Color.red;
            increase.text = value.ToString() ;
        }
        increase.gameObject.SetActive(true);
        increase.transform.localScale = Vector3.zero;
        increase.transform.DOScale(Vector3.one,1);
        float timeCount = 0;
        DOTween.To(() => timeCount, a => timeCount = a, 1, 1f).OnComplete(() =>
        {
            increase.gameObject.SetActive(false);
        });

    }

}
