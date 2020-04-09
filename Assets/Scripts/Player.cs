using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player 
{

    public int Hp;

    public int Index;

    public PlayerUI ui;

    public List<Card> cards = new List<Card>();


    public  Player(int index,PlayerUI ui)
    {
        Hp = 5;
        this.Index = index;
        this.ui = ui;
        cards.Clear();
    }


    public void UpdateUI()
    {
        ui.Update();

    }

    
}
