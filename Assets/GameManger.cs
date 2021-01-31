using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    [Header("GameOver UI")]
    [SerializeField] GameObject gameOverUI;

    public void Awake()
    {
        gameOverUI.SetActive(false);
    }


    public void GameOver()
    {
        print("Game Over");
        gameOverUI.SetActive(true);
    }

}
