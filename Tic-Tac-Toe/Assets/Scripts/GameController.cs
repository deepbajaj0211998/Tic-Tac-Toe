using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

	public GameObject gameOverPanel;
	public Text gameOverText;
	
	public Text[] buttonList;
	string playerSide;
	int moveCount;

	private void Awake()
	{
		gameOverPanel.SetActive(false);
		playerSide = "X";
		moveCount = 0;
		SetControllerOnButtons();
	}

	void SetControllerOnButtons()
	{
        for(int i = 0; i < buttonList.Length; i++)
		{
			buttonList[i].GetComponentInParent<GridSpace>().SetController(this);
		}
	}

	public string GetPlayerSide()
	{
		return playerSide;
	}

	public void EndTurn()
	{
		moveCount++;

		if(buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide)
		{
			GameOver();
		}
		if (buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide)
		{
			GameOver();
		}
		if (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide)
		{
			GameOver();
		}
		if (buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide)
		{
			GameOver();
		}
		if (buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide)
		{
			GameOver();
		}
		if (buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide)
		{
			GameOver();
		}
		if (buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide)
		{
			GameOver();
		}
		if (buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide)
		{
			GameOver();
		}

		if(moveCount >= 9)
		{
			SetGameOverText("It's a Draw!");
		}

		ChangeSides();
	}

	void GameOver()
	{
		SetBoardInteractable(false);
		SetGameOverText(playerSide + " Wins!");
	}

	void ChangeSides()
	{
		playerSide = (playerSide == "X") ? "O" : "X";
	}

	void SetGameOverText(string myText)
	{
		gameOverText.text = myText;
		gameOverPanel.SetActive(true);
	}

	public void RestartGame()
	{
		playerSide = "X";
		moveCount = 0;
		gameOverPanel.SetActive(false);
		for (int i = 0; i < buttonList.Length; i++)
		{
			buttonList[i].text = "";
		}
		SetBoardInteractable(true);
	}

	void SetBoardInteractable(bool toggle)
	{
		for (int i = 0; i < buttonList.Length; i++)
		{
			buttonList[i].GetComponentInParent<Button>().interactable = toggle;
		}
	}

}
