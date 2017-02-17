using UnityEngine;

public class ShipController : MonoBehaviour {

    public Vector2 Speed = new Vector2(10, 15);
    private Vector2 Movement;
    private Rigidbody2D RBody2D;
    public GameObject DiedMenu;

    void Awake()
    {
        RBody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Gathering controller information (keyboard and pad)
        if(Input.GetKey(KeyCode.Escape))
        {
            Camera.main.GetComponent<Manager>().QuitGame();
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
            if (weapon != null)
            {
                weapon.Attack(false); //false: player is not an enemy
            }
        }
    }

    void FixedUpdate()  // appele a intervalle fix
    {
        RBody2D.velocity = Movement;
    }

    void OnDestroy()
    {
        DiedMenu.SetActive(true);
    }
}
