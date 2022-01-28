using UnityEngine;

public class PlayerPositionCheck : MonoBehaviour
{
    [SerializeField]
    Transform _topPlayerTransform;
    [SerializeField]
    Transform _bottomPlayerTransform;

    Transform playerAhead;

    private void Update()
    {
        CheckPlayerAhead();
    }

    void CheckPlayerAhead()
    {
        if(_topPlayerTransform.position.x < _bottomPlayerTransform.position.x)
        {
            playerAhead = _bottomPlayerTransform;
        }
        else
        {
            playerAhead = _topPlayerTransform;
        }

        if (CameraFollow.instance.GetTargetTransform() != playerAhead)
        {
            CameraFollow.instance.ChangeTarget(playerAhead);
        }
    }
}
