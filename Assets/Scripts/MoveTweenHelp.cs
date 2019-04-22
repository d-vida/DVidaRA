using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveTweenHelp : MonoBehaviour
{

    public RectTransform helpScreen;

    public void showMenu()
    {
        helpScreen.DOAnchorPos(new Vector2(0, -55), 0.25f);
    }
    public void hideMenu()
    {
        helpScreen.DOAnchorPos(new Vector2(0, -1809), 0.25f);
    }
}
