﻿using UnityEngine;
using System.IO;
using UnityEditor;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public class Manager : MonoBehaviour 
{
	public static int _score;

	public static int _bosses;

	public GameObject WinMenu;

	private BinaryFormatter bf;
	private List<int> _compare = new List<int>();

    public void QuitGame()
    {
        Application.Quit();
    }

	void Update(){

		if (_bosses > 2){

			if (WinMenu)
			{
				WinMenu.SetActive(true);
			}

			_compare.Clear ();

			for (int i = 0; i < 5; i++) {

				if (File.Exists (Application.persistentDataPath + "/" + i + ".bananasplit")) {
					BinaryFormatter bf = new BinaryFormatter ();
					FileStream file = File.Open (Application.persistentDataPath + "/" + i + ".bananasplit", FileMode.Open);
					SavedData dataa = (SavedData)bf.Deserialize (file);
					_compare.Add (dataa.pouints);
					_compare.Sort ();
					file.Close();
				} else {
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
}
