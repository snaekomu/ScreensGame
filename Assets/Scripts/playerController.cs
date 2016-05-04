using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

    public float moveSpeed = 10f; //Movement Speed
	public float radius = 2.5f;


    private float dt; //
	private NavMeshAgent agent;
	private GameObject[] peeps; //Instanciated peeps
	private int peepsLayer = 1<<10; //Layer number holding peeps objects
	private int artLayer = 1<<9; //Layer number holding peeps objects

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		peeps = GameObject.FindGameObjectsWithTag("Peeps");
	}//Start

	// Update is called once per frame
	void Update () {
		//Update movement each frame
		agent.Move(Vector3.right * moveSpeed * Time.deltaTime * Input.GetAxis ("Horizontal") + Vector3.forward * moveSpeed * Time.deltaTime * Input.GetAxis ("Vertical"));

		//Check for ability triggers each frame
		if (Input.GetKeyDown("space")) { firstAbility ();}

    }//Update

	void firstAbility() {
		//Get targets
		Collider[] targets = Physics.OverlapSphere (this.transform.position, 2.5f, peepsLayer);
		Debug.Log (targets.Length);
		for (int i = 0; i < targets.Length; i++) {
			//Change destination of targets
			targets [i].GetComponent<peepController>().ChangeDestTrigger();
		}//for	
	}//firstAbility
}