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

    private Dictionary<int, Player> players = new Dictionary<int, Player>();

    public int currentPlayer=2;

    public bool isStart = false;

    public List<CardType> cardLibrary = new List<CardType>();

    public Root root;

    int index;

    int targetCount = 0;

    int currentCount = 0;



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

        for (int i = 0; i < 36; i++)
        {
           int range =  Random.Range(1, (int)CardType.Max);
            cardLibrary.Add((CardType)range);
        }

        targetCount = 15;
        currentCount = 0;
        Licensing();
    }

    /// <summary>
    /// 發牌
    /// </summary>
    private void Licensing()
    {
        currentCount++;

        if (currentCount <= targetCount)
        {
            GameObject go = Resources.Load<GameObject>("Prefab/card");
            GameObject ingo = GameObject.Instantiate(go);
            Card card = ingo.AddComponent<Card>();
            card.transform.SetParent(transform);
            card.transform.position = root.startBtn.transform.position;

            card.transform.DOMove(players[index].HeapPos.transform.position, 0.5f);
            float timeCount = 0;
            DOTween.To(() => timeCount, a => timeCount = a, 1, 0.5f).OnComplete(() =>
            {

                Licensing();

            });

            index++;
            index = index % 3;
        }
        else
        {

        }
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
                Player player = new Player(i,p,this);
                players.Add(i,player ) ;
            }
        }

        isStart = true;

        RandomCardLibraries();
    }



}

