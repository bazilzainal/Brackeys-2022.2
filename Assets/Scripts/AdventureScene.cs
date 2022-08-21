using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AdventureScene : MonoBehaviour
{
    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text description;
    [SerializeField] private Image image;
    [SerializeField] private List<AdventureScenePrompt> prompts;


    public void BindData(AdventureSceneData data)
    {
        title.text = data.Title;
        description.text = data.Description;
        image.sprite = data.Background;

        for (int i = 0; i < data.Scenes.Count; i++)
        {
            prompts[i].BindPrompt(data.Scenes[i], onClick);
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
