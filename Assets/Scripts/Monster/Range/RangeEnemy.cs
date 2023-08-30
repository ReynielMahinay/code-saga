using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class RangeEnemy : MonoBehaviour
{
    public float speed; 
    public float checkRaduis;
    public float attackRaduis;
    public float retreatRadius;

    public LayerMask player;
    private Rigidbody2D rb2;
    private Animator anim;
    private Vector2 movement;
    private Transform target;
    private Vector3 direction;

    public AudioSource Attack;
    
    private bool facingRight = false;
    private bool  isInchangeRange;
    private bool  isInattackRange;

    private float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject projectile;
    

    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }


    void Update()
    {     
        anim.SetBool("isRunning", isInchangeRange);
        isInchangeRange = Physics2D.OverlapCircle(transform.position, checkRaduis, player);
        isInattackRange = Physics2D.OverlapCircle(transform.position, attackRaduis, player);
        direction = target.position - transform.position;
        direction.Normalize();

        if(Vector2.Distance(transform.position, target.position) < retreatRadius){
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
        }

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
    anim.Play("attack");

        if(timeBtwShots <= 0){
            Attack.Play();
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        } else{
            timeBtwShots -= Time.deltaTime;
        }

        
    } 
}
