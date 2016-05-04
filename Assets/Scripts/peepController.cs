using UnityEngine;
using System.Collections;
using System;

public class peepController : MonoBehaviour {

	private GameObject[] artsy;
	private Vector3 destination;
	//private Rigidbody rb;
	private NavMeshAgent agent;
	private GameObject dest;

	// Use this for initialization
	void Start () {
		//rb = GetComponent<Rigidbody> ();
		agent = GetComponent<NavMeshAgent> ();
		artsy = GameObject.FindGameObjectsWithTag ("Art");
		int n = UnityEngine.Random.Range (0, artsy.Length);
		if (dest != artsy [n]) {
			destination = artsy [n].GetComponent<Transform> ().position;
			dest = artsy [n];
			agent.SetDestination (destination);
		}

	}//Start
	
	// Update is called once per frame
	void Update () {
		//Randomly change destination
		if (UnityEngine.Random.Range(0,1000) == 362) {
			ChangeDest ();
		}
		
	}//Update

	//25% chance of triggering change destination
	public void ChangeDestTrigger() {
		if (UnityEngine.Random.Range(0,3) == 1) {
			ChangeDest ();
		}
	}//ChangeDestTrigger

	//Change destination
	public void ChangeDest () {
		GameObject d = dest;	//Save current destination
		while (d == dest) {		//Loop through random destinations until we find one that is different to the current one
			int n = UnityEngine.Random.Range (0, artsy.Length);		//--Get random destination
			if (dest != artsy [n]) {
				destination = artsy [n].GetComponent<Transform> ().position;	//--Check if it's different and set it as the current destination
				dest = artsy [n];
			}
		}
		agent.SetDestination (destination);		//Set destination to AI
	}//ChangeDest

}//Class
