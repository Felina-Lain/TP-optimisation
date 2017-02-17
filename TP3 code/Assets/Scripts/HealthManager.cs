using UnityEngine;

public class HealthManager : MonoBehaviour 
{
    public int HP = 1;
    public bool IsEnemy = true;

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
                    Destroy(gameObject);
                }
            }
        }
        
    }
}
