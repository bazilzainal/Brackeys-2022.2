using UnityEngine;

public class FlappyCollision : MonoBehaviour
{
    [SerializeField]
    private int damageOnHit;
    private void OnCollisionEnter2D(Collision2D other)
    {
        RobotManager.instance.AdjustHealth(damageOnHit, out bool isDead);
    }
}