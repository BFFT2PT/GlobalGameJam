using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocus : MonoBehaviour
{
    public static CameraFocus instance;

    CameraFollow followScript;
    Vector3 targetPosition;
    float lerpValue;

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

    private void Start()
    {
        followScript = GetComponent<CameraFollow>();
    }

    public void FocusWinner(Transform winnerTransform)
    {
        followScript.enabled = false;
        targetPosition = new Vector3(winnerTransform.position.x, winnerTransform.position.y, -10);
        StartCoroutine("MoveToPlayer");
    }

    IEnumerator MoveToPlayer()
    {
        while(lerpValue < 1)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, lerpValue);
            Camera.main.orthographicSize = Mathf.Lerp(5, 3, lerpValue);
            lerpValue += 0.002f;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
