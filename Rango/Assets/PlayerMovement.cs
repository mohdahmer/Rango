using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   public Transform gameOver;
   public Rigidbody2D rb;
   public KeyCode MoveLeft;
   public KeyCode MoveRight;
   public KeyCode Jump;
   private Animator anim;
   public float speed ;
   public float jump = 160f;
   private float y;
   bool grounded = true;

   void Start()
   {
      anim = gameObject.GetComponent<Animator>();
   }

    void FixedUpdate()
   {
     if(Input.GetKey(MoveLeft)) 
     {
        transform.localScale=new Vector3(-1,1,1);
        rb.AddForce(new Vector2(-speed, 0));
        anim.SetBool("isWalk", true);
     }
     else if(Input.GetKey(MoveRight)) 
     {
        transform.localScale=new Vector3(1,1,1);
        rb.AddForce(new Vector2(speed, 0));
        anim.SetBool("isWalk", true);
     }
     else if(Input.GetKey(Jump) && grounded==true)
     {
        rb.AddForce(new Vector2(0, jump));
        grounded=false;
     }

     if(rb.velocity.x==0)
     {
        anim.SetBool("isWalk", false);
     }
     else if(rb.velocity.x>12f || rb.velocity.x<-12f)
     {
        anim.SetBool("isRun",true);
        anim.SetFloat("AnimationSpeed", 1f);
        //Debug.Log("run");
        if(rb.velocity.x>20f || rb.velocity.x<-20f)
        anim.SetFloat("AnimationSpeed", 2f);
     }
     else
     {
        anim.SetBool("isRun",false);
     }
    
     if(rb.velocity.y==0)
     {
        grounded=true;
     }

     y = Mathf.Clamp(transform.position.y, -10f, 4f);
     transform.position = new Vector3(rb.position.x, y, 0);
     
     if(transform.position.y<-9f)
     {
        gameOver.gameObject.SetActive(true);
     }
   }
}