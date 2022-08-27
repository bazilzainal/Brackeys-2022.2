using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    [SerializeField] private AdventureSceneData StartingScene;
    [SerializeField] private AdventureScene scene;
    [SerializeField] private GameObject gameOverPanel;

    [SerializeField]
    private GameObject[] minigames;
    void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        CloseMinigames();
        this.scene.BindData(this.StartingScene);
    }

    private void CloseMinigames()
    {
        foreach (var minigame in minigames)
        {
            minigame.gameObject.SetActive(false);
        }
    }

    public void ResetGame()
    {
        gameOverPanel.SetActive(true);
        StartGame();
    }

    public void StartMinigame(in int activateMinigameIndex)
    {
        scene.gameObject.SetActive(false);
        this.minigames[activateMinigameIndex].gameObject.SetActive(true);
    }

    public void MinigameWon()
    {
        CloseMinigames();
        scene.gameObject.SetActive(true);
    }
}
