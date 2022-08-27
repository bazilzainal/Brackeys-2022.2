using System.Linq;
using UnityEngine;

public class FightoCharacter : MonoBehaviour
{
    [SerializeField]
    private bool isPlayer;

    [SerializeField]
    private int health;

    public int AttackDamage;
    [SerializeField]
    private float attackSpeed;

    [SerializeField]
    private Transform bulletOrigin;
    [SerializeField]
    private Bullet bullet;

    [SerializeField]
    private FightoCharacter target;

    private float timer;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Camera cam;

    private FightoCharacter[] allCharacters;
    private void Awake()
    {
        allCharacters = GameObject.FindObjectsOfType<FightoCharacter>();
        ResetCooldown();
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            if (isPlayer && cam != null)
            {
                var mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
                this.target = allCharacters.OrderBy(c => (c.transform.position - mousePosition).sqrMagnitude).FirstOrDefault();
            }
            if (!isPlayer || InputManager.instance.IsKeyDown(GameKey.Action))
            {
                ResetCooldown();
                ShootBullet();
            }
        }
    }

    private void ResetCooldown()
    {
        timer = attackSpeed * UnityEngine.Random.Range(0.9f, 1.1f);
    }

    private void ShootBullet()
    {
        if (target == null || !target.gameObject.activeInHierarchy)
        {
            return;
        }
        
        var newBullet = Instantiate(bullet, bulletOrigin.position, bulletOrigin.rotation);
        newBullet.Init(this, this.target);
    }

    public void TakeDamage(FightoCharacter attacker, int attackerAttackDamage)
    {
        this.target = attacker;
        this.health -= attackerAttackDamage;
        PlayHitAnim();
        if (this.health <= 0)
        {
            PlayDeathAnim();
        }
    }

    private void PlayDeathAnim()
    {
        this.gameObject.SetActive(false);
        animator.SetTrigger("death");
    }

    private void PlayHitAnim()
    {
        animator.SetTrigger("hit");
    }
}