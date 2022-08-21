using System;
using TMPro;
using UnityEngine;

public class AdventureScenePrompt : MonoBehaviour
{
    [SerializeField] private TMP_Text prompt;
    private Action<SceneBranch> onClick;
    private SceneBranch sceneBranch;

    public void HandleClick()
    {
        // dosomething
        onClick.Invoke(sceneBranch);

    }

    public void BindPrompt(SceneBranch data, Action<SceneBranch> branch)
    {
        sceneBranch = data;
        prompt.text = data.choice;
        onClick = branch;

    }
}
