using UnityEngine;
using System.IO;


public class ShipController : MonoBehaviour {

    public Vector2 Speed = new Vector2(10, 15);
    private Vector2 Movement;
    private Rigidbody2D RBody2D;
    public GameObject DiedMenu;
	private Manager manag;

	public static int _score;

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
				
		int savenum =   System.Convert.ToInt32(Path.GetFileNameWithoutExtension(Application.persistentDataPath));

		if (File.Exists (Application.persistentDataPath + "/" + savenum + ".bananasplit")) {

			Camera.main.GetComponent<Sauvegarde> ().Saving (savenum + 1);
			savenum++;

		}

		if (savenum > 6) {
		
			savenum = 0;
		
		}
	}

}
