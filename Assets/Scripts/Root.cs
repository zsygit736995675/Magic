using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Root : MonoBehaviour
{

    Game game;

    public  Button startBtn;

    public Transform FollowBtns;

    public Transform btns;



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

    }

    void UpdateUI()
    {
        startBtn.gameObject.SetActive(!game.isStart);
        FollowBtns.gameObject.SetActive(game.currentPlayer==0);
        btns.gameObject.SetActive(game.currentPlayer==0);
    }


    
    private void Start()
    {
        game = this.GetComponent<Game>();
    }




}
