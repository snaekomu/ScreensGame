using UnityEngine;
using System.Collections;
using System;

public class playerController : MonoBehaviour {

    public float moveSpeed = 10f; //Movement Speed
	public float radius = 2.5f; //Radius of yell trigger

	private NavMeshAgent agent; //Navigation mesh
	private GameObject[] peeps; //Instanciated peeps
	private int peepsLayer = 1<<10; //Layer number holding peeps objects
	private int artLayer = 1<<9; //Layer number holding peeps objects
	private MeshCollider coneCollider;
	private float fuel = 10f; //Fire extinguisher fuel

	private enum Abilities {Yell, Mop, Spray, Barrier};	//Enum of available weapons
	private Action executeAbility;

	private int activeAbility;
	public int ActiveAbility {
		get {
			return activeAbility;
		}
		set {
			activeAbility = value;
			if (activeAbility == (int)Abilities.Yell) {
				executeAbility = yellAbility;
			} else if (activeAbility == (int)Abilities.Mop) {

			} else if (activeAbility == (int)Abilities.Spray) {
				executeAbility = sprayAbility;
			} else if (activeAbility == (int)Abilities.Barrier) {

			}
		}
	}

 //Selected weapon

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		peeps = GameObject.FindGameObjectsWithTag("Peeps");
		ActiveAbility = (int)Abilities.Spray;
		coneCollider = GetComponentInChildren<MeshCollider> ();
	}//Start

	// Update is called once per frame
	void Update () {
		//Update movement each frame
		agent.Move(Vector3.right * moveSpeed * Time.deltaTime * Input.GetAxis ("Horizontal") + Vector3.forward * moveSpeed * Time.deltaTime * Input.GetAxis ("Vertical"));

		//Check for ability triggers each frame
		if (Input.GetKey("space")) { executeAbility ();}
		if (Input.GetKeyDown("right")) { activeAbility = (activeAbility++) % 4;}
		if (Input.GetKeyDown("left")) { activeAbility = (activeAbility++) % 4;}

    }//Update

	void yellAbility() {
		if (Input.GetKeyDown("space")){
			//Get targets
			Collider[] targets = Physics.OverlapSphere (this.transform.position, 2.5f, peepsLayer);
			Debug.Log (targets.Length);
			for (int i = 0; i < targets.Length; i++) {
				//Change destination of targets
				targets [i].GetComponent<peepController>().ChangeDestTrigger(3);
			}//for	
		}//if
	}//yellAbility

	void sprayAbility() {
		//Get targets
		Collider[] targets = Physics.OverlapSphere (this.transform.position, 1f, peepsLayer);
		for (int i = 0; i < targets.Length; i++) {
			//Change destination of targets
			targets [i].GetComponent<peepController>().ChangeDestTrigger(0);
		}//for
		fuel -= Time.deltaTime;
	}//sprayAbility
}