using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerController : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public Animator myAnimator;
    public float speed = 2f;
    public float jumpForce = 4f;
    public bool IsFacingRight = true;
    public bool IsGrounded = false;
    public bool ArialControl = false;

    [Header("Shooting")]
    public Transform ShootPoint;
    public GameObject ProjectilePrefab;
    public float ShootSpeed = 5f;
	
	// Update is called once per frame
	void Update ()
	{
        // STEP 1: MOVING
	    var h = Input.GetAxis("Horizontal");
	    if (IsGrounded || ArialControl)
	    {
	        myRigidbody.velocity = new Vector2(speed * h, myRigidbody.velocity.y);
	    }

        // STEP 2: ANIMATING
        myAnimator.SetFloat("Speed",Mathf.Abs(h));

        // STEP 3: FLIPPING
	    if (IsFacingRight)
	    {
	        if (h < 0)
	        {
                transform.localScale = new Vector3(-1f, 1f, 1f);
	            IsFacingRight = false;
	        }
	    }
	    else
	    {
	        if (h > 0)
	        {
	            transform.localScale = new Vector3(1f, 1f, 1f);
	            IsFacingRight = true;
	        }
        }

        // Step 4: JUMPING
	    if (IsGrounded)
	    {
	        if (Input.GetButtonDown("Jump"))
	        {
                myRigidbody.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
	        }
	    }

        // STEP 5: SHOOTING (Extra)
	    if (Input.GetButtonDown("Fire1"))
	    {
	        myAnimator.SetTrigger("Shoot");
	    }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            IsGrounded = true;
            myAnimator.SetBool("IsGrounded", true);
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            IsGrounded = false;
            myAnimator.SetBool("IsGrounded", false);
        }
        
    }

    public void ShootGun()
    {
        Debug.Log("Shoot Gun!");
        GameObject projectile = GameObject.Instantiate(ProjectilePrefab);
        projectile.transform.position = ShootPoint.position;

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (IsFacingRight)
        {
            projectile.transform.localScale = new Vector3(1f, 1f);
            rb.velocity = ShootPoint.right * ShootSpeed;
        }
        else
        {
            projectile.transform.localScale = new Vector3(-1f, 1f);
            rb.velocity = -ShootPoint.right * ShootSpeed;
        }
        Destroy(projectile, 2f);
    }
}