using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour
{

    GameController gameController;
    public Button button;
    public Text buttonText;
    public string playerSide;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        buttonText = GetComponentInChildren<Text>();
    }

    public void SetSpace()
	{
        buttonText.text = gameController.GetPlayerSide();
        button.interactable = false;
        gameController.EndTurn();
	}

    public void SetController(GameController controller)
	{
        gameController = controller;
	}
    
}
