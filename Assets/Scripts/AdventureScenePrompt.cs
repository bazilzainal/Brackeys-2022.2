using System;
using Newtonsoft.Json.Serialization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class AdventureScenePrompt : MonoBehaviour
{
    [SerializeField] private TMP_Text prompt;
    private Action<PromptData> onClick;
    private PromptData promptData;

    public void HandleClick()
    {
        // dosomething
        onClick.Invoke(promptData);
        

    }

    public void BindPrompt(PromptData data, Action<PromptData> branch)
    {
        promptData = data;
        prompt.text = data.Choice;
        onClick = branch;

    }

    public void AdjustHealth(int amount)
    {
    }
}

public enum GameKey
{
    Action,
}