using UnityEngine;

public class EnemyScript : MonoBehaviour 
{
    private WeaponScript[] Weapons;

	void Awake()
    {
        Weapons = GetComponentsInChildren<WeaponScript>();
	}
	
	void Update() 
    {
	    foreach(WeaponScript Weapon in Weapons)
        {
            if (Weapon.CanAttack)
            {
                Weapon.Attack(true); //true: it's en enemy
            }
        }
	}
}
