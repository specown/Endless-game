using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
using UnityEngine;
using System.Linq;

public class Save : MonoBehaviour {

     private List<Highscore> highscores = new List<Highscore>();

     public void SaveFile(Highscore highscore)
     {
        //Load save file
		LoadFile ();

		Debug.Log (highscore.score + "  " + highscore.name);

        //File destination
        string destination = Application.persistentDataPath + "/save.dat";

        FileStream file;

		Debug.Log (destination);
 
         //Check if file exists
         if(File.Exists(destination)) file = File.OpenWrite(destination);
         
         //If not - create a new save file
         else file = File.Create(destination);
 
         //Add score to the file
		 this.highscores.Add(highscore);

         //Format data
         BinaryFormatter bf = new BinaryFormatter();

         bf.Serialize(file, this.highscores);

         //Close file
         file.Close();
     }

	public List<Highscore> getHighscores()
    {
        //Load save file
		LoadFile();

        //Add to list and sort descending
		List<Highscore> SortedList = highscores.OrderByDescending (o => o.score).ToList();

        //Return the list
        return SortedList;
	}
 
     public void LoadFile()
     {
         //Load file from destination
         string destination = Application.persistentDataPath + "/save.dat";
         FileStream file;
 
         //Check if file exists
         if(File.Exists(destination)) file = File.OpenRead(destination);
         else return;
 
         //Format data
         BinaryFormatter bf = new BinaryFormatter();
         this.highscores = (List<Highscore>) bf.Deserialize(file);

         //Close file
         file.Close();
     }
}
