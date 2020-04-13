using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CardType
{

    dragon = 1,
    ghost,
    dream,
    owl,
    storm,
    ice,
    fire,
    heal,
    Max
}


public class Card : MonoBehaviour
{

    public CardType type;

    public int owner;

    public Game game;

    public void User()
    {
       
        switch (type)
        {
            case CardType.dragon:

                foreach (var item in game.players)
                {
                    if (item.Value.Index != owner)
                    {
                        item.Value.Hit(2);
                    }
                }

                break;
            case CardType.ghost:

                foreach (var item in game.players)
                {
                    if (item.Value.Index != owner)
                    {
                        item.Value.Hit(1);
                    }
                    else
                    {
                        item.Value.Gain(1);
                    }
                }

                break;
            case CardType.dream:

                foreach (var item in game.players)
                {
                    item.Value.Gain(1);
                }

                break;
            case CardType.owl:

                foreach (var item in game.players)
                {
                    if (item.Value.Index == owner)
                    {
                        item.Value.Gain(1);
                    }
                }

                break;
            case CardType.storm:

                foreach (var item in game.players)
                {
                    if (item.Value.Index != owner)
                    {
                        item.Value.Hit(1);
                    }
                }

                break;
            case CardType.ice:

                int target = (owner + 2) % 3;
                Player player = null;
                if (game.players.TryGetValue(target, out player))
                {
                    player.Hit(1);
                }
             
                break;
            case CardType.fire:

                int targetfire = (owner + 1) % 3;
                Player playerfire = null;
                if (game.players.TryGetValue(targetfire, out playerfire))
                {
                    playerfire.Hit(1);
                }

                break;
            case CardType.heal:

                foreach (var item in game.players)
                {
                    if (item.Value.Index == owner)
                    {
                        item.Value.Gain(1);
                    }
                }

                break;
            case CardType.Max:
                break;
            default:
                break;
        }

    }


}
