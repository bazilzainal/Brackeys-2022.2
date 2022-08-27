using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed;
    
    private FightoCharacter attacker;
    private FightoCharacter target;
    
    public void Init(FightoCharacter fightoCharacter, FightoCharacter target)
    {
        this.target = target;
        this.attacker = fightoCharacter;
    }

    private void Update()
    {
        if (target == null)
        {
            return;
        }
        this.transform.position = Vector2.MoveTowards(this.transform.position, target.transform.position, Time.deltaTime * this.speed);
        if (((Vector2)this.transform.position - (Vector2)target.transform.position).magnitude < 0.1f)
        {
            target.TakeDamage(attacker, attacker.AttackDamage);
            Destroy(this.gameObject);
        }
    }
}