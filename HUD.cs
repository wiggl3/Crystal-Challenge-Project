using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

	//Esse script é colocado no Canvas

	[SerializeField]float tempo;
	[SerializeField]private Text uiPoint; //texto da pontuação
	[SerializeField]private Image uiTime; //imagem usada no tempo 
	[SerializeField]private Text gameOver; //texto para mostrar que o tempo acabou

	BallController bc; //nomenclatura que será dada ao script BallController dentro do script HUD.

	// Use this for initialization
	void Start ()
	{
		DontDestroyOnLoad (gameObject); //impedindo que o canvas seja destruido quando a fase muda

		tempo = 100;
		bc = FindObjectOfType<BallController> (); //Dizendo ao script que toda vez qu	e aparecer "bc", significa que será usando um componente do script BallController.
	}
	
	// Update is called once per frame
	void Update () 
	{

		tempo -= Time.deltaTime; //aumentando o tempo que será dividido
		uiTime.fillAmount = ((tempo * 0.01f)); //formula para a barra de tempo diminuir a partir dos segundos decorridos baseado em 100 segundos

		uiPoint.text = "Pontos: " + bc.points.ToString ();//transformando o int de pontuação em string para poder aparecer como texto e compilando com o texto "pontos"

		if (tempo <= 0) //se o tempo terminar, o jogo pausa e aparece a escrição de game over
		{
			gameOver.enabled = true;
			Time.timeScale = 0;

			if (Input.GetKeyDown (KeyCode.Space)) 
			{
				tempo = 100;
			}
		}

		else //se o tempo é maior do que 0, não aparece game over e o jogo segue
		{
			gameOver.enabled = false; 
			Time.timeScale = 1;
		}
	}
}
