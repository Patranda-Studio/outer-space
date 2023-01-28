using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
	
	public int speed = 5;
	
	float leftRestriction = 15;
	float rightRestriction = WorldGenerator.landscapeWidth + 15;
	float upRestriction = WorldGenerator.landscapeLength - 35;
	float downRestriction = -10;

	void Update() {
		// лево
		if ((transform.position.x >= leftRestriction) && (int)Input.mousePosition.x < 2)
			transform.position -= transform.right * Time.deltaTime * speed;
		// право
		if ((transform.position.x <= rightRestriction) && (int)Input.mousePosition.x > Screen.width - 2)
			transform.position += transform.right * Time.deltaTime * speed;
		// верх 
		if ((transform.position.z <= upRestriction) && Input.mousePosition.y > Screen.height - 2)
			transform.position += transform.forward * Time.deltaTime * speed;
		// низ
		if ((transform.position.z >= downRestriction) && Input.mousePosition.y < 2)
			transform.position -= transform.forward * Time.deltaTime * speed;
	}
}
