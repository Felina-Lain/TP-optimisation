using UnityEngine;

public class BlastScript : MonoBehaviour {
    public int Damage = 1;
    public bool IsEnemyBlast = false;
    public float LifeTime = 1;

	void OnEnable(){

		LifeTime = 0.7f;
	}

	// Use this for initialization
	void Update () 
    {
		LifeTime -= Time.deltaTime;
		if (LifeTime <= 0) {
			ObjectPool.instance.PoolObject (gameObject);
		}

	}

}
