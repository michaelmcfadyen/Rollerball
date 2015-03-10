using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	private static readonly string LOSE_MESSAGE = "You Lost!";
	private static readonly string DRAW_MESSAGE = "DRAW!!";
	private static readonly string WIN_MESSAGE = "You Win!";

	public float speedMultiplier;
	public Text countText;
	public Slider healthSilder;
	public Text gameOverText;
	public EnemyMovement enemyScript;

	private int count;
	private int health;

	// Use this for initialization
	void Start () {
		health = 100;
		count = 0;
		healthSilder.value = health;
		countText.text = "Count: " + count.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isGameOver ()) {
			if(health <= 0)
				updateGameOverText(LOSE_MESSAGE);
			else if(isDraw())
				updateGameOverText(DRAW_MESSAGE);
			else if(!hasWon())
				updateGameOverText(LOSE_MESSAGE);
			else
				updateGameOverText(WIN_MESSAGE);
		}
	}

	void FixedUpdate(){
		float vertical = Input.GetAxis ("Vertical");
		float horizontal = Input.GetAxis ("Horizontal");

		Vector3 movement = new Vector3 (horizontal, 0.0f, vertical);

		GetComponent<Rigidbody> ().AddForce (movement * speedMultiplier * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Pickup") {
			other.gameObject.SetActive (false);
			count++;
			countText.text = "Count: " + count.ToString ();
		} else {
			health -= 10;
			healthSilder.value = health;
		}
	}

	public bool isGameOver() {
		return GameObject.FindGameObjectsWithTag ("Pickup").Length <= 0 || health <= 0;
	}

	public bool hasWon(){
		return count > enemyScript.score ();
	}

	public bool isDraw(){
		return count == enemyScript.score();
	}

	void updateGameOverText(string text){
		gameOverText.text = text;
	}
}
