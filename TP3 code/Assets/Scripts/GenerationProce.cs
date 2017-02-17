using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationProce: MonoBehaviour {

	public GameObject prefab1;
	public GameObject prefab2;
	public GameObject prefab3;

	float timer;
	public float timerMax;

	// Use this for initialization
	void SpawnRandom () {


		float leftLimitation = Camera.main.ViewportToWorldPoint(new Vector3(0,0,0)).x;
		float rightLimitation = Camera.main.ViewportToWorldPoint(new Vector3(1,0,0)).x;

		float upLimitation = Camera.main.ViewportToWorldPoint(new Vector3(0,0,0)).y;
		float downLimitation = Camera.main.ViewportToWorldPoint(new Vector3(0,1,0)).y;


		int numeroaupif = Random.Range(1,4);

		Vector3 randompos = new Vector3 (rightLimitation + 0.1f, Random.Range (downLimitation, upLimitation), 0);
			
		if(numeroaupif == 1)
		{
			//GameObject inst = Instantiate (prefab1, randompos, Quaternion.identity);
			GameObject inst = ObjectPool.instance.GetObjectForType(prefab1.name, false);
			inst.transform.position = randompos;
			inst.transform.rotation = Quaternion.identity;
			inst.transform.parent = this.transform;
		}
		if(numeroaupif == 2)
		{
			GameObject inst = ObjectPool.instance.GetObjectForType(prefab2.name, false);
			inst.transform.position = randompos;
			inst.transform.rotation = Quaternion.identity;
			inst.transform.parent = this.transform;
		}
		if(numeroaupif == 3)
		{
			GameObject inst = ObjectPool.instance.GetObjectForType(prefab3.name, false);
			inst.transform.position = randompos;
			inst.transform.rotation = Quaternion.identity;
			inst.transform.parent = this.transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
		timer += 1 * Time.deltaTime;
		if (timer >= timerMax) {
			timer = 0f;
			timerMax = Random.Range (2, 4);
			SpawnRandom ();
		}
	}
}
