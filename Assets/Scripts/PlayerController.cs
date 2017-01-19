using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;

	private Rigidbody rb;
	private int count;

	public Transform canvas;
	Matrix4x4 calibrationMatrix;
	Vector3 wantedDeadZone  = Vector3.zero;

	public AudioClip choque;
	public AudioSource choques;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText ();
		calibrateAccelerometer ();
	}

	void FixedUpdate ()
	{
		Vector3 move = getAccelerometer(Input.acceleration);
		rb.AddForce (move.x * speed, 0f, move.y * speed);
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			Handheld.Vibrate();
			Destroy(other.gameObject);
			count = count + 1;
			SetCountText ();
		}
		if (other.gameObject.CompareTag ("Wall"))
		{
			choques.PlayOneShot (choque);
		}
	}

	void SetCountText ()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 12)
		{
			canvas.GetChild(1).gameObject.SetActive (false);
			canvas.GetChild(2).gameObject.SetActive (true);
			canvas.GetChild(3).gameObject.SetActive (false);
			Time.timeScale = 0;
		}
	}
		
	void calibrateAccelerometer(){
		wantedDeadZone = Input.acceleration;
		Quaternion rotateQuaternion = Quaternion.FromToRotation(new Vector3(0f, 0f, -1f), wantedDeadZone);
		//create identity matrix ... rotate our matrix to match up with down vec
		Matrix4x4 matrix = Matrix4x4.TRS(Vector3.zero, rotateQuaternion, new Vector3(1f, 1f, 1f));
		//get the inverse of the matrix
		calibrationMatrix = matrix.inverse;
	}

	Vector3 getAccelerometer(Vector3 accelerator){
		Vector3 accel = this.calibrationMatrix.MultiplyVector(accelerator);
		return accel;
	}
}
