using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour {

	public Text countText;
	NavMeshAgent nav;
	Transform player;
	int count;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		nav = GetComponent <NavMeshAgent> ();
	}

	void Awake()
	{
		count = 0;
		countText.text = "Enemy Count: 0";
	}
	
	// Update is called once per frame
	void Update () {

		GameObject[] objects = GameObject.FindGameObjectsWithTag ("Pickup");
		float distance = float.MaxValue;
		GameObject closest = null;

		if (objects.Length == 0) {
			nav.SetDestination (player.position);
			return;
		}

		foreach(GameObject o in objects){
			float myDistance = Vector3.Distance(transform.position, o.transform.position);
			if(myDistance < distance){
				closest = o;
				distance = myDistance;
			}
		}
		nav.SetDestination (closest.transform.position);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Pickup") {
			other.gameObject.SetActive (false);
			Destroy(other, 1f);
			count++;
			countText.text = "Enemy Count: " + count.ToString ();
		}
	}

	public int score(){
		return count;
	}

	public void disablePathFinding(){
		nav.SetDestination (transform.position);
	}

}
