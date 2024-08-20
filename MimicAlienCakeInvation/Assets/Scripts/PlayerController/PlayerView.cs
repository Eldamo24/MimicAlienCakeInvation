using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerView : MonoBehaviour
{
    private GameObject player;
    private Vector2 mouseMovement;
    private float xRotation;
    private float yRotation;
    private float cameraOffset;
    private float mouseSensitivity = 7f;


    void Start()
    {
        player = GameObject.Find("Player");
        cameraOffset = transform.position.y - player.transform.position.y;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    void Update()
    {
        MouseMovement();
    }

    private void MouseMovement()
    {
        mouseMovement = Mouse.current.delta.ReadValue();
        xRotation += mouseMovement.y * Time.deltaTime * mouseSensitivity * -1;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        yRotation += mouseMovement.x * Time.deltaTime * mouseSensitivity;
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
        player.transform.rotation = Quaternion.Euler(0f, yRotation, 0f);
        Vector3 pos = player.transform.position;
        pos.y += cameraOffset;
        transform.position = pos;
    }
}
