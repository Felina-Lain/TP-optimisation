﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Sauvegarde : MonoBehaviour {

		public BinaryFormatter bf;
	private List<int> _compare = new List<int>();

	//to use when game is over, will save score to file
	public void Saving(int name, int _value){

		SavedData dataa = new SavedData();

		dataa.pouints = _value;

		//save on external file
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create (Application.persistentDataPath + "/"+  name + ".bananasplit");
		bf.Serialize(file, dataa);
		file.Close();

		//print("Save Path" + Application.persistentDataPath);

		}


	//to use when loading score, will return the score
	public int Loading(int name){

		if (File.Exists (Application.persistentDataPath + "/" + name + ".bananasplit")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/" + name + ".bananasplit", FileMode.Open);
			SavedData dataa = (SavedData)bf.Deserialize (file);
			file.Close();
			return dataa.pouints;

		} else {
		
			return 0;
		}


	}


	public void DoingSaving(){

		_compare.Clear ();
		//print(Application.persistentDataPath);

		for (int i = 0; i < 5; i++) {

			if (File.Exists (Application.persistentDataPath + "/" + i + ".bananasplit")) {
				BinaryFormatter bf = new BinaryFormatter ();
				FileStream file = File.Open (Application.persistentDataPath + "/" + i + ".bananasplit", FileMode.Open);
				SavedData dataa = (SavedData)bf.Deserialize (file);

				//print("I found save " + i + " containing " + dataa.pouints);

				_compare.Add(dataa.pouints);

				file.Close();

			}else {

				_compare.Add(0);
			}
		}
			
		_compare.Add(Manager._score);

		_compare.Sort((a, b) => -1* a.CompareTo(b));

		for (int y = 0; y < 5; y++) {


			Saving (y, _compare[y]);


		}
	}
}
