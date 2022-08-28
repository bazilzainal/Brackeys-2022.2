using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotManager : Singleton<RobotManager>
{

    [SerializeField] private List<Thing> things;

    [SerializeField] private int maxHealth;
    private int health;

    public int Health { get => health; set => health = value; }


    protected override void Awake()
    {
        base.Awake();
        health = maxHealth;
    }

    public void AdjustHealth(int amount, out bool isDead)
    {
        this.health = Mathf.Clamp(this.health + amount, 0, this.maxHealth);

        if (this.health <= 0)
        {
            ProcessDeath();
            isDead = true;
        }
        else
        {
            isDead = false;
        }
    }

    public void ProcessDeath()
    {
        // Call game manager to process death
        this.Health = maxHealth;
        GameManager.instance.ResetGame();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool LowHealth()
    {
        return this.health <= 20;
    }
}

public abstract class Thing { }

