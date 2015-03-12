using UnityEngine;
using System.Collections;

public class PickupManager : MonoBehaviour {

	public GameObject pickup;
	public Transform[] spawnPoints;
	public PlayerHealth playerHealth;

	// Update is called once per frame
	void Update () {
		spawnPickup ();
	}

	void spawnPickup(){
		GameObject[] currentObjects = GameObject.FindGameObjectsWithTag ("Pickup");
		if (currentObjects.Length <= 1 && playerHealth.getHealth() > 0) {
			int spawnIndex = Random.Range(0, spawnPoints.Length);

			// Don't spawn two pickups on the same spot
			foreach(GameObject o in currentObjects){
				if(o.transform.position.Equals(spawnPoints[spawnIndex].position))
					spawnIndex = (spawnIndex + 1) % spawnPoints.Length;
			}

			Instantiate(pickup, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
		}
	}
}
