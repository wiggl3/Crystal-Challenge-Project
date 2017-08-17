using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour {

	//Esse script é colocado no Canvas

	[SerializeField]float timer;
	[SerializeField]private Text uiPoint; //texto da pontuação
	[SerializeField]private Image uiTime; //imagem usada no tempo 
	[SerializeField]private Text gameOver; //texto para mostrar que o tempo acabou
	[SerializeField]private Text level; // texto para mostrar o level atual
	Scene lastLevel, currentLevel;

	BallController bc; //nomenclatura que será dada ao script BallController dentro do script HUD.

	// Use this for initialization
	void Start ()
	{
		lastLevel = SceneManager.GetActiveScene();//pegando o nome da ultima cena que você esteve e deixando salva para pode ler quando mudar de cena

		DontDestroyOnLoad (gameObject); //impedindo que o canvas seja destruido quando a fase muda

		timer = 100; //tempo que a fase tem para ser completada
		bc = FindObjectOfType<BallController> (); //Dizendo ao script que toda vez qu	e aparecer "bc", significa que será usando um componente do script BallController.
	}
	
	// Update is called once per frame
	void Update () 
	{
		sceneControl ();
		uiParameters ();
	}


	//----------------------------------------------------------------------------------------------------------------------------------------------------------------

	void sceneControl()
	{
		Debug.Log ("cena: " + lastLevel.name); //debugando o nome da ultima cena que você esteve

		currentLevel = SceneManager.GetActiveScene(); //pega a cena que você está atualmente

		if (Input.GetKeyDown (KeyCode.Return)) 
		{
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1); //se você apertar enter, a cena troca para a proxima listada na build
		}  

		if (lastLevel.name != currentLevel.name) //se o nome da ultima cena for diferente do nome da cena atual
		{
			lastLevel = SceneManager.GetActiveScene(); //ultima cena se torna a cena em que você está
			timer = 100; // tempo retorna para 100
			bc.points = 0; //pontuação volta a ser 0
			bc = FindObjectOfType<BallController> ();
		}
	}

	void uiParameters()
	{
		timer -= Time.deltaTime; //diminui o tempo que será dividido
		uiTime.fillAmount = ((timer * 0.01f)); //formula para a barra de tempo diminuir a partir dos segundos decorridos baseado em 100 segundos

		uiPoint.text = "Pontos: " + bc.points.ToString ();//transformando o int de pontuação em string para poder aparecer como texto e compilando com o texto "pontos"
		level.text = "Level " + "0" + (SceneManager.GetActiveScene().buildIndex + 1); //mostrando na tela o level em que você se encontra

		if (timer <= 0) //se o tempo terminar, o jogo pausa e aparece a escrição de game over
		{
			gameOver.enabled = true; //deixa a mensagem de gameover visivel
			Time.timeScale = 0;//velocidade do jogo zera

			if (Input.GetKeyDown (KeyCode.Space))  //dando restart no tempo
			{
				timer = 100;
			}
		}

		else //se o tempo é maior do que 0, não aparece game over e o jogo segue
		{
			gameOver.enabled = false; 
			Time.timeScale = 1;
		}
	}
}
