using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AdventureScene")]
public class AdventureSceneData : ScriptableObject
{
    [SerializeField] private string title;
    [SerializeField] private Sprite background;
    [SerializeField] [TextArea] private string description;

    [SerializeField] private List<PromptData> scenes;

    private List<AdventureSceneData> nextScenes;
    
    [SerializeField]
    private int activateMinigameIndex = -1;
    public string Title { get => title; set => title = value; }
    public Sprite Background { get => background; set => background = value; }
    public string Description { get => description; set => description = value; }
    public List<PromptData> Scenes { get => scenes; set => scenes = value; }
    
    public void OnSceneLoaded()
    {
        if (activateMinigameIndex >= 0)
        {
            GameManager.instance.StartMinigame(activateMinigameIndex);
        }
    }
}