﻿using UnityEngine;

public class HealthManager : MonoBehaviour 
{
    public int HP = 1;
    public bool IsEnemy = true;
	public bool IsBoss = false;

    void OnTriggerEnter2D(Collider2D collider)
    {
        BlastScript Blast = collider.gameObject.GetComponent<BlastScript>();
        if (Blast != null)
        {
            if (Blast.IsEnemyBlast != IsEnemy)
            {
                HP -= Blast.Damage;
                Destroy(Blast.gameObject);

                if (HP <= 0)
                {
					Destroy (gameObject);
                }
            }
        }
        
    }

	void OnDestroy(){

		if(IsBoss){
			Manager._bosses ++;}

	}
}
