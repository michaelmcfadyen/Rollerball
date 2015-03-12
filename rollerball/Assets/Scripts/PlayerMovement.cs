using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	public float speedMultiplier;
	public PlayerHealth playerHealth;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate(){
		float vertical = Input.GetAxis ("Vertical");
		float horizontal = Input.GetAxis ("Horizontal");

		Vector3 movement = new Vector3 (horizontal, 0.0f, vertical);

		GetComponent<Rigidbody> ().AddForce (movement * speedMultiplier * Time.deltaTime);
	}
}
