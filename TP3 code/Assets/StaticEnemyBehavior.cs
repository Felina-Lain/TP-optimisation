using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemyBehavior : MonoBehaviour {

	[Header("Proportion of the screen to freeze to")]
	[Range(0f, 1f)]
	public float screenPosX = 0.8f;

	private float thisXViewportPos;

	void Update () {

		thisXViewportPos = Camera.main.WorldToViewportPoint(transform.position).x;


		if(thisXViewportPos < screenPosX)
		{
			transform.parent = null;
			this.enabled = false;
			//C'est ici que l'on enclenche un wait puis un patern
		}

	}
}
