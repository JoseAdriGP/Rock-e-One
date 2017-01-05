using System.Collections;
using UnityEngine;

public class PinchZoom : MonoBehaviour {

	public float perspectiveZoomSpeed = 0.5f;
	public float orthoZoomSpeed = 0.5f;

	void Update()
	{
		if (Input.touchCount == 2)
		{
			Touch touchZero = Input.GetTouch(0);
			Touch touchOne = Input.GetTouch(1);

			Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
			Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

			float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
			float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

			float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;
		
			if (GetComponent<Camera> ().orthographic)
			{	
				if (GetComponent<Camera> ().orthographicSize <= 7 && GetComponent<Camera> ().orthographicSize >= 3) {
					GetComponent<Camera> ().orthographicSize += deltaMagnitudeDiff * orthoZoomSpeed;
					GetComponent<Camera> ().orthographicSize = Mathf.Max (GetComponent<Camera> ().orthographicSize, 0.1f);
				} else {
					if (GetComponent<Camera> ().orthographicSize > 7) {
						GetComponent<Camera> ().orthographicSize = 7;
					}
					if (GetComponent<Camera> ().orthographicSize < 3){
						GetComponent<Camera> ().orthographicSize = 3;
					}
				}
			} else {
				if (GetComponent<Camera> ().fieldOfView <= 70 && GetComponent<Camera> ().fieldOfView >= 40) {
					GetComponent<Camera> ().fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed;
					GetComponent<Camera> ().fieldOfView = Mathf.Clamp (GetComponent<Camera> ().fieldOfView, 0.1f, 179.9f);
				} else {
					if (GetComponent<Camera> ().fieldOfView > 70) {
						GetComponent<Camera> ().fieldOfView = 70;	
					}
					if (GetComponent<Camera> ().fieldOfView < 40) {
						GetComponent<Camera> ().fieldOfView = 40;	
					}
				}
			}
		}
	}
}
