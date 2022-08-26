using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "AdventureScene")]
public class AdventureSceneData : ScriptableObject
{

    [SerializeField] private string title;
    [SerializeField] private Sprite background;
    [SerializeField] [TextArea] private string description;

    [SerializeField] private List<PromptData> scenes;

    private List<AdventureSceneData> nextScenes;

    public string Title { get => title; set => title = value; }
    public Sprite Background { get => background; set => background = value; }
    public string Description { get => description; set => description = value; }
    public List<PromptData> Scenes { get => scenes; set => scenes = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}

[Serializable]
public class PromptData {
    [SerializeField] public int Amount;
    [SerializeField] public string Choice;
    [SerializeField] public AdventureSceneData NextScene;

    internal AdventureSceneData PromptChosen()
    {
        RobotManager.instance.AdjustHealth(Amount);
        return GetNextScene();
    }

    internal AdventureSceneData GetNextScene()
    {
        return NextScene;
    }
}

