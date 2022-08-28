using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadGame : MonoBehaviour
{
    public void Reload()
    {
        var scene = SceneManager.GetActiveScene();
        SceneManager.UnloadScene(scene);
        SceneManager.LoadScene(scene.buildIndex);
    }
}