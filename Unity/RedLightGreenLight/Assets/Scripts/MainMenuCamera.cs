//* Moves The Camera Based On Mouse Pos
//* Morgan Finney
//* FEB 2020
//* For Red Light Green Light in Abertay Alt Controller Games Jam

using UnityEngine;
using System.Collections;
using UnityEditor;

public class MainMenuCamera : MonoBehaviour
{

    public float speedH = 0.5f;
    public float speedV = 0.5f;

    private float yaw = 235.0f;
    private float pitch = 15.0f;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Vector2 mousePos = Input.mousePosition;
    }

    void Update()
    {
        StartCoroutine("CentreMouseCursor");

        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float screenX = Screen.width;
        float screenY = Screen.height;

        if (mouseX < 0 || mouseX > screenX || mouseY < 0 || mouseY > screenY)
        {
            Cursor.lockState = CursorLockMode.Locked;
            yaw = 235.0f;
            pitch = 15.0f;
            StartCoroutine("CentreMouseCursor");
        }

    }

    IEnumerator CentreMouseCursor()
    {
        yield return new WaitForSeconds(0.5f);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");
        Camera.main.transform.eulerAngles = new Vector3(Mathf.Clamp(pitch, 0, 10), Mathf.Clamp(yaw, 230, 240), 0);

    }
}