using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public GameObject gameoverP, player, background;
	public int score;
	public Text scoreText;
	public int arrowKeyVar;
	public float objectSpeed;

	void Start () 
	{
		Time.timeScale = 1;
		gameoverP.SetActive(false);
		arrowKeyVar = 0;
	}

	void SetGameover()
	{
		if(player.GetComponent<PlayerScript>().catInDanger == true)
		{
			gameoverP.SetActive(true);
			Time.timeScale = 0;
		}
	}

	public void RestartButton()
	{
		SceneManager.LoadScene("SampleScene");
	}
	
	public void QuitButton()
	{
		Application.Quit();
	}

	void SetScoreTextValue()
	{
		scoreText.text = score.ToString();
	}

	void Update()
	{
		SetGameover();
		SetScoreTextValue();
		ChangeArrowKeyVar();
		SetSpeedGame();
	}

	void ChangeArrowKeyVar()
	{
		if(Input.GetKeyDown(KeyCode.LeftArrow) && arrowKeyVar > -3)
		{
			arrowKeyVar--;
		}
		else if(Input.GetKeyDown(KeyCode.RightArrow) && arrowKeyVar < 3)
		{
			arrowKeyVar++;
		}
		/*

		Prof. Khalil Y.G.

		Esta parte do código está na trilha, porém não faz sentido semântico algum, afinal ela diz
		que se você apertar o botão de correr a mais do que o limite seu personagem vai voltar
		para o ponto mais devagar possível, logo, para mudar isso, retirei esta parte e apenas 
		mantive a anterior, que regula a velocidade para mais ou para menos
		
		else if(Input.GetKeyDown(KeyCode.RightArrow) && arrowKeyVar >= 3)
		{
			arrowKeyVar = -3;
		}
		else if(Input.GetKeyDown(KeyCode.LeftArrow) && arrowKeyVar <= -3)
		{
			arrowKeyVar = 3;
		}
		*/
	}

	void SetSpeedGame()
	{
		switch(arrowKeyVar)
		{
			case 0:
			background.GetComponent<Scrolling>().speed = 3.5f;
			objectSpeed = 250;
			player.GetComponent<PlayerScript>().jumpHeight = new Vector2(0, 5.5f);
			break;

			case 1:
			background.GetComponent<Scrolling>().speed = 3.5f / 1.3f;
			objectSpeed = 250 * 1.3f;
			break;

			case 2:
			background.GetComponent<Scrolling>().speed = 3.5f / 1.5f;
			objectSpeed = 250 * 1.5f;
			player.GetComponent<PlayerScript>().jumpHeight = new Vector2(0, 5.8f);
			break;

			case 3:
			background.GetComponent<Scrolling>().speed = 3.5f / 2f;
			objectSpeed = 250 * 2f;
			player.GetComponent<PlayerScript>().jumpHeight = new Vector2(0, 5.8f);
			break;

			case -1:
			background.GetComponent<Scrolling>().speed = 3.5f * 1.3f;
			objectSpeed = 250 / 1.3f;
			player.GetComponent<PlayerScript>().jumpHeight = new Vector2(0, 5.8f);
			break;

			case -2:
			background.GetComponent<Scrolling>().speed = 3.5f * 1.5f;
			objectSpeed = 250 / 1.5f;
			player.GetComponent<PlayerScript>().jumpHeight = new Vector2(0, 5.8f);
			break;

			case -3:
			background.GetComponent<Scrolling>().speed = 3.5f * 2f;
			objectSpeed = 250 / 2f;
			player.GetComponent<PlayerScript>().jumpHeight = new Vector2(0, 5.8f);
			break;
		}
	}
}
