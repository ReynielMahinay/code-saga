using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public float speed; 
    public float attackRaduis;
    public float attackRaduisRage;

    public LayerMask player;
    private Rigidbody2D rb2;
    private Animator anim;
    private Vector2 movement;
    private Transform target;
    private Vector3 direction;
    
    private bool facingRight = false;
    private bool  isInattackRange;
    private bool  isInattackRangeRage;

     //for player taking damage one at a time
    public float invulTime = 1f; 
    private bool invulnerable = false;
    public static bool bossAwake;

    //attack
    [SerializeField] private int attackDamage = 0;

    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
        bossAwake = false;
    }


    void Update()
    {     
        isInattackRange = Physics2D.OverlapCircle(transform.position, attackRaduis, player); //range of attack \
        isInattackRangeRage = Physics2D.OverlapCircle(transform.position, attackRaduisRage, player);
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

        if(!isInattackRange){
            anim.SetTrigger("running");
        MoveCharacter(movement); 
        }

        if(isInattackRange){
            anim.SetTrigger("canAtack");
        }
        if(isInattackRangeRage){
            anim.SetTrigger("rageAttack");
        }
    }

    //Movement fucntion
    private void MoveCharacter(Vector2 direction){
        if(bossAwake){
            rb2.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
        }
    }

    IEnumerator JustHurt(){
        invulnerable = true;
        yield return new WaitForSeconds(invulTime);
        invulnerable = false;
    }

    private void BossAwake(){
        anim.SetTrigger("awake");
        bossAwake = true;
    }

}
