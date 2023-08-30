using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuicideEnemy : MonoBehaviour
{
    public float speed; 
    public float checkRaduis;
    public float attackRaduis;
    [SerializeField] private int attackDamage = 0;

    public LayerMask player;
    private Rigidbody2D rb2;
    private Animator anim;
    private Vector2 movement;
    private Transform target;
    private Vector3 direction;
    
    private bool facingRight = false;
    private bool  isInchangeRange;
    private bool  isInattackRange;
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    //for player taking damage one at a time
    public float invulTime = 1f; 
    private bool invulnerable = false;

    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }


    void Update()
    {     
        anim.SetBool("isRunning", isInchangeRange);
        isInchangeRange = Physics2D.OverlapCircle(transform.position, checkRaduis, player);
        isInattackRange = Physics2D.OverlapCircle(transform.position, attackRaduis, player);
        direction = target.position - transform.position;
        direction.Normalize();
        movement = direction;

        if (target.transform.position.x < gameObject.transform.position.x && facingRight){
            Flip ();
        }

        if (target.transform.position.x > gameObject.transform.position.x && !facingRight){
            Flip ();
        }
    }

    void Flip(){
        facingRight = !facingRight;
        Vector3 tmpScale = gameObject.transform.localScale;
        tmpScale.x *= -1;
        gameObject.transform.localScale = tmpScale;
    }
        
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            if(!invulnerable){
            other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
            anim.Play("attack");    
            }
        }
    }

    private void FixedUpdate() {

        if(isInchangeRange && !isInattackRange){    
        MoveCharacter(movement); 
    
        }

        if(isInattackRange){
        AttackCharacter(); 
        
        }
        
        if(!isInattackRange && !isInchangeRange){
            anim.Play("idle");
        }
    }

    private void MoveCharacter(Vector2 direction){
    rb2.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    
    }

    private void AttackCharacter(){
    
        
        if(timeBtwAttack <= 0){
            
            anim.Play("attack");
            timeBtwAttack = startTimeBtwAttack;

        } else{
            timeBtwAttack -= Time.deltaTime;
        }
    } 

    IEnumerator JustHurt(){
        invulnerable = true;
        yield return new WaitForSeconds(invulTime);
        invulnerable = false;
    }
    
}
