﻿using UnityEngine;
using System.IO;
using UnityEditor;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public class ParallaxHandler : MonoBehaviour 
{
    public float Speed = 0;
    public bool Repeatable = false;
    public bool Collidable = false;
    public float RepeatDistance = 10;
    public float HorizontalDistance;
    public float Displaced;
    public float DistanceOffScreen;
    public GameObject WinMenu;

    void Awake()
    {
        //Computing bounds of the whole layer, then delete every unneaded component
        Bounds LayerBounds = GetComponent<BoxCollider2D>().bounds;
        //Debug.Log("LayerBounds=" + LayerBounds);
        BoxCollider2D[] Childs = GetComponentsInChildren<BoxCollider2D>();
        foreach (BoxCollider2D Child in Childs)
        {
            //Debug.Log("Child(" + Child.transform.name + ").bounds=" + Child.bounds);
            LayerBounds.Encapsulate(Child.bounds);
            //Child.enabled = false;
        }
        HorizontalDistance = LayerBounds.extents.x * 2;
        Displaced = 0;

        //Clean unneeded object
        if (!Collidable) // then we could clean the source a little
        {
            for (int i = Childs.Length - 1; i >= 0; i--)  // /!\ elt0 is the LayerBounds
            {

				Destroy(Childs[i]);
            }
            //Debug.Log("LayerBounds=" + LayerBounds);
        }

        // Get position of top right corner
        Vector3 TopRightCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));
        //Debug.Log("TopRightCorner=" + TopRightCorner);
        DistanceOffScreen = TopRightCorner.x;
        RepeatDistance = Mathf.Max(DistanceOffScreen, RepeatDistance - DistanceOffScreen);
    }

	void Update () {
        if (Displaced > HorizontalDistance + RepeatDistance)
        {
            if (Repeatable)
            {
                Vector3 OldPos = transform.position;
                transform.position = new Vector3(DistanceOffScreen + (HorizontalDistance / 2.0f), OldPos.y, OldPos.z);
                Displaced = -DistanceOffScreen - (HorizontalDistance / 2.0f);
            }
            else
            {
               Destroy(gameObject);
            }
        }
        else
        {
            float EffectiveSpeed = Speed * Time.deltaTime;
            transform.Translate(-EffectiveSpeed, 0.0f, 0.0f);
            Displaced += EffectiveSpeed;
        }    
	}
		
}
