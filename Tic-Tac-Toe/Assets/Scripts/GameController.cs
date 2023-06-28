using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Player
{
	public Image panel;
	public Text text;
}

[System.Serializable]
public class PlayerColor
{
	public Color panelColor;
	public Color textColor;
}

public class GameController : MonoBehaviour
{

	public Player playerX;
	public Player playerO;
	public PlayerColor activePlayerColor;
	public PlayerColor inactivePlayerColor;

	public GameObject gameOverPanel;
	public Text gameOverText;
	public GameObject restartButton;
	
	public Text[] buttonList;
	string playerSide;
	int moveCount;

	private void Awake()
	{
		playerSide = "X";
		SetPlayerColors(playerX, playerO);
		restartButton.SetActive(false);
		moveCount = 0;
		gameOverPanel.SetActive(false);
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
			GameOver(playerSide);
		}
		else if (buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide)
		{
			GameOver(playerSide);
		}
		else if (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide)
		{
			GameOver(playerSide);
		}
		else if(buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide)
		{
			GameOver(playerSide);
		}
		else if(buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide)
		{
			GameOver(playerSide);
		}
		else if(buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide)
		{
			GameOver(playerSide);
		}
		else if(buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide)
		{
			GameOver(playerSide);
		}
		else if(buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide)
		{
			GameOver(playerSide);
		}
		else if(moveCount >= 9)
		{
			GameOver("Draw");
		}
		else
		{
			ChangeSides();
		}
	}

	void GameOver(string winningPlayer)
	{
		SetBoardInteractable(false);
		if(winningPlayer == "Draw")
		{
			SetGameOverText("It's a draw!");
		}
		else
		{
			SetGameOverText(playerSide + " Wins!");
		}
		restartButton.SetActive(true);
	}

	void ChangeSides()
	{
		playerSide = (playerSide == "X") ? "O" : "X";
		if(playerSide == "X")
		{
			SetPlayerColors(playerX, playerO);
		}
		else
		{
			SetPlayerColors(playerO, playerX);
		}
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
		SetPlayerColors(playerX, playerO);
		SetBoardInteractable(true);
		restartButton.SetActive(false);
	}

	void SetBoardInteractable(bool toggle)
	{
		for (int i = 0; i < buttonList.Length; i++)
		{
			buttonList[i].GetComponentInParent<Button>().interactable = toggle;
		}
	}

	void SetPlayerColors(Player newPlayer, Player oldPlayer)
	{
		newPlayer.panel.color = activePlayerColor.panelColor;
		newPlayer.text.color = activePlayerColor.textColor;

		oldPlayer.panel.color = inactivePlayerColor.panelColor;
		oldPlayer.text.color = inactivePlayerColor.textColor;
	}

}
