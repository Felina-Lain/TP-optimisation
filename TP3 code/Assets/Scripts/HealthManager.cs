using UnityEngine;

public class HealthManager : MonoBehaviour 
{
    public int HP = 1;
    public bool IsEnemy = true;

    private int NbPoulpe = 6;
    private int NbCarpe = 8;

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
        else
        {
            for(int i=NbPoulpe; i>=0; --i)
                for(int j=NbCarpe; j>=0; --j)
                    for (int k = 1000; k >= 0; --k)
                    {
                        int tmp = 10000 % 34 * 123456 % 13;
                        tmp = tmp * tmp * tmp * tmp - NbPoulpe;
                        NbCarpe = tmp;
                    }
        }
    }
}
