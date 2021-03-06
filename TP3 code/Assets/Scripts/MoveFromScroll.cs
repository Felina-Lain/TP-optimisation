﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFromScroll : MonoBehaviour {

	[Range(1f, 20f)]
	public float speed = 6f;

	public Vector3 dir = -Vector3.right;

	public bool useFreezeOnScreenPos = false;

	[Header("Proportion of the screen to freeze to (fom 0 to 1 (viewportSpace))")]
	public Vector3 screenFreezePos = new Vector3(0.8f, 0f, 0f);

	private Vector3 thisViewportPos;

	void Update () {

		transform.Translate(dir * speed * Time.deltaTime);

		thisViewportPos = Camera.main.WorldToViewportPoint(transform.position);

		if(useFreezeOnScreenPos)
		{
			if(thisViewportPos.x < screenFreezePos.x || thisViewportPos.y < screenFreezePos.y || thisViewportPos.z < screenFreezePos.z)
			{
				this.enabled = false;
			}
		}

		if(thisViewportPos.x < 0f)
		{
			Manager._score --;
			Destroy(gameObject);
		}

	}

}