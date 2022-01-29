using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationIntro : MonoBehaviour
{
    [SerializeField]
    PlayerMovement[] _playerMovementScripts;
    [SerializeField]
    CameraFollow _cameraFollowScript;
    [SerializeField]
    PlayerPositionCheck _PlayerPositionCheckScript;
    [SerializeField]
    GameObject goText;
    [SerializeField]
    Animator[] _playerAnimators;

    Animator thisAnimator;


    private void Start()
    {
        thisAnimator = GetComponent<Animator>();
    }

    public void EnableGoText()
    {
        goText.SetActive(true);
    }
    public void AnimationFinished()
    {
        foreach(PlayerMovement movScript in _playerMovementScripts)
        {
            movScript.enabled = true;
        }
        foreach(Animator anim in _playerAnimators)
        {
            anim.enabled = true;
        }
        _cameraFollowScript.enabled = true;
        _PlayerPositionCheckScript.enabled = true;
        thisAnimator.enabled = false;
        GameManager.instance.ChangeGameState(true);
        ObstaclesSpawner.instance.ChangeSpawnState(true);
        ObstaclesSpawner.instance.SpawnObstacles();
    }
}
