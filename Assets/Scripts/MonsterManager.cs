using UnityEngine;
using System.Collections;

public class MonsterManager : MonoBehaviour
{
	ArrayList monsters = new ArrayList ();

	public float numPerSec = 1.0f;

	public GameObject monsterPref;
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (generateMonsterOrNot ()) {
			GameObject monster = Instantiate (monsterPref);
			randomPos (monster);
			monsters.Add (monster);
		}
	}

	bool generateMonsterOrNot ()
	{
		if (Random.value < numPerSec * Time.deltaTime)
			return true;
		
		return false;
	}

	void randomPos (GameObject obj)
	{
		Vector3 pos = new Vector3 (0f, 5f, 1f);

		if (Random.value < 0.5) {
			pos.x = Random.Range (100, 400);
			pos.z = (Random.value < 0.5) ? 100 : 400;
		} else {
			pos.x = (Random.value < 0.5) ? 100 : 400;
			pos.z = Random.Range (100, 400);
		}

		obj.transform.position = pos;
	}

	public void ClearMonsters ()
	{
		foreach (GameObject m in monsters) {
			Destroy (m);
		}
		monsters.Clear ();
	}

	public void removeMonster (GameObject monster)
	{
		monsters.Remove (monster);
		Destroy (monster);
	}
}
