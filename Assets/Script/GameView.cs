using System;
using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{
    public Text winnerText;
    public Text[] boardTexts;
    private GameLogic _gameLogic;

    void Start()
    {
        _gameLogic = new GameLogic();
    }
    
    
    public void OnSelect(int index)
    {
        int x = index % 3;
        int y = index / 3;
        Select(x, y);
    }
  
    // Update is called once per frame
    private void Select(int x, int y)
    {
        var canSelect = _gameLogic.CanSelect(x, y);
        if (canSelect == false)
        {
            return;
        }
        _gameLogic.Select(x, y);

        UpdateCellView(x, y);
        UpdateWinnerText();
    }

    private void UpdateCellView(int x,int y)
    {
        var playerMark = _gameLogic.GetCellMark(x,y);
        int index = x + y * 3;
        switch (playerMark)
        {
            case PlayerMark.Blank:
                boardTexts[index].text = "";
                break;
            case PlayerMark.Circle:
                boardTexts[index].text = "○";
                break;
            case PlayerMark.Cross:
                boardTexts[index].text = "☓";
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    
    private void UpdateWinnerText()
    {
        var winnerPlayer = _gameLogic.GetWinnerPlayer();
        switch (winnerPlayer)
        {
            case PlayerMark.Blank:
                winnerText.text = "";
                break;
            case PlayerMark.Circle:
                winnerText.text = "○";
                break;
            case PlayerMark.Cross:
                winnerText.text = "☓";
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}