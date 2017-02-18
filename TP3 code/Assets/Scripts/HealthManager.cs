using UnityEngine;

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
					if (IsEnemy) {
						ObjectPool.instance.PoolObject (gameObject);
					} else {
						Destroy (gameObject);}
                }
            }
        }
        
    }

	void OnDisable(){

		if(IsBoss){
			Manager._bosses ++;}

	}
}
