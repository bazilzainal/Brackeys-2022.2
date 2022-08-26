using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    [SerializeField] private AdventureSceneData StartingScene;
    [SerializeField] private AdventureScene scene;
    [SerializeField] private GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        
        this.scene.BindData(this.StartingScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetGame()
    {
        gameOverPanel.SetActive(true);
        StartGame();
    }
}
