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
    [SerializeField] private Texture2D cursorImagePointer;
    private Vector2 hotSpot = Vector2.zero;
    private CursorMode cursorMode = CursorMode.Auto;

    public void OnEnter()
    {
        if (imageButton != null)
        {
            Cursor.SetCursor(cursorImagePointer, hotSpot, cursorMode);
            imageButton.sprite = imageOn;
        }
    }

    public void OnExit()
    {
        if (imageButton != null)
        {
            Cursor.SetCursor(null, Vector2.zero, cursorMode);
            imageButton.sprite = imageOff;
        }
    }
}
