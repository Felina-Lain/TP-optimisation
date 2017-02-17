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
	private BinaryFormatter bf;
	private List<int> _compare = new List<int>();


    void Awake()
    {
        RBody2D = GetComponent<Rigidbody2D>();
		manag =  Camera.main.GetComponent<Manager>();
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
        bool blast = Input.GetButtonDown("Fire1");

        //Calcul movement
        Movement = new Vector2(Speed.x * inputX, Speed.y * inputY);

        //Blast
        if (blast)
        {
            WeaponScript weapon = GetComponent<WeaponScript>();

            weapon.Attack(false); //false: player is not an enemy

        }
    }

    void FixedUpdate()  // appele a intervalle fix
    {
        RBody2D.velocity = Movement;
    }

    void OnDestroy()
    {
        DiedMenu.SetActive(true);

		_compare.Clear ();

		for (int i = 0; i < 5; i++) {

			if (File.Exists (Application.persistentDataPath + "/" + i + ".bananasplit")) {
				BinaryFormatter bf = new BinaryFormatter ();
				FileStream file = File.Open (Application.persistentDataPath + "/" + i + ".bananasplit", FileMode.Open);
				SavedData dataa = (SavedData)bf.Deserialize (file);
				_compare.Add(dataa.pouints);
				_compare.Sort ();
				file.Close();
			}else {
				Camera.main.GetComponent<Sauvegarde> ().Saving (0);
			}
		}

		bool _check = false;

		for (int y = 0; y < 5; y++) {

			if (Manager._score > _compare [y] && !_check) {
				_compare.Insert (y, Manager._score);
				_check = true;
			}else {
				return;
			}

			Camera.main.GetComponent<Sauvegarde> ().Saving (y);
		}


			
    }
}
