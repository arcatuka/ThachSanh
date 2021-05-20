using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;
	public Rigidbody2D rb;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;
	public int health = 1000;
	// Update is called once per frame
	public void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			animator.SetBool("IsJumping", true);
		}
		if (hp.health <= 0)
		{
			animator.SetTrigger("IsDead");
			Destroy(gameObject,2f);

			Death();
			
			


		}

	}
	public void Death()
	{
		
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}


	public void OnLanding ()
	{
		animator.SetBool("IsJumping", false);
	}


	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}
	void OnCollisionEnter2D(Collision2D coll) //move with the flatfrom
	{
		if (coll.gameObject.tag == "moveflat")
		{
			this.transform.parent = coll.transform;
		}
	}
	void OnCollisionExit2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "moveflat")
		{
			this.transform.parent = null;
		}
	}
	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag("Spike"))
		{

			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

		}
	
	}
	private void OnTriggerExit2D(Collider2D other)
	{ if (other.gameObject.CompareTag("flyflat"))
		{
			this.transform.parent = null;
		} }

}
