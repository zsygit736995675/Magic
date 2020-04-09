using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Root : MonoBehaviour
{

    Game game;

    public void Back()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }


    public void StartGame()
    {

    }

    public void CardClick(int  type)
    {

    }


    private void Start()
    {
        game = this.GetComponent<Game>();
    }




}

public class PlayerUI
{

    public Transform HeapPos;

    public Transform CountDown;

    public Text CountTxt;

    public Text hp;

    public Player player;

    public void Init(Transform tran,Player player)
    {
        this.player = player;
        HeapPos = tran.Find("HeapPos");
        CountDown = tran.Find("CountDown");
        CountTxt = CountDown.Find("CountTxt").GetComponent<Text>();
        hp= tran.Find("hp").GetComponent<Text>();
    }

    public void Update()
    {
        if (player != null)
        {
            hp.text = player.Hp.ToString();


        }
    }

}
