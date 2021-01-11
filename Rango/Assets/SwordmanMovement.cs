using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class SwordmanMovement : MonoBehaviour
{
    public AIPath aiPath;
    public Rigidbody2D rb;
    public float speed;
    public float jump;
    private Animator anim;
    public KeyCode Attack;
    public KeyCode Left;
    public KeyCode Right;
    public KeyCode Jump;
    bool grounded = true;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if(Input.GetKey(Attack)) 
        {
            anim.SetBool("isRun", false);
            anim.SetBool("isJump", false);
            anim.SetBool("isAttack", true);
        }

        else if(Input.GetKey(Left) || aiPath.desiredVelocity.x < 0.01f) 
        {
            transform.localScale=new Vector3(1,1,1);
            anim.SetBool("isAttack", false);
            anim.SetBool("isJump", false);
            anim.SetBool("isRun", true);
            rb.AddForce(new Vector2(-speed, 0));
        }

        else if(Input.GetKey(Right) || aiPath.desiredVelocity.x > 0.01f) 
        {
            transform.localScale=new Vector3(-1,1,1);
            anim.SetBool("isAttack", false);
            anim.SetBool("isJump", false);
            anim.SetBool("isRun", true);
            rb.AddForce(new Vector2(speed, 0));
            Debug.Log(rb.velocity.x);
        }

        else if(Input.GetKey(Jump) && grounded == true) 
        {
            anim.SetBool("isRun", false);
            anim.SetBool("isAttack", false);
            anim.SetBool("isJump", true);
            rb.AddForce(new Vector2(0, jump));
            grounded = false;
            Debug.Log(rb.velocity.y);
        }

        if(rb.velocity.x==0)
        {
            anim.SetBool("isRun", false);
        }

        if(rb.velocity.y==0)
        {
            grounded=true;
            anim.SetBool("isJump", false);
        }
    }
}
