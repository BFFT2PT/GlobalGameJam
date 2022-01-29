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
    [SerializeField]
    Transform[] _playersTransform; //0 = Top player ; 1 = Bottom player
    [SerializeField]
    Rigidbody2D[] _playersRigs;

    bool gameStarted;

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
            case "Player1": _winnerText.text = "Player 2 Wins!!";
                CameraFocus.instance.FocusWinner(_playersTransform[1]);
                break;
            case "Player2": _winnerText.text = "Player 1 Wins!!";
                CameraFocus.instance.FocusWinner(_playersTransform[0]);
                break;
        }

        foreach(PlayerMovement moveScript in _playerMovementScripts)
        {
            moveScript.enabled = false;
        }

        foreach(Rigidbody2D rig in _playersRigs)
        {
            rig.gravityScale = 0;
            rig.velocity = Vector2.zero;
        }

        _winnerGameObject.SetActive(true);
    }

    public bool GameState()
    {
        return gameStarted;
    }

    public void ChangeGameState(bool newBool)
    {
        gameStarted = newBool;
    }
}
