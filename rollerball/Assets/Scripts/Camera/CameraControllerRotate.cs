using UnityEngine;
using System.Collections;

public class CameraControllerRotate : MonoBehaviour {

	public GameObject player;
	public float speed;

	private Vector3 offset;
	
	// Use this for initialization
	void Start () {
		offset = transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = player.transform.position + offset;
		Debug.Log("PLAYER FORWARD: " + player.transform.forward);
		//transform.forward = player.transform.forward;
		//transform.forward = new Vector3 (player.transform.forward.x, player.transform.forward.y, player.transform.forward.z);
		//transform.eulerAngles = Vector3(transform.rotation.x, transform.rotation.y, )
		//		transform.rotation = Quaternion.Lerp(transform.rotation, player.transform.rotation,Time.deltaTime * speed);
//		transform.eulerAngles = new Vector3 (30f, transform.rotation.y, 0f);
	}
}
