using UnityEngine;
using System.Collections;

public class garage_camera : MonoBehaviour {

		public Camera mainCamera;
		public Transform bmw;
		public Transform porsche;
		public Transform wrx;
		public Transform mazda;

		void FixedUpdate () {


				switch (PlayerPrefs.GetString ("active_car")) {
				case "e36":
						{
								if (mainCamera.transform.position != bmw.position) {
										CameraMove (bmw);
								}
								break;
						}
				case "mazda":
						{
								if (mainCamera.transform.position != mazda.position) {
										CameraMove (mazda);
								}
								break;
						}
				case "wrx":
						{
								if (mainCamera.transform.position != wrx.position) {
										CameraMove (wrx);
								}
								break;
						}
				case "911":
						{
								if (mainCamera.transform.position != porsche.position) {
										CameraMove (porsche);
								}
								break;
						}
				}
		}

		void CameraMove (Transform t) {
				mainCamera.transform.position = Vector3.Lerp (mainCamera.transform.position,t.position,Mathf.Sin(Mathf.PI*Time.deltaTime*0.5f));
				mainCamera.transform.rotation = Quaternion.Lerp (mainCamera.transform.rotation, t.rotation,Mathf.Sin(Mathf.PI*Time.deltaTime*0.5f));
	}

}
