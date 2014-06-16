using UnityEngine;
using System.Collections;

public class TowerRotation : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}

	void Update(){
		transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0));
	}

}
