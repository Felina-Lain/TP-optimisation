using UnityEngine;

public class BlastScript : MonoBehaviour {
    public int Damage = 1;
    public bool IsEnemyBlast = false;
    public float LifeTime = 1;

	// Use this for initialization
	void Start () 
    {
        Destroy(gameObject, LifeTime);
	}

    void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 10);
        foreach (Collider2D col in colliders)
        {
            if(col.transform.name == GameObject.Find("Ship").transform.name)
            {
                GameObject.Find("Ship").GetComponent<HealthManager>().HP--;
            }
        }
    }
}
