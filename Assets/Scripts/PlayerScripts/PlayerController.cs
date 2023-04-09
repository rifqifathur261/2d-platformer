using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //movement
    public float speed, jumpForce;
    public bool isFacingRight, isJump;
    public Rigidbody2D rb;

    //ground check
    public float radius;
    public Transform groundChecker;
    public LayerMask whatsGround;

    //animation
    Animator anim;
    string walk_parameter = "walk";
    string idle_parameter = "idle";
    string jump_parameter = "jump";
    string land_parameter = "land";

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        jump();
    }

    void FixedUpdate()
    {
        movement();
    }

    void movement(){
        float move = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        if(move != 0){
            anim.SetTrigger(walk_parameter);
        }else{
            anim.SetTrigger(idle_parameter);
        }

        if(move > 0 && !isFacingRight){
            transform.eulerAngles = Vector2.zero;
            isFacingRight = true;
        }else if(move < 0 && isFacingRight){
            transform.eulerAngles = Vector2.up * 180;
            isFacingRight = false;
        }
    }

    void jump(){
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded()){
            rb.velocity = Vector2.up * jumpForce;
        }

        if(!isGrounded() && !isJump){
            anim.SetTrigger(jump_parameter);
            isJump = true;
        }else if(isGrounded() && isJump){
            anim.SetTrigger(land_parameter);
            isJump = false;

        }
    }

    bool isGrounded(){
        return Physics2D.OverlapCircle(groundChecker.position, radius,      whatsGround);
    }

    void OnDrawGizmos(){
        Gizmos.DrawWireSphere(groundChecker.position, radius);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Water"))
        {
            GoalManager.singleton.CollectWater();
            Destroy(other.gameObject);
        }else if(other.CompareTag("Goal")){
            if(GoalManager.singleton.canEnter){
                print("Congratulations!");
            }
        }
    }
}
