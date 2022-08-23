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


    public void BindData(AdventureSceneData data)
    {
        title.text = data.Title;
        sceneText.text = data.Description;
        image.sprite = data.Background;

        // TODO: Potential infinite loop
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

    private void onClick(SceneBranch data)
    {
        BindData(data.nextScene);

    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
