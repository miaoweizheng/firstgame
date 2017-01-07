using UnityEngine;
using System.Collections;

public class MonsterMove : MonoBehaviour
{
	public float speed = 10.0f;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 target = new Vector3 (250f, 5f, 250f);
		transform.position = Vector3.MoveTowards (transform.position, target, speed * Time.deltaTime);
	}

	void OnTriggerEnter (Collider collider)
	{
		if (collider.gameObject.name.Equals ("Hero")) {

			Camera.main.GetComponent<MonsterManager> ().removeMonster (gameObject);

		} else if (collider.gameObject.name.Equals ("Princess")) {
			Debug.Log ("Princess Attacked!!!");
			Camera.main.GetComponent<MonsterManager> ().removeMonster (gameObject);
		}
	}
}
