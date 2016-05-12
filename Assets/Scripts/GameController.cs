using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public float gameLength = 600f;
	public GameObject winCanvas;

	private float timeRemaining;

	// Use this for initialization
	void Start () {
		timeRemaining = gameLength;
	}
	
	// Update is called once per frame
	void Update () {
		timeRemaining -= Time.deltaTime;

		if (timeRemaining <= 0) {
			Time.timeScale = 0.0f;
			winCanvas.SetActive (true);
		}
	}
}
