using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	private static readonly string LOSE_MESSAGE = "You Lost!";
	private static readonly string DRAW_MESSAGE = "DRAW!!";
	private static readonly string WIN_MESSAGE = "You Win!";

	public Slider healthSilder;
	public Text gameOverText;
	public Text countText;
	public EnemyMovement enemyScript;
	public PlayerMovement playerMovement;
	public int enemyDamage;

	private int health;
	private int count;

	// Use this for initialization
	void Start () {
		health = 100;
		healthSilder.value = health;
		count = 0;
		countText.text = "Count: " + count.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isGameOver ()) {

			disableMovement();

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

	public bool isGameOver() {
		return GameObject.FindGameObjectsWithTag ("Pickup").Length <= 0 || health <= 0;
	}
	
	public bool hasWon(){
		return count > enemyScript.score ();
	}
	
	public bool isDraw(){
		return count == enemyScript.score();
	}
	
	public int getHealth(){
		return health;
	}

	public void reduceHealth(int h){
		health -= h;
		healthSilder.value = health;
	}
	
	void updateGameOverText(string text){
		gameOverText.text = text;
	}

	void disableMovement(){
		playerMovement.enabled = false;
		enemyScript.enabled = false;
		enemyScript.disablePathFinding();
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Pickup") {
			other.gameObject.SetActive (false);
			Destroy(other, 1f);
			count++;
			countText.text = "Count: " + count.ToString ();
		} else
			;//reduceHealth(enemyDamage);
	}
}
