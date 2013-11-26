﻿using UnityEngine;
using System.Collections;

public class InterludeGui : MonoBehaviour 
{
	
	public GUISkin CustomGUISkin = null;

	public Texture InterludeImage = null;

	float _boxWidth = Screen.width * 0.75f;
	float _boxHeight = Screen.height * 0.90f;
	
	float _maxWidth = 650.0f;
	float _maxHeight = 800.0f;

	float _minWidth = 550.0f;
	float _minHeight = 550.0f;

	
	public TextAsset InterludeText;
	

	// Use this for initialization
	void Start () 
	{
		this._boxWidth = CommonMenuUtilities.forceDimensions(this._boxWidth, this._minWidth, this._maxWidth);
		this._boxHeight = CommonMenuUtilities.forceDimensions(this._boxHeight, this._minHeight, this._maxHeight);
		
		Debug.Log("Briefing width: " + this._boxWidth);
		Debug.Log("Briefing height: " + this._boxHeight);
		
		PersistentInfo Persistence = GameObject.Find("PersistentInfo").GetComponent<PersistentInfo>();
		this.InterludeText = Resources.Load("Texts/Interludes/" + Persistence.sceneName) as TextAsset;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	
	void OnGUI()
	{
		GUI.skin = this.CustomGUISkin;
		
		//Replace "briefing" with the name of the map or something (should be in the intro text file)
		CommonMenuUtilities.drawCenterBoxHeader(this.CustomGUISkin, "", this._boxWidth, this._boxHeight);

		GUILayout.FlexibleSpace();
		
		this._drawPicture();
		
		GUILayout.FlexibleSpace();
		
		this._drawText();

		GUILayout.FlexibleSpace();
		
		if (GUILayout.Button("Continue")) {
			this._loadNextScene();
		}
		
		GUILayout.FlexibleSpace();
		
		CommonMenuUtilities.endCenterBox();
	}
	
	
	private void _drawPicture()
	{
		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();

		GUILayout.Label(this.InterludeImage);

		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
	}
	
	
	private void _drawText()
	{
		CommonMenuUtilities.drawSingleWrappingLabelLine(this.InterludeText.text);
	}
	
	
	private void _loadNextScene()
	{
		PersistentInfo Persistence = GameObject.Find("PersistentInfo").GetComponent<PersistentInfo>();
		Persistence.loadNextScene();
	}
}
