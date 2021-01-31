using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    [Header("GameOver UI")]
    [SerializeField] GameObject gameOverUI;
    bool go = false;

    public void Awake()
    {
        gameOverUI.SetActive(false);
    }


    public void GameOver()
    {
        if (!go)
        {

        print("Game Over");
        gameOverUI.SetActive(true);
            gameOverUI.GetComponent<GameOverController>().GOPlay();
            go = true;
        }
    }

}
