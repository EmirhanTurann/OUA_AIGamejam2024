using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Animator Animator;
    public bool isGround;
    public bool isMoved;
    public bool isJump = false;
    public float speed =0.0f;
    public float jumpForce = 0.0f;
    float jumpDelay = 1;
    
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        Animator.SetBool("isMovement", isMoved);
        if (isMoved)
        {
            rb.velocity = new Vector3(rb.velocity.x,rb.velocity.y,speed*Time.deltaTime);
        }
        if (isGround && !isJump && Input.GetKey(KeyCode.Space))
        {
            StartCoroutine(JumpCoroutine());
        }
     
    }

    IEnumerator JumpCoroutine() 
    {
        isJump = true;
        GetComponent<CapsuleCollider>().material.dynamicFriction = 0;
        GetComponent<CapsuleCollider>().material.staticFriction = 0;
        GetComponent<CharacterAbility>().isObstacle=false;
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Force);
        Animator.SetTrigger("isJump");
        yield return new WaitForSeconds(jumpDelay);
        isJump = false;
        yield return new WaitForSeconds(1f);
        GetComponent<CapsuleCollider>().material.dynamicFriction = 1;
        GetComponent<CapsuleCollider>().material.staticFriction = 1;
    }
    
    void OnDrawGizmosSelected()
    {
       
            // Draws a blue line from this transform to the target
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, Vector3.down);
          


    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            

        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        

        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = false;
            
        }
    }

}
