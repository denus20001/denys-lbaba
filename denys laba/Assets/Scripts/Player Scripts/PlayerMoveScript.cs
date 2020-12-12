using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMoveScript : MonoBehaviour {

	public static PlayerMoveScript instance;

	public float moveSpeed,jumpForce, jumpTime, jumpTimeCounter, 
	speedMultiplier, speedIncrease, speedCount;

	public AudioSource audioSource;
	public AudioClip coinClip, diedClip;
	public Animator anim;
	private Rigidbody2D rigidbody;
	private Collider2D collider;

	public bool grounded;
	public LayerMask isGround;
	public Transform groundCheck;
	public float groundChecked;

	//public GameManagerScript gameManager;

	public Text scoreText;
	public int coinScore, score, bestScore;
	public float scoreCount, highScoreCount, coinCount, pointsPerSeconds;

	private bool stopJumping;

	void Start () {
		MakeInstance ();
		rigidbody = GetComponent<Rigidbody2D> ();
		collider = GetComponent<Collider2D> ();

		jumpTimeCounter = jumpTime;
		speedCount = speedIncrease;

		stopJumping = true;
	}

	void MakeInstance () {
		if (instance == null) {
			instance = this;
		}
	}	

	void Update () {
		
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundChecked, isGround);
			
		if(transform.position.x > speedCount) {
			speedCount += speedIncrease;
			speedIncrease = speedIncrease * speedMultiplier;
			moveSpeed = moveSpeed * speedMultiplier;
		}

		rigidbody.velocity = new Vector2 (moveSpeed, rigidbody.velocity.y);

		if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {

			if(grounded) {
				rigidbody.velocity = new Vector2 (rigidbody.velocity.x, jumpForce);
				anim.SetTrigger ("Jump");
				stopJumping = false;
			}	
		}

		if((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) && !stopJumping) {
			if(jumpTimeCounter > 0) {
				rigidbody.velocity = new Vector2 (rigidbody.velocity.x, jumpForce);
				jumpTimeCounter -= Time.deltaTime;
			}
		}

		if(Input.GetKeyUp (KeyCode.Space) || Input.GetMouseButtonUp(0)) {
			jumpTimeCounter = 0;
			stopJumping = true;
		} 
			
		if(grounded) {
			jumpTimeCounter = jumpTime;
		}


		scoreCount += pointsPerSeconds = Time.deltaTime;

		if(scoreCount > highScoreCount) {
			highScoreCount = scoreCount;

		}
		scoreText.text = "Score: " + Mathf.Round(scoreCount);

	}

	void OnCollisionEnter2D(Collision2D target) {
		if(target.gameObject.tag == "died" || target.gameObject.tag == "Crates") {
			jumpForce = 0;
			scoreCount = 0;
			anim.SetTrigger ("Died");
			scoreText.gameObject.SetActive (false);
			audioSource.PlayOneShot (diedClip);
			FindObjectOfType<GameManagerScript> ().gameOver (Mathf.RoundToInt(highScoreCount), coinScore);
			FindObjectOfType<GameManagerScript> ().ifPlayerDiedCoinScore(coinScore);
			FindObjectOfType<GameManagerScript> ().ifPlayerDiedScore (Mathf.RoundToInt(highScoreCount));
		}
	} 

	void OnTriggerEnter2D(Collider2D coin) {
		if(coin.tag == "Coin") {
			audioSource.PlayOneShot (coinClip);
			coinScore++;
			FindObjectOfType<GameManagerScript> ().SetCoinScore (coinScore);
			coin.gameObject.SetActive (false);
		}
	}
}














