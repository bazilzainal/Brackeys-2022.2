using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private AdventureSceneData data;
    [SerializeField] private AdventureScene scene;

    // Start is called before the first frame update
    void Start()
    {
        this.scene.BindData(this.data);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
