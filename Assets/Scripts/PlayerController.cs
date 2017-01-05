using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;

	private Rigidbody rb;
	private int count;

	public Transform canvas;
	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText ();
	}

	void FixedUpdate ()
	{
		Vector3 move = Input.acceleration;
		rb.AddForce (move.x * speed, 0f, move.y * speed);
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ( "Pick Up"))
		{
			//MC.PlayOneShot (Pickup);
			Handheld.Vibrate();
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}
	}

	void SetCountText ()
	{
		//MC.Play ();
		countText.text = "Count: " + count.ToString ();
		if (count >= 12)
		{
			canvas.GetChild(1).gameObject.SetActive (false);
			canvas.GetChild(2).gameObject.SetActive (true);
			canvas.GetChild(3).gameObject.SetActive (false);
			Time.timeScale = 0;
		}
	}
}
