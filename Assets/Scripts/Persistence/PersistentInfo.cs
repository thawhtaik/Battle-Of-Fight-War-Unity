﻿using UnityEngine;
using System.Collections;
using System.IO;


public class PersistentInfo : MonoBehaviour 
{
	
	public TextAsset SceneOrder;
	
	public int sceneIndex = 0;
	public string sceneName = "";
	
	
	// Use this for initialization
	void Start () 
	{
		DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	
	public void loadSceneAtIndex(int index)
	{
		this.setSceneIndex(index);
		
		string[] sceneInfo = this._getSceneInfoAtIndex(index);
		this.sceneName = sceneInfo[1];
		
		Debug.Log("Scene type: " + sceneInfo[0]);
		if (sceneInfo[0] == "Interlude") {
			
			Debug.Log ("Texts/Interludes/" + sceneInfo[1]);
			Application.LoadLevel("Interlude");
			
		} else { //BattleMap... load the right scene
			
			Debug.Log(sceneInfo[1]);
			Application.LoadLevel(sceneInfo[1]);
		}
	}
	
	
	public void loadNextScene()
	{
		//This part is pretty important
		Time.timeScale = 1;
		
		int nextSceneNumber = this.getSceneIndex() + 1;
		Debug.Log("Next scene number: " + nextSceneNumber);
		this.loadSceneAtIndex(nextSceneNumber);
	}


	public void loadDefeatScene()
	{
		Time.timeScale = 1;

		//Don't mess with the scene number; we'll keep it for now
		this.sceneName = "Defeat";

		Application.LoadLevel("Interlude");
	}
	
	
	private string[] _getSceneInfoAtIndex(int index)
	{
		//Generate list of names
		string sceneList = this.SceneOrder.text;
		StringReader Reader = new StringReader(sceneList);
		
	    string sceneInfo = "";	
		for (int i = 0; i <= index; i++) {
			sceneInfo = Reader.ReadLine();
		}
			
		Debug.Log ("Scene Info :" + sceneInfo);
		
		return sceneInfo.Split(null);
	}
	
	
	public void setSceneIndex(int newIndex)
	{
		this.sceneIndex = newIndex;	
	}
	
	
	public int getSceneIndex()
	{
		return this.sceneIndex;	
	}
}
