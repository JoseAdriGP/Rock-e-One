using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {

	public Transform canvas; 

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (canvas.GetChild(1).gameObject.activeInHierarchy == false && canvas.GetChild(2).gameObject.activeInHierarchy == false) {
				canvas.GetChild(1).gameObject.SetActive (true);
				canvas.GetChild(3).gameObject.SetActive (false);
				Time.timeScale = 0;
			} else {
				canvas.GetChild(1).gameObject.SetActive (false);
				canvas.GetChild(3).gameObject.SetActive (true);
				Time.timeScale = 1;
			}
		}
	}
}
