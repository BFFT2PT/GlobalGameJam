using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayPowerUp : MonoBehaviour
{
    [SerializeField]
    Sprite _missile;
    [SerializeField]
    Sprite _thunder;
    [SerializeField]
    Sprite _ball;
    [SerializeField]
    Sprite _wall;
    [SerializeField]
    Sprite _lava;

    [SerializeField]
    SpriteRenderer _iconSprite;
    [SerializeField]
    GameObject _iconParent;
    [SerializeField]
    Animator _iconAnimator;

    public void ChangeIcon(string powerUpName)
    {
        switch(powerUpName)
        {
            case "Missile": _iconSprite.sprite = _missile;
                break;
            case "Thunder": _iconSprite.sprite = _thunder;
                break;
            case "Ball": _iconSprite.sprite = _ball;
                break;
            case "Wall": _iconSprite.sprite = _wall;
                break;
            case "Lava": _iconSprite.sprite = _lava;
                break;
        }
        _iconParent.SetActive(true);
    }

    public void HideIcon()
    {
        _iconAnimator.SetTrigger("Hide");
    }
}
