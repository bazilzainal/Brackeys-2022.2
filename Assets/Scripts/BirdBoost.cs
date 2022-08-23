﻿using UnityEngine;

public class BirdBoost : MonoBehaviour
{
    public float BirdSpeed;
    public float BoostForce;
    public float MaxBoostTime;
    public float MaxCooldown;
    private float currentBoostTime;
    private float currentCooldown;
    public Rigidbody2D RB;
    
    private void FixedUpdate()
    {
        RB.velocity = new Vector2(BirdSpeed, RB.velocity.y);
        
        currentCooldown -= Time.deltaTime;
        if (currentCooldown > 0f)
        {
            return;
        }
        if (InputManager.instance.IsKeyDown(GameKey.Action))
        {
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