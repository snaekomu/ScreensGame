using UnityEngine;
using System.Collections;
using System;

public class peepController : MonoBehaviour {

	private GameObject[] artsy;
	private Vector3 destinationVector;
	private NavMeshAgent agent;
	private GameObject destinationGameObject;

	private bool yellable = false;

	public bool Yellable {
		get {
			return yellable;
		}
	}

	// Use this for initialization
	void Start () {
		//rb = GetComponent<Rigidbody> ();
		agent = GetComponent<NavMeshAgent> (); //get navigation mesh agent
		artsy = GameObject.FindGameObjectsWithTag ("Art"); //get all art objects
		//Give peeps a random destination on start
		int n = UnityEngine.Random.Range (0, artsy.Length);
		if (destinationGameObject != artsy [n]) {
			destinationVector = artsy [n].GetComponent<Transform> ().position;
			destinationGameObject = artsy [n];
			agent.SetDestination (destinationVector);
		}//if

	}//Start
	
	// Update is called once per frame
	void Update () {
		//Randomly change destination
		if (UnityEngine.Random.Range(0,1000) == 362) {
			ChangeDest ();
		}
		
	}//Update

	//25% chance of triggering change destination
	public void ChangeDestTrigger(int chance) {
		if (yellable && UnityEngine.Random.Range(0, chance) == 0) { //check if it's close to the destination (yellable) and 25% chance
			ChangeDest ();
			yellable = false;
		}
	}//ChangeDestTrigger

	//Change destination
	public void ChangeDest () {
		GameObject d = destinationGameObject;		//Save current destination
		while (d == destinationGameObject) {		//Loop through random destinations until we find one that is different to the current one
			int n = UnityEngine.Random.Range (0, artsy.Length);		//--Get random destination
			if (destinationGameObject != artsy [n]) {
				destinationVector = artsy [n].GetComponent<Transform> ().position;	//--Check if it's different and set it as the current destination
				destinationGameObject = artsy [n];
			}
		}
		agent.SetDestination (destinationVector);		//Set destination to AI
	}//ChangeDest

	void reduceSpeed () {
		agent.speed = 1.2f;
	}

	void increaseSpeed () {
		agent.speed = 2.5f;
	}

	void yell () {
		yellable = true;
	}

	void dontYell () {
		yellable = false;
	}

}//Class
