using UnityEngine;
using System.Collections;

public class EndlessGame : MonoBehaviour {

	private float gameLength = 0f;
	private UnityEngine.UI.Text text;

	public GameObject loseText;

	// Use this for initialization
	void Start () {
		text = loseText.GetComponent<UnityEngine.UI.Text>();
	}
	
	// Update is called once per frame
	void Update () {
		gameLength += Time.deltaTime;
		text.text = "You survived for " + Mathf.FloorToInt(gameLength) + " seconds.";
	}
}
