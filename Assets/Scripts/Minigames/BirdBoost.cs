using UnityEngine;

public class BirdBoost : MonoBehaviour
{
    public float BirdSpeed;
    public float BoostForce;
    public float MaxBoostTime;
    public float MaxCooldown;
    private float currentBoostTime;
    private float currentCooldown;
    public Rigidbody2D RB;
    public AudioClip Clip;
    private void FixedUpdate()
    {
        RB.velocity = new Vector2(BirdSpeed, RB.velocity.y);

        var offset = Vector2.Dot(transform.up, Vector2.up) -1f;
        RB.AddTorque(offset * Time.deltaTime * 20f, ForceMode2D.Impulse);
        currentCooldown -= Time.deltaTime;
        if (currentCooldown > 0f)
        {
            return;
        }
        if (InputManager.instance.IsKeyDown(GameKey.Action))
        {
            MusicManager.instance.PlayEffect(Clip);
            currentBoostTime += Time.deltaTime;
            if (currentBoostTime > MaxBoostTime)
            {
                currentBoostTime = 0;
                currentCooldown = MaxCooldown;
            }
            RB.AddForce(new Vector2(0, BoostForce * Time.deltaTime));
        }
        else
        {
            currentBoostTime = 0;
            currentCooldown = MaxCooldown;
        }
    }
}