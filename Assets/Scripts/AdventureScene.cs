using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AdventureScene : MonoBehaviour
{
    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text sceneText;
    [SerializeField] private Image image;
    [SerializeField] private List<AdventureScenePrompt> prompts;
    private AdventureSceneData data;
    private float timer;


    public void BindData(AdventureSceneData data)
    {
        this.data = data;
        data.OnSceneLoaded();
        title.text = data.Title;
        sceneText.text = data.Description;
        image.sprite = data.Backgrounds[0];

        int i = 0;
        while (i < data.Scenes.Count)
        {
            prompts[i].gameObject.SetActive(true);
            prompts[i].BindPrompt(data.Scenes[i], onClick);
            i++;
        }
        while (i < prompts.Count)
        {
            prompts[i].gameObject.SetActive(false);
            i++;
        }
        

    }

    private void Update()
    {

        image.sprite = data.Backgrounds[(int)timer % (data.Backgrounds.Count)];
        timer += 12*Time.deltaTime;

    }

    private void onClick(PromptData data)
    {
        data.PromptChosen(out AdventureSceneData nextScene);
        if (nextScene == null)
        {
            return;
        }
        BindData(nextScene);

    }
}
