using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeImageButton : MonoBehaviour
{
    [SerializeField] private Image imageButton;
    [SerializeField] private Sprite imageOn;
    [SerializeField] private Sprite imageOff;

    public void OnEnter()
    {
        if (imageButton != null)
        {
            imageButton.sprite = imageOn;
        }
    }

    public void OnExit()
    {
        if (imageButton != null)
        {
            imageButton.sprite = imageOff;
        }
    }
}
