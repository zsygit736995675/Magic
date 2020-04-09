using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    private Dictionary<int, Player> players = new Dictionary<int, Player>();

    public int currentPlayer;




    private void Start()
    {
        Init();
    }


    private void Update()
    {
        
    }


    public void Init()
    {
        players.Clear();

        for (int i = 0; i < 3; i++)
        {
            Transform p =  transform.Find("player"+i);
            PlayerUI ui = new PlayerUI();
            Player player = new Player(i, ui);
            ui.Init(p,player);
            players.Add(i,player ) ;
        }

        

    }



}
