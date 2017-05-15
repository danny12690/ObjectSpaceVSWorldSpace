/*
 * Computer Animation and Gaming......Assignment 1.........
 * Author : Dhananjay Singh
 * UTD Id : 2021250625
 * 
 * The script enables user to translate and rotate a cube according to the world cordinate system
 * as well as the Object Cordinate System.
 * 
 * 1> The translation is done using W,A,S,D,Z,X keys and the rotation is done using I,J,K,L,N,M keys.
 * 2> The cordinate system canbe switched using the buttons named appropriately.
 * 3> The reset button will place the cube back to its original position and orientation.
 * 
 * Note::::::::::::
 * 1> By default the transformations and translations are done in the Object Cordinate System.
 * 2> The Cordinate axis are shown in the form of cylinders Z: Blue, Y: Green and X: Orange.
 */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class RotationAndTranslation : MonoBehaviour
{
	float transSpeed=20.0f;
	float rotSpeed=100.0f;
	int status;
	// 1 for World Cordinate System and 0 for Object Cordinate System//
	// Use this for initialization

	void Start ()
	{
		//Making sure that the worldcordinate axis is always shown (for reference)
		GameObject[] wcsCylinders=GameObject.FindGameObjectsWithTag("WCSCylinder");
		GameObject wcs = GameObject.FindGameObjectWithTag ("WCS");
		foreach (GameObject wcsCylinder in wcsCylinders)
			wcsCylinder.SetActive (true);
	}

	// Update is called once per frame
	void Update ()
	{
		if (status == 0) 
		{   //Move left in Object Space//
			if (Input.GetKeyDown (KeyCode.A)) {
				this.transform.Translate (Vector3.left * Time.deltaTime * transSpeed);
			}
			//Move Right in Object Space//
			if (Input.GetKeyDown (KeyCode.D)) {
				this.transform.Translate (Vector3.right * Time.deltaTime * transSpeed);
			}
			//Move up along Y axis in Object Space//
			if (Input.GetKeyDown (KeyCode.W)) {
				this.transform.Translate (Vector3.up * Time.deltaTime * transSpeed);
			}
			//Move Down along Y axis in Object Space//
			if (Input.GetKeyDown (KeyCode.S)) {
				this.transform.Translate (Vector3.down * Time.deltaTime * transSpeed);
			}
			//Move along Z axis in Object Space//
			if (Input.GetKeyDown (KeyCode.Z)) {
				this.transform.Translate (Vector3.forward * Time.deltaTime * transSpeed);
			}
			//Move along Z axis in Object Space//
			if (Input.GetKeyDown (KeyCode.X)) {
				this.transform.Translate (Vector3.back * Time.deltaTime * transSpeed);
			}

			//Rotate around Y axis in Object Space//
			if (Input.GetKeyDown (KeyCode.J)) {
				this.transform.Rotate (Vector3.up * Time.deltaTime * rotSpeed);
			}
			if (Input.GetKeyDown (KeyCode.L)) {
				this.transform.Rotate (-Vector3.up * Time.deltaTime * rotSpeed);
			}

			//Rotate around X axis in Object Space//
			if (Input.GetKeyDown (KeyCode.I)) {
				this.transform.Rotate (Vector3.right * Time.deltaTime * rotSpeed);
			}
			if (Input.GetKeyDown (KeyCode.K)) {
				this.transform.Rotate (-Vector3.right * Time.deltaTime * rotSpeed);
			}

			//Rotate around Z axis in Object Space//
			if (Input.GetKeyDown (KeyCode.N)) {
				this.transform.Rotate (Vector3.forward * Time.deltaTime * rotSpeed);
			}
			if (Input.GetKeyDown (KeyCode.M)) {
				this.transform.Rotate (Vector3.back * Time.deltaTime * rotSpeed);
			}
		} 
		else if (status == 1) 
		{
			//Move along X axis in World Space//			
			if (Input.GetKeyDown (KeyCode.A)) {
				this.transform.Translate (Vector3.left * Time.deltaTime * transSpeed,Space.World);
			}
			if (Input.GetKeyDown (KeyCode.D)) {
				this.transform.Translate (Vector3.right * Time.deltaTime * transSpeed,Space.World);
			}

			//Move along Y axis in World Space//
			if (Input.GetKeyDown (KeyCode.W)) {
				this.transform.Translate (Vector3.up * Time.deltaTime * transSpeed,Space.World);
			}
			if (Input.GetKeyDown (KeyCode.S)) {
				this.transform.Translate (Vector3.down * Time.deltaTime * transSpeed,Space.World);
			}

			//Move along Z axis in world Space//
			if (Input.GetKeyDown (KeyCode.Z)) {
				this.transform.Translate (Vector3.forward * Time.deltaTime * transSpeed,Space.World);
			}
			if (Input.GetKeyDown (KeyCode.X)) {
				this.transform.Translate (Vector3.back * Time.deltaTime * transSpeed,Space.World);
			}

			//Rotate around Y axis in World Space//
			if (Input.GetKeyDown (KeyCode.J)) {
				this.transform.Rotate (Vector3.up * Time.deltaTime * rotSpeed,Space.World);
			}
			if (Input.GetKeyDown (KeyCode.L)) {
				this.transform.Rotate (-Vector3.up * Time.deltaTime * rotSpeed,Space.World);
			}

			//Rotate around X axis in World Space//
			if (Input.GetKeyDown (KeyCode.I)) {
				this.transform.Rotate (Vector3.right * Time.deltaTime * rotSpeed,Space.World);
			}
			if (Input.GetKeyDown (KeyCode.K)) {
				this.transform.Rotate (-Vector3.right * Time.deltaTime * rotSpeed,Space.World);
			}

			//Rotate around Z axis in world space//
			if (Input.GetKeyDown (KeyCode.N)) {
				this.transform.Rotate (Vector3.forward * Time.deltaTime * rotSpeed,Space.World);
			}
			if (Input.GetKeyDown (KeyCode.M)) {
				this.transform.Rotate (Vector3.back * Time.deltaTime * rotSpeed,Space.World);
			}
		}
	}

	//Show users the current space of operations//
	void OnGUI()
	{
		if(status==0)
		GUI.Label (new Rect (10, 10, 100, 20), "Object Cordinate");
		else
		GUI.Label (new Rect (10, 10, 100, 20), "World Cordinate");
	}

	//To toggle between spaces//
	public void setWCSOn()
	{
		status = 1;
	}
	public void setOCSOn()
	{
		status = 0;
	}

	//To bring the cube back to its defaut position and orientation//
	public void onReset()
	{
		this.transform.position = Vector3.zero;
		this.transform.rotation = Quaternion.identity;
		status = 0;
	}
}