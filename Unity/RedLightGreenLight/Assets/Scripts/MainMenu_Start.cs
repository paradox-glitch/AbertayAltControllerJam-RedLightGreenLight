//* Start Button
//* Morgan Finney
//* FEB 2020
//* For Red Light Green Light in Abertay Alt Controller Games Jam

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_Start : MonoBehaviour {

	bool overStart = false;
	public Mesh text;
	public Mesh textbold;

	private void Update()
	{
		if (overStart == true && Input.GetKeyDown(KeyCode.Mouse0))
			Debug.Log("Load Game");

	}

	void OnMouseOver()
	{
		if (overStart == false) {
			GetComponent<MeshFilter>().sharedMesh = textbold;
			overStart = true;
		}
	}

	void OnMouseExit()
	{
		if (overStart == true) {
			GetComponent<MeshFilter>().sharedMesh = text;
			overStart = false;
		}
	}
}