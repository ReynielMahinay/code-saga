using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed; 
    public float checkRaduis;
    public float attackRaduis;

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


    //attack
    [SerializeField] private int attackDamage = 0;

    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }


    void Update()
    {     
        anim.SetBool("isRunning", isInchangeRange);
        isInchangeRange = Physics2D.OverlapCircle(transform.position, checkRaduis, player); //range of agro
        isInattackRange = Physics2D.OverlapCircle(transform.position, attackRaduis, player); //range of attack 
        direction = target.position - transform.position;
        direction.Normalize();
        movement = direction;

        //if statement for flipping the monster
        if (target.transform.position.x < gameObject.transform.position.x && facingRight){
            Flip ();
        }

        if (target.transform.position.x > gameObject.transform.position.x && !facingRight){
            Flip ();
        }
    }

    //doing damage
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
               if(!invulnerable){
                other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
                  StartCoroutine(JustHurt());
               }
        }
    }

    //where flip function
    void Flip(){
        facingRight = !facingRight;
        Vector3 tmpScale = gameObject.transform.localScale;
        tmpScale.x *= -1;
        gameObject.transform.localScale = tmpScale;
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

    //Movement fucntion
    private void MoveCharacter(Vector2 direction){
    rb2.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    anim.SetBool("isRunning", isInchangeRange);
    
    }

    //attack
    private void AttackCharacter(){
    
        if(timeBtwAttack <= 0){
            timeBtwAttack = startTimeBtwAttack;
            anim.Play("attack");
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
