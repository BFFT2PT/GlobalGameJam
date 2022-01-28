using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    public void DestroyThisObject()
    {
        Destroy(gameObject);
    }

    public void DisableThisObject()
    {
        gameObject.SetActive(false);
    }
}
