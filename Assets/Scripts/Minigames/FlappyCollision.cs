using UnityEngine;

public class FlappyCollision : MonoBehaviour
{
    [SerializeField]
    private int damageOnHit;

    public AudioClip Clip;
    private void OnCollisionEnter2D(Collision2D other)
    {
        RobotManager.instance.AdjustHealth(damageOnHit, out bool isDead);
        MusicManager.instance.PlayEffect(Clip);
    }
}