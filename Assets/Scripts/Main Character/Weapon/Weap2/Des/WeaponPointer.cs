using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class WeaponPointer : MonoBehaviour
{   
    public AudioSource attackSound;

    public SpriteRenderer characterRenderer, weaponRenderer;
    public Vector2 PointerPosition { get; set; }
    public Animator animator;

    private bool attackBlocked;
    public bool IsAttacking { get; set; }
 
    public float delay = 0;
    public Transform circleRange;
    public float radius;

    public static WeaponPointer instance;
    public Quest quest;
    public QuestLN questln;
    public QuestMB questmb;

    private void Awake() {
        instance = this;
    }

    private void Update() {

        if(IsAttacking)
            return;
            
        Vector2 direction = (PointerPosition - (Vector2)transform.position).normalized;
        transform.right = direction;

        Vector2 scale = transform.localScale;
        if (direction.x < 0)
        {
            scale.y = -1;
        }
        else if (direction.x > 0)
        {
            scale.y = 1;
        }
        transform.localScale = scale;


        
    }

    public void ResetIsAttacking()
    {
        IsAttacking = false;
    }

    public void Attack(){
        if(attackBlocked)
        return;
        attackSound.Play();
        
        IsAttacking = true;
        attackBlocked = true;
        StartCoroutine(DelayAttack());

    }

    private IEnumerator DelayAttack(){
        yield return new WaitForSeconds(delay);
        attackBlocked = false;
    }

    private void OnDrawGizmosSelected() {

        Gizmos.color = Color.red;
        Vector3 position = circleRange == null  ? Vector3.zero : circleRange.position;
        Gizmos.DrawWireSphere(position, radius);
    }
    
    public  void DetectColliders(){

        foreach (Collider2D collider in Physics2D.OverlapCircleAll(circleRange.position,radius))
        {
            Health health;
            MinibossHP minibossHP;
            RangeMonsHP rangeMonHP;
            BossHP bossHP;
            RuinProtectorHP ruinProtectorHP;
            GrimsonHP grimsonHP;
            SpecificEnemyScriptDrop specialMonster;
            if(health = collider.GetComponent<Health>())
            {
                health.GetHit(1, transform.parent.gameObject);
                    if (quest.isActive)
                    { 
                        quest.goal.EnemyKilled();
                        if(quest.goal.IsReached())
                        {
                            quest.Complete();
                        } 
                    }  
            }

            
            else if(minibossHP = collider.GetComponent<MinibossHP>())
            {
                minibossHP.GetHit(1, transform.parent.gameObject);
                if (questmb.isActive)
                    { 
                        questmb.goal.EnemyKilled();
                    if(questmb.goal.IsReached())
                    {
                        questmb.CompleteMB();
                    } 
                }
            }

            else if(rangeMonHP = collider.GetComponent<RangeMonsHP>())
            {
                rangeMonHP.GetHit(1, transform.parent.gameObject);
                        if (questln.isActive)
                    { 
                        questln.goal.EnemyKilled();
                    if(questln.goal.IsReached())
                    {
                        questln.CompleteLN();
                    } 
                }
            }

            else if(specialMonster = collider.GetComponent<SpecificEnemyScriptDrop>())
            {
                specialMonster.GetHit(1, transform.parent.gameObject);
            }

            else if(bossHP = collider.GetComponent<BossHP>())
            {
                bossHP.GetHit(1, transform.parent.gameObject);
            }
            else if(ruinProtectorHP = collider.GetComponent<RuinProtectorHP>())
            {
                ruinProtectorHP.GetHit(1, transform.parent.gameObject);
            }
            else if(grimsonHP = collider.GetComponent<GrimsonHP>())
            {
                grimsonHP.GetHit(1, transform.parent.gameObject);
            }
            
        }
    }
}
