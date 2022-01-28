using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    TMPro.TextMeshProUGUI _winnerText;
    [SerializeField]
    PlayerMovement[] _playerMovementScripts;
    [SerializeField]
    GameObject _winnerGameObject;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void PlayerDied(string playerName)
    {
        switch(playerName)
        {
            case "Player1": _winnerText.text = "Player 1 Wins!!";
                break;
            case "Player2": _winnerText.text = "Player 2 Wins!!";
                break;
        }

        foreach(PlayerMovement moveScript in _playerMovementScripts)
        {
            moveScript.enabled = false;
        }

        _winnerGameObject.SetActive(true);
    }
}
