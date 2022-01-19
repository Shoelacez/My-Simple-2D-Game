using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float moveSpeed=11f;
    private Rigidbody2D myPlayer;
    private float movementX;
    private float jumpForce=10f;
    private SpriteRenderer sr;
    private Animator anim;
    private bool isGrounded=false;
    private bool hasCollidedWithKillsPlayer=false;
    HealthBar healthBarScript;
    public int maxHealth=100;
    public int currentHealth;
    public GameOverSreen gameOverSreenScript;

    // Start is called before the first frame update
    void Start()
    {
        myPlayer=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        sr=GetComponent<SpriteRenderer>();
        healthBarScript=FindObjectOfType<HealthBar>();

        currentHealth=maxHealth;
        healthBarScript.setHealth(currentHealth);
        healthBarScript.setMaxHealth(maxHealth);

    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        AnimatePlayer();
    }

    void FixedUpdate() 
    {
        PlayerJump();
    }

    void MovePlayer()
    {
        movementX=Input.GetAxisRaw("Horizontal");
        transform.position+=new Vector3(movementX*moveSpeed,0f,0f)*Time.deltaTime;
    }

    void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            myPlayer.AddForce(new Vector2(0f,jumpForce),ForceMode2D.Impulse);
            isGrounded=false;
        }
    }

    void AnimatePlayer()
    {
        //Walking or Movement
        Run();
        //Attacking
        Attack();
    }

    void Run()
    {
        if (movementX>0f)
        {
            //player is facing right
            sr.flipX=false;
            anim.SetBool("Run",true);
        }
        else if (movementX<0f)
        {
            //Player is moving to the left
            sr.flipX=true;
            anim.SetBool("Run",true);
        }

        else
        {
            //do nothing on the direction the player is facing
            anim.SetBool("Run",false);
        }
    }

    public void Death()
    {
 
            anim.SetBool("Death",true);
            Debug.Log("Player is Dead");
            this.gameObject.SetActive(false);
            GameOver();
    }

    void Attack()
    {
        // To animate the Attack
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("Attack1",true);
        }
        else if(Input.GetMouseButtonUp(0))
        {
            anim.SetBool("Attack1",false);
        }
 
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            // Debug.Log(this.gameObject.name+" is on the "+other.gameObject.name);
            isGrounded=true;
        }
        if (other.gameObject.CompareTag("killsPlayer"))
        {
            hasCollidedWithKillsPlayer=true;
        }

        if (hasCollidedWithKillsPlayer && currentHealth>0f)
        {
            TakeDamage(10);
        }
  
    }

    void TakeDamage(int damage)
    {
        currentHealth-=damage;

        healthBarScript.setHealth(currentHealth);
        Debug.Log("Player's health is "+currentHealth);

        if (currentHealth<10)
        {
            Death();
        }
    }

    public void GameOver()
    {
        gameOverSreenScript.Setup(23);
    }
}
