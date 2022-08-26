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

    public bool AdjustHealth(int amount)
    {

        this.health += amount;

        if (this.health <= 0)
        {
            ProcessDeath();
        }

        return true;
    }

    public bool IncHealth(int heal)
    {
        this.health += heal;

        return true;
    }

    public bool ProcessDeath()
    {
        // Call game manager to process death
        this.Health = maxHealth;
        GameManager.instance.ResetGame();

        return true;
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

public abstract class Thing { }

