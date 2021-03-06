﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Root : MonoBehaviour
{

    Game game;

    public  Button startBtn;

    public Transform FollowBtns;

    public Transform btns;

    public Transform settlement;
    public Text settleText;
    public Button settleBtn;

    public void Back()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }


    public void StartGame()
    {
        game.Init();
        UpdateUI();
    }

    public void CardClick(int  type)
    {
        game.players[game.currentPlayer].GuessCard(type);
    }

   public  void UpdateUI()
    {
        startBtn.gameObject.SetActive(!game.isStart);
        
        btns.gameObject.SetActive(game.currentPlayer==0);
    }

    public void GameOver(int index)
    {
        settlement.gameObject.SetActive(true);

        if (index == 0)
        {
            settleText.text = "玩家失败";
        }
        else
        {
            //胜利
            settleText.text = "玩家胜利";
        }
    }


    private void Start()
    {
        game = this.GetComponent<Game>();

        settleBtn.onClick.AddListener(Back);
    }




}
