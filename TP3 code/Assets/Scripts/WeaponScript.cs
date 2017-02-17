﻿using UnityEngine;
using UnityStandardAssets.Utility;

public class WeaponScript : MonoBehaviour
{
    public Transform BlastPrefab;
    public float BlastingRate = 0.25f;
    public float BlastSpeed;
    private float BlastCooldown;

    void Start()
    {
        BlastCooldown = 0f;
    }

    void Update()
    {
        if (BlastCooldown > 0)
        {
            BlastCooldown -= Time.deltaTime;
        }
    }
    
    public void Attack(bool IsEnemy)
    {
        if (CanAttack)
        {
            BlastCooldown = BlastingRate;
            var BlastTransform = Instantiate(BlastPrefab, transform.position, transform.rotation) as Transform;
            BlastTransform.position = transform.position;
            if (transform.parent)
            {
                BlastTransform.SetParent(transform.parent);
            }
            BlastScript Blast = BlastTransform.gameObject.GetComponent<BlastScript>();
            if (Blast != null)
            {
                Blast.IsEnemyBlast = IsEnemy;
            }

            // On saisit la direction pour le mouvement
            AutoMoveAndRotate Move = BlastTransform.gameObject.GetComponent<AutoMoveAndRotate>();
            if (Move != null)
            {
                Move.moveUnitsPerSecond.value = Vector3.right * BlastSpeed;
            }
        }
    }

    public bool CanAttack
    {
        get
        {
            return BlastCooldown <= 0f;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + 0.3f * BlastSpeed * (transform.rotation * Vector3.right));
    }
}