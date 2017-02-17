using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationProce: MonoBehaviour {

	public GameObject prefab1;
	public GameObject prefab2;
	public GameObject prefab3;



	// Use this for initialization
	void Start () {


		float leftLimitation = Camera.main.ViewportToWorldPoint(new Vector3(0,0,0)).x;
		float rightLimitation = Camera.main.ViewportToWorldPoint(new Vector3(1,0,0)).x;

		float upLimitation = Camera.main.ViewportToWorldPoint(new Vector3(0,0,0)).y;
		float downLimitation = Camera.main.ViewportToWorldPoint(new Vector3(0,1,0)).y;


		int numeroaupif = Random.Range(1,4);

		Vector3 randompos = new Vector3 (Random.Range (leftLimitation, rightLimitation), Random.Range (downLimitation, upLimitation), 0);
			
		if(numeroaupif == 1)
		{
			Instantiate (prefab1, randompos, Quaternion.identity);
		}
		if(numeroaupif == 2)
		{
			Instantiate(prefab2, randompos ,  Quaternion.identity);
		}
		if(numeroaupif == 3)
		{
			Instantiate(prefab3, randompos ,  Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
