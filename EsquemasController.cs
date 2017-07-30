using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsquemasController : MonoBehaviour {
	//Esse Script vai na Camera//
	//---------------------------------------------------------------------------//

	[SerializeField]
	GameObject [] esquemas, coletaveis;

	// Use this for initialization
	void Awake ()
	{
		esquemas = GameObject.FindGameObjectsWithTag ("esquemas");
		coletaveis = GameObject.FindGameObjectsWithTag ("PikedSimple");
	}

	void Start () 
	{
		for (int y = 1; y < esquemas.Length; y++) 
		{
			esquemas [y].SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {

		for (int x = 0; x < esquemas.Length; x++) 
		{
			print (esquemas.Length);

			if (esquemas [x].transform.childCount == 0) 
			{
				esquemas[x + 1].SetActive (true);
				coletaveis = GameObject.FindGameObjectsWithTag ("PikedSimple");
			}

		}
	
	}
}
