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

}
