using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsquemasController : MonoBehaviour {
	//Esse Script vai na Camera//
	//---------------------------------------------------------------------------//

	[SerializeField]
	GameObject [] group, piked;

	// Use this for initialization
	void Awake ()
	{
		group = GameObject.FindGameObjectsWithTag ("esquemas");
		piked = GameObject.FindGameObjectsWithTag ("PikedSimple");
	}

	void Start () 
	{
		for (int y = 1; y < group.Length; y++) 
		{
			group [y].SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {

		for (int x = 0; x < group.Length; x++) 
		{
			if (group [x].transform.childCount == 0) 
			{
				group[x + 1].SetActive (true);
				piked = GameObject.FindGameObjectsWithTag ("PikedSimple");
				group [x].SetActive (false);			
			}
		}
	}
}
