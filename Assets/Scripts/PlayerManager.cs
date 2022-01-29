using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    string _playerName;

    private void OnBecameInvisible()
    {
        if(GameManager.instance.GameState())
        GameManager.instance.PlayerDied(_playerName);
        GameManager.instance.ChangeGameState(false);
        ObstaclesSpawner.instance.ChangeSpawnState(false);
    }
}
