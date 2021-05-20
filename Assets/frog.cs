using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frog : MonoBehaviour
{
    
    [SerializeField] Transform Player;
    [SerializeField] float range;
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D rb;
    public Animator animator;
    public bool attacking = false;
    public Collider2D trigger;
    public float attackdelay = 0.3f;
    public int health = 20;
    public int dmg = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //distance to player
        float DTplayer = Vector2.Distance(transform.position, Player.position);
        //chase player
        if(DTplayer < range)
        {
            rb.velocity = new Vector2(0, 0);
            attacking = true;
            trigger.enabled = true;
            attackdelay = 1f;
            chaseplayer();
            animator.SetBool("frogjump", true);
        }
        else { stopchase();
            animator.SetBool("frogjump", false);
        }
        if (health <= 0)
        {
            
            
            Destroy(gameObject);
        }


    }
    private void chaseplayer()
    {
        //chase direction
        if(transform.position.x < Player.position.x)
        { rb.velocity = new Vector2 (speed, 0);
            transform.localScale = new Vector2(-3,3);


        }
        else 
        { rb.velocity = new Vector2(-speed, 0);
            transform.localScale = new Vector2(3, 3);
            
        }
        
    }
    private void stopchase()
    { rb.velocity = new Vector2(0, 0);
      }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger != true && col.CompareTag("Player"))
        {
            col.SendMessageUpwards("tkdmg", dmg);
        }
    }
    void Damage(int damage)
    {
        health -= damage;
    }

}
    
