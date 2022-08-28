using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fighto : MonoBehaviour
{
    public FightoCharacter[] klick;
    public FightoCharacter[] robots;
    public FightoCharacter[] humans;

    public AdventureSceneData humansWin;
    public AdventureSceneData humansWinWithJetpack;
    public AdventureSceneData robotsWin;
    public AdventureSceneData robotsWinWithJetpack;
    private void Update()
    {
        bool sideHumans = klick[0].Target != null && robots.Any(c=> c == klick[0].Target);
        if (RobotManager.instance.LowHealth() && GameManager.instance.HasJetpack)
        {
            if (sideHumans)
            {
                GameManager.instance.LoadScene(humansWinWithJetpack);
            }
            else
            {
                GameManager.instance.LoadScene(robotsWinWithJetpack);
            }
        }
        else if (IsDead(robots))
        {
            GameManager.instance.LoadScene(humansWin);
        }
        else if (IsDead(humans))
        {
            GameManager.instance.LoadScene(robotsWin);
        }
    }

    private bool IsDead(FightoCharacter[] fightoCharacters)
    {
        return fightoCharacters.All(c => c.IsDead);
    }
}