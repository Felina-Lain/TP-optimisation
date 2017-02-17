using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScores : MonoBehaviour {

	public Text _1;
	public Text _2;
	public Text _3;
	public Text _4;
	public Text _5;


	void Update(){
	
		_1.text = Camera.main.GetComponent<Sauvegarde> ().Loading (0).ToString();
		_2.text = Camera.main.GetComponent<Sauvegarde> ().Loading (1).ToString();
		_3.text = Camera.main.GetComponent<Sauvegarde> ().Loading (2).ToString();
		_4.text = Camera.main.GetComponent<Sauvegarde> ().Loading (3).ToString();
		_5.text = Camera.main.GetComponent<Sauvegarde> ().Loading (4).ToString();

	
	}

}
