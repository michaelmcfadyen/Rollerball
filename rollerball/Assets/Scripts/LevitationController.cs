using UnityEngine;
using System.Collections;

public class LevitationController : MonoBehaviour {

	public float hoverForce = 12f;
	public int delay;
	public EnemyMovement enemyMovement;

	private bool isActive;
	private Light light;

	// Use this for initialization
	void Start () {
		isActive = false;
		light = (Light)transform.FindChild("SpotLight").GetComponent(typeof(Light));
		light.enabled = false;

		InvokeRepeating ("switchLevitation", delay, delay);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void switchLevitation(){
		isActive = !isActive;
		light.enabled = !light.enabled;
	}

	void OnTriggerStay(Collider other){

		if (!isActive) {
			other.attachedRigidbody.AddForce(Vector3.down * hoverForce, ForceMode.Acceleration);
			other.attachedRigidbody.constraints = RigidbodyConstraints.None;
			return;
		}

		other.attachedRigidbody.AddForce (Vector3.up * hoverForce);
		other.attachedRigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
		Debug.Log ("Inside ");
	}
}
