using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Sauvegarde : MonoBehaviour {

		public BinaryFormatter bf;

	//to use when game is over, will save score to file
	public void Saving(int name){

		SavedData dataa = new SavedData();

		dataa.pouints = ShipController._score;

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

			return dataa.pouints;

		} else {
		
			return 0;
		}


	}
}
