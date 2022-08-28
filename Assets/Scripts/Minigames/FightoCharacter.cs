using System.Linq;
using UnityEngine;

public class FightoCharacter : MonoBehaviour
{
    [SerializeField]
    private bool isPlayer;

    [SerializeField]
    private int health;
    public bool IsDead => health <= 0;


    public int AttackDamage;
    [SerializeField]
    private float attackSpeed;

    [SerializeField]
    private Transform bulletOrigin;
    [SerializeField]
    private Bullet bullet;

    [SerializeField]
    private FightoCharacter target;
    public FightoCharacter Target => target;

    private float timer;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Camera cam;

    private FightoCharacter[] allCharacters;
    public AudioClip Clip;

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

        MusicManager.instance.PlayEffect(this.Clip);

        Vector3 vectorToTarget = this.target.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

        var newBullet = Instantiate(bullet, bulletOrigin.position, q);
        newBullet.Init(this, this.target);
    }

    public void TakeDamage(FightoCharacter attacker, int attackerAttackDamage)
    {
        this.target = attacker;

        if (isPlayer)
        {
            RobotManager.instance.AdjustHealth(-attackerAttackDamage, out bool isDead);
            if (isDead)
            {
                PlayDeathAnim();
            }
        }
        else
        {
            this.health -= attackerAttackDamage;
            if (this.health <= 0)
            {
                PlayDeathAnim();
            }
        }

        PlayHitAnim();
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