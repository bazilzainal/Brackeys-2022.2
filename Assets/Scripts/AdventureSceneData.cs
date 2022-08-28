using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AdventureScene")]
public class AdventureSceneData : ScriptableObject
{
    [SerializeField] private string title;
    [SerializeField] private List<Sprite> backgrounds;
    [SerializeField] [TextArea (minLines:20,maxLines:20)] private string description;

    [SerializeField] private List<PromptData> scenes;

    private List<AdventureSceneData> nextScenes;
    
    [SerializeField]
    private int activateMinigameIndex = -1;

    [SerializeField]
    public bool UseTypewriter;

    public AudioClip AudioClip;
    public string Title { get => title; set => title = value; }
    public List<Sprite> Backgrounds { get => backgrounds; set => backgrounds = value; }
    public string Description { get => description; set => description = value; }
    public List<PromptData> Scenes { get => scenes; set => scenes = value; }

    [SerializeField]
    private bool giveJetpack;
    
    public void OnSceneLoaded()
    {
        if (activateMinigameIndex >= 0)
        {
            GameManager.instance.StartMinigame(activateMinigameIndex);
        }

        if (giveJetpack)
        {
            GameManager.instance.HasJetpack = true;
        }

        if (AudioClip != null)
        {
            MusicManager.instance.PlayMusic(AudioClip);
        }
    }
}