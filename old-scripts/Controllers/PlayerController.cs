/**
 * FTSWFOS - PlayerController.cs
 *
 * @since       04.01.2017
 * @version     1.0.0.0
 * @author      MLB
 * @copyright   -
 */

/*******************/
/***** IMPORTS *****/
/*******************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**************************************************/
/**************************************************/

/**********************/
/***** CONTROLLER *****/
/**********************/

public class PlayerController : MonoBehaviour {

	/**********************/
	/***** PROPERTIES *****/
	/**********************/

	//PUBLIC
	//------

	public float moveSpeed;
	public float speedMultiplier;
	public float speedIncreaseMilestone;
	public float jumpForce;
	public float jumpTime;
	public float groundCheckRadius;

	public bool isGrounded;

	public LayerMask theGround;

	public Transform groundCheck;

	public GameManager gameManager;

	public AudioSource jumpSound;
	public AudioSource deathSound;

	//PRIVATE
	//-------

	private float jumpTimeCounter;
	private float speedMilestoneCount;
	private float moveSpeedStore;
	private float speedMilestoneCountStore;
	private float speedIncreaseMilestoneStore;

	private bool stoppedJumping;
	private bool canDoubleJump;

	private Rigidbody2D playerRigidbody;

	private Animator playerAnimator;

	/**************************************************/
	/**************************************************/

	/*****************/
	/***** START *****/
	/*****************/

	void Start () {
		this.getComponents ();
		this.setValues ();
	}

	/**************************************************/
	/**************************************************/

	/******************/
	/***** UPDATE *****/
	/******************/

	void Update () {
		this.moves ();
	}

	/**************************************************/
	/**************************************************/

	/**************************/
	/***** GET COMPONENTS *****/
	/**************************/

	private void getComponents () {
		this.playerRigidbody = GetComponent<Rigidbody2D> ();
		this.playerAnimator = GetComponent<Animator> ();
	}

	/**************************************************/
	/**************************************************/

	/*******************/
	/***** SETTERS *****/
	/*******************/

	/*****/
	/***** SET VALUES *****/
	/*****/

	private void setValues () {
		this.setJumpTimeCounter (this.jumpTime);
		this.setSpeedMilestoneCount ();
		this.setMoveSpeedStore ();
		this.setSpeedMilesStoneCountStore ();
		this.setSpeedIncreaseMilestoneStore ();
		this.setStoppedJumping (true);
		this.setCanDoubleJump (true);
	}

	/*****/
	/***** JUMP TIME COUNTER *****/
	/*****/

	private void setJumpTimeCounter (float time) {
		this.jumpTimeCounter = time;
	}

	/*****/
	/***** SPEED STORE *****/
	/*****/

	private void setMoveSpeedStore () {
		this.moveSpeedStore = this.moveSpeed;
	}

	/*****/
	/***** SPEED MILESTONE COUNT *****/
	/*****/

	private void setSpeedMilestoneCount () {
		this.speedMilestoneCount = this.speedIncreaseMilestone;
	}

	/*****/
	/***** SPEED MILESTONE COUNT STORE *****/
	/*****/

	private void setSpeedMilesStoneCountStore () {
		this.speedMilestoneCountStore = this.speedMilestoneCount;
	}

	/*****/
	/***** SPEED INCREASE MILESTONE STORE *****/
	/*****/

	private void setSpeedIncreaseMilestoneStore() {
		this.speedIncreaseMilestoneStore = this.speedIncreaseMilestone;
	}

	/*****/
	/***** STOPPED JUMPING *****/
	/*****/

	private void setStoppedJumping (bool value) {
		this.stoppedJumping = value;	
	}

	/*****/
	/***** CAN DOUBLE JUMP *****/
	/*****/

	private void setCanDoubleJump (bool value) {
		this.canDoubleJump = value;	
	}

	/**************************************************/
	/**************************************************/

	/*******************************/
	/***** HORIZONTAL MOVEMENT *****/
	/*******************************/

	private void moves () {
		
		this.horizontalMovement ();
		this.jump ();

		playerAnimator.SetFloat ("Speed", this.playerRigidbody.velocity.x);
		playerAnimator.SetBool ("isGrounded", this.isGrounded);

	}

	/**************************************************/
	/**************************************************/

	/*******************************/
	/***** HORIZONTAL MOVEMENT *****/
	/*******************************/

	private void horizontalMovement () {

		this.computeMoveSpeed ();
		this.playerRigidbody.velocity = new Vector2 (this.moveSpeed, this.playerRigidbody.velocity.y);
	}

	/**************************************************/
	/**************************************************/

	/******************************/
	/***** COMPUTE MOVE SPEED *****/
	/******************************/

	private void computeMoveSpeed() {
		
		if (this.transform.position.x > this.speedMilestoneCount) {

			this.speedMilestoneCount += this.speedIncreaseMilestone;
			this.speedIncreaseMilestone = this.speedIncreaseMilestone * this.speedMultiplier;
			this.moveSpeed = this.moveSpeed * this.speedMultiplier;

		}

	}

	/**************************************************/
	/**************************************************/

	/****************/
	/***** JUMP *****/
	/****************/

	private void jump () {

		this.isGrounded = this.checkIfGrounded ();

		if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0)) {

			if (this.isGrounded) {
				this.doJump ();
				this.setStoppedJumping (false);
				this.jumpSound.Play ();
			}

			if (!this.isGrounded && this.canDoubleJump) {
				this.doJump ();
				this.setJumpTimeCounter (this.jumpTime);
				this.setStoppedJumping (false);
				this.setCanDoubleJump (false);
				this.jumpSound.Play ();
			}

		}

		if ((Input.GetKey (KeyCode.Space) || Input.GetMouseButton(0)) && !this.stoppedJumping) {

			if (this.jumpTimeCounter > 0) {
				this.doJump ();
				this.jumpTimeCounter -= Time.deltaTime;
			}

		}
			
		if (Input.GetKeyUp (KeyCode.Space) || Input.GetMouseButtonUp(0)) {
			this.setJumpTimeCounter (0);
			this.setStoppedJumping (true);
		}

		if (this.isGrounded) {
			this.setJumpTimeCounter (this.jumpTime);
			this.setCanDoubleJump (true);
		}

	}

	/**************************************************/
	/**************************************************/

	/*****************************/
	/***** CHECK IF GROUNDED *****/
	/*****************************/

	private bool checkIfGrounded () {
		return Physics2D.OverlapCircle(this.groundCheck.position, this.groundCheckRadius, this.theGround);
	}

	/**************************************************/
	/**************************************************/

	/*******************/
	/***** DO JUMP *****/
	/*******************/

	private void doJump () {
		this.playerRigidbody.velocity = new Vector2 (this.playerRigidbody.velocity.x, this.jumpForce);
	}

	/**************************************************/
	/**************************************************/

	/*********************************/
	/***** ON COLLISION ENTER 2D *****/
	/*********************************/

	void OnCollisionEnter2D (Collision2D other) {

		if (other.gameObject.tag == "killbox" && other.otherCollider.GetType() == typeof(BoxCollider2D)) {
			this.gameManager.restartGame ();
			this.moveSpeed = this.moveSpeedStore;
			this.speedMilestoneCount = this.speedMilestoneCountStore;
			this.speedIncreaseMilestone = this.speedIncreaseMilestoneStore;
			this.deathSound.Play ();
		}

		if ((other.gameObject.tag == "killbox" || other.gameObject.tag == "ground") && other.otherCollider.GetType() == typeof(CircleCollider2D)) {
			Physics2D.IgnoreCollision(other.collider, GetComponent<CircleCollider2D> ());
		}
			
	}

}
