using UnityEngine;
using System.IO;
using UnityEditor;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public class Manager : MonoBehaviour 
{
	public static int _score;

	public static int _bosses;

	public GameObject WinMenu;

	private bool _check = false;

	void Start(){

		_check = false;
	}

    public void QuitGame()
    {
        Application.Quit();
    }

	void Update(){
		
		if (_bosses > 2){

			if (WinMenu)
			{
				WinMenu.SetActive(true);

				if(!_check){
					GetComponent<Sauvegarde>().DoingSaving();
					_check = true;
				}
			}

		}

	}
}