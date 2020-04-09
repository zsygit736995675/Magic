using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Mian : MonoBehaviour
{

    /// <summary>
    /// 进入游戏
    /// </summary>
    /// <param name="level"></param>
    public void EnterGame(int level)
    {
        App.Ins.currentLevel = level;

        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }



}
