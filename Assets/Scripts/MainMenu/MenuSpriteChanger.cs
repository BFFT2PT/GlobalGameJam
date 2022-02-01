using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSpriteChanger : MonoBehaviour
{
    [SerializeField]
    Sprite[] _leftSideSprites;
    [SerializeField]
    Sprite[] _rightSideSprites;

    [SerializeField]
    Image _leftSideImage;
    [SerializeField]
    Image _rightSideImage;

    int currentIndex;

    public void ChangeSprite()
    {
        currentIndex++;
        if(currentIndex > _leftSideSprites.Length -1)
        {
            currentIndex = 0;
        }
        _leftSideImage.sprite = _leftSideSprites[currentIndex];
        _rightSideImage.sprite = _rightSideSprites[currentIndex];
    }
}
