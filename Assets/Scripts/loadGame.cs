using UnityEngine;
using System.Collections;

public class loadGame : MonoBehaviour {

	// Use this for initialization
	public void loadScene (int level){
		UnityEngine.SceneManagement.SceneManager.LoadScene (level);
	}
}
