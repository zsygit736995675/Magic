using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public enum CardType
{
            
    dragon=1,
    ghost,
    dream,
    owl,
    storm,
    ice,
    fire,
    heal,
    Max
}

public class Game : MonoBehaviour
{

    public Dictionary<int, Player> players = new Dictionary<int, Player>();

    public int currentPlayer=2;

    public bool isStart = false;

    public List<CardType> cardLibrary = new List<CardType>();

    public Root root;

    int index;

    int targetCount = 0;//目标发牌张数

    int currentCount = 0;//当前发牌的张数

    public int currentRound = 0;//回合数


    private void Start()
    {
        root = gameObject.GetComponent<Root>();
    }


    private void Update()
    {
        
    }


    /// <summary>
    /// 随机生成牌库
    /// </summary>
    public void RandomCardLibraries()
    {
        currentPlayer = -1;
        currentRound = -1;
        targetCount = 15;
        currentCount = 0;

        for (int i = 0; i < 36; i++)
        {
           int range =  Random.Range(1, (int)CardType.Max);
            cardLibrary.Add((CardType)range);
        }

        Licensing(Next);
    }

    /// <summary>
    /// 發牌
    /// </summary>
    private void Licensing(System.Action callback)
    {
        if (cardLibrary.Count > 0)
        {
            currentCount++;

            if (currentCount <= targetCount)
            {
                GameObject go = Resources.Load<GameObject>("Prefab/card");
                GameObject ingo = GameObject.Instantiate(go);
                Card card = ingo.AddComponent<Card>();
                card.transform.SetParent(transform);
                card.transform.position = root.startBtn.transform.position;
                card.type = cardLibrary[0];
                cardLibrary.Remove(0);

                card.transform.DOMove(players[index].HeapPos.transform.position, 0.5f);
                float timeCount = 0;
                DOTween.To(() => timeCount, a => timeCount = a, 1, 0.5f).OnComplete(() =>
                {
                    players[index].Receive(card);
                    index++;
                    index = index % 3;
                    Licensing(callback);
                });
            }
            else
            {
                callback?.Invoke();
            }
        }
        else
        {
            ///游戏结束
            

        
        }
      
    }

    public void GameOver()
    {

    }



    public void Next()
    {
        currentPlayer ++;
        currentPlayer = currentPlayer % 3;
        if (currentPlayer == 0)
        {
            currentRound++;
        }

        root.UpdateUI();
        players[currentPlayer].Action();
    }


    /// <summary>
    /// 初始化
    /// </summary>
    public void Init()
    {
        if (players.Count == 0)
        {
            for (int i = 0; i < 3; i++)
            {
                Transform p =  transform.Find("player"+i);
                Player player = p.gameObject.AddComponent<Player>();
                player.Init(i,this);
                players.Add(i,player ) ;
            }
        }

        isStart = true;

        RandomCardLibraries();
    }



}

