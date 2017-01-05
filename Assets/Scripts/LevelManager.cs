using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
	public Transform canvas ; 

	// Use this for initialization

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void loadLevel(string newLevel){
		SceneManager.LoadScene (newLevel);
		Time.timeScale = 1;
	}

	public void reloadLevel(string newLevel){
		canvas.GetChild (1).gameObject.SetActive (false);
		canvas.GetChild (2).gameObject.SetActive (false);
		canvas.GetChild (3).gameObject.SetActive (true);
		Time.timeScale = 1;
		SceneManager.LoadScene (newLevel);
	} 

	public void closeGame(){
		Application.Quit();
	}

	public void goInstructions(){
		if (canvas.GetChild(0).gameObject.activeInHierarchy == true) {
			canvas.GetChild(0).gameObject.SetActive (false);
			canvas.GetChild(1).gameObject.SetActive (true);
			Time.timeScale = 1;
		}
	}

	public void backMainMenu(){
		if (canvas.GetChild(1).gameObject.activeInHierarchy == true) {
			canvas.GetChild(0).gameObject.SetActive (true);
			canvas.GetChild(1).gameObject.SetActive (false);
			Time.timeScale = 1;
		}
	}

	public void pause(){
		if (canvas.GetChild (1).gameObject.activeInHierarchy == false) {
			canvas.GetChild (1).gameObject.SetActive (true);
			canvas.GetChild (3).gameObject.SetActive (false);
			Time.timeScale = 0;
		}
	}

	public void returnGame(){
		if (canvas.GetChild (1).gameObject.activeInHierarchy == true) {
			canvas.GetChild (1).gameObject.SetActive (false);
			canvas.GetChild (3).gameObject.SetActive (true);
			Time.timeScale = 1;
		}
	}
}
