using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    string _playerName;
    private void OnBecameInvisible()
    {
        GameManager.instance.PlayerDied(_playerName);
    }
}
