using UnityEngine;
using System.Collections;

public class RoleMove : MonoBehaviour
{
	public float speed = 100.0f;
	public float moveScale = 50.0f;

	float originX;
	float originZ;

	public float minX = 150.0f;
	public float maxX = 350.0f;
	public float minZ = 150.0f;
	public float maxZ = 350.0f;

	int numOfKillMonster = 0;

	float blood = 100.0f;
	float bloodMax = 100.0f;
	float bloodMonsterDecrease = 1.0f;

	// Use this for initialization
	void Start ()
	{
		originX = transform.position.x;
		originZ = transform.position.z;
	}
	
	// Update is called once per frame
	void Update ()
	{
		float curX = transform.position.x;
		float curZ = transform.position.z;

		Vector3 newPos = new Vector3 (curX, transform.position.y, curZ);

		if (curX < minX)
			newPos.x = minX;
		if (curX > maxX)
			newPos.x = maxX;

		if (curZ < minZ)
			newPos.z = minZ;
		if (curZ > maxZ)
			newPos.z = maxZ;

		transform.position = newPos;
	}

	public void JoystickMove (Vector2 direction)
	{
		transform.LookAt (new Vector3 (transform.position.x + direction.x, transform.position.y, transform.position.z + direction.y));
		transform.Translate (Vector3.forward * speed * Time.deltaTime);
	}

	void OnTriggerEnter (Collider collider)
	{
		if (collider.name.StartsWith ("Monster")) {
			
			blood -= bloodMonsterDecrease;
			Debug.Log (blood + " Blood");

			if (blood <= 0) {
				Debug.Log ("Game Over!");
			}
		}
	}

	public void recoverBlood (float num)
	{
		blood += num;
		if (blood > bloodMax)
			blood = bloodMax;
		Debug.Log (blood + " Blood");
	}
}
