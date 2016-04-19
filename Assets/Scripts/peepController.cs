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

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ChangeDest () {
		GameObject d = dest;
		while (d == dest) {
			int n = UnityEngine.Random.Range (0, artsy.Length);
			if (dest != artsy [n]) {
				destination = artsy [n].GetComponent<Transform> ().position;
				dest = artsy [n];
			}
		}
		agent.SetDestination (destination);
	}

}
