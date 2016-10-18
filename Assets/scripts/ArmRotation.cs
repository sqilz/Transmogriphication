using UnityEngine;
using System.Collections;

public class ArmRotation : MonoBehaviour {


	public int rotationOffet = 90;
	// Update is called once per frame
	void Update () 
	{
		Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		difference.Normalize();		//normalizing the vector meaning that all the sum of the vector will be equal to 1.

		float rotZ = Mathf.Atan2(difference.y,difference.x) * Mathf.Rad2Deg; //find the angle in degree
		transform.rotation = Quaternion.Euler (0f, 0f, rotZ + rotationOffet);
				}
}
