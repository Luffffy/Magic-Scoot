using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Rigidbody2D myRigidbody;
    public Animator myAnimator;
    public float currentHealth = 2f;
    public float maxHealth = 2f;
    public float speed = 1f;
    public float maxSpeed = 5f;
    public float jumpForce = 4f;
    public bool isFacingRight = true;
    public bool isGrounded = false;
    public bool hitWall = false;
    public bool isDead = false;
    public bool aerialControl = false;
    public float currentSpeed = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Moving
        var h = Input.GetAxis("Horizontal");
        if ((isGrounded || aerialControl) && myRigidbody.velocity.magnitude < maxSpeed)
        {
            currentSpeed = myRigidbody.velocity.magnitude;
            myRigidbody.velocity += new Vector2(speed * h, myRigidbody.velocity.y);
        }

        
        // ANIMATING
        myAnimator.SetFloat("Speed", Mathf.Abs(h));

        // Facing Direction
        if (isFacingRight)
        {
            if (h < 0)
            {
               transform.localScale = new Vector3(-1f, 1f, 1f);
               isFacingRight = false;
            }
        }
        else
        {
            if (h > 0)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
                isFacingRight = true;
            }
        }

        // Jump
        if (isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                myRigidbody.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            isGrounded = true;
            myAnimator.SetBool("isGrounded", true);
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            isGrounded = false;
            myAnimator.SetBool("isGrounded", false);
        }
    }

    public void takeDamage(float damage)
    {
        if(!isDead)
        {
            Debug.Log("Taking Damage: " + damage);
            currentHealth -= damage;
            if(currentHealth <=0)
            {
                currentHealth = 0;
                Die();
            }
        }
    }

    public void Die()
    {
        Debug.Log("Dead");
        isDead = true;
    }
}
