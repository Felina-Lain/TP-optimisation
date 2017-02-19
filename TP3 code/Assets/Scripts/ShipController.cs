using UnityEngine;
using System.IO;
using UnityEditor;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public class ShipController : MonoBehaviour {

    public Vector2 Speed = new Vector2(10, 15);
    private Vector2 Movement;
    private Rigidbody2D RBody2D;
    public GameObject DiedMenu;
	private Manager manag;

	float leftLimitation;
	float rightLimitation;
	float upLimitation;
	float downLimitation;

    void Awake()
    {
        RBody2D = GetComponent<Rigidbody2D>();
		manag =  Camera.main.GetComponent<Manager>();

		leftLimitation = Camera.main.ViewportToWorldPoint(Vector3.zero).x;
		rightLimitation = Camera.main.ViewportToWorldPoint(Vector3.right).x;
		upLimitation = Camera.main.ViewportToWorldPoint(Vector3.zero).y;
		downLimitation = Camera.main.ViewportToWorldPoint(Vector3.up).y;
    }

    void Update()
    {
        //Gathering controller information (keyboard and pad)
        if(Input.GetKey(KeyCode.Escape))
        {
			manag.QuitGame();
        }
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        //Calcul movement
        Movement = new Vector2(Speed.x * inputX, Speed.y * inputY);

        //Blast
		if (Input.GetButtonDown("Fire1"))
        {
            WeaponScript weapon = GetComponent<WeaponScript>();

            weapon.Attack(false); //false: player is not an enemy

        }

    }

    void FixedUpdate()  // appele a intervalle fix
    {
        RBody2D.velocity = Movement;
    }

	void LateUpdate()
	{
		//clamp player in the screen
		Vector3 _tempPos = transform.position;
		_tempPos.x = Mathf.Clamp(_tempPos.x, leftLimitation, rightLimitation);
		_tempPos.y = Mathf.Clamp(_tempPos.y, upLimitation, downLimitation);
		transform.position = _tempPos;
	}

    void OnDestroy()
    {
        DiedMenu.SetActive(true);
		Camera.main.GetComponent<Sauvegarde>().DoingSaving();
			
    }

}
