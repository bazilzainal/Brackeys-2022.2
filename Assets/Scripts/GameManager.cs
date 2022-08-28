using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    [SerializeField] private AdventureSceneData StartingScene;
    [SerializeField] private AdventureScene scene;
    [SerializeField] private GameObject gameOverPanel;

    [SerializeField]
    private GameObject[] minigames;

    public bool HasJetpack;

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

    public void LoadScene(AdventureSceneData sceneData)
    {
        CloseMinigames();
        scene.gameObject.SetActive(true);
        this.scene.BindData(sceneData);
    }
}