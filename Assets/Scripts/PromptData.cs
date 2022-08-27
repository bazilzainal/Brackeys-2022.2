using System;
using UnityEngine;

[Serializable]
public class PromptData
{
    [SerializeField] public int HealthChange;
    [SerializeField] public string Choice;
    [SerializeField] public AdventureSceneData NextScene;

    public void PromptChosen(out AdventureSceneData nextScene)
    {
        RobotManager.instance.AdjustHealth(HealthChange, out bool isDead);
        if (isDead)
        {
            nextScene = null;
        }
        else
        {
            nextScene = this.NextScene;
        }
    }
}