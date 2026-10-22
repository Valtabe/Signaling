using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private readonly string MouseX = "Mouse X";
    private readonly string MouseY = "Mouse Y";
    private readonly string Horizontal = "Horizontal";
    private readonly string Vertical = "Vertical";
    private readonly KeyCode _activateButton = KeyCode.Mouse1;

    public event Action MouseLeftButtonClecking;
    public event Action<float, float> DirectionInputing;
    public event Action<float, float> CameraInputing;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseLeftButtonClecking?.Invoke();
        }

        if (Input.GetAxis(Horizontal) != 0 || Input.GetAxis(Vertical) != 0)
        {
            DirectionInputing?.Invoke(Input.GetAxis(Horizontal), Input.GetAxis(Vertical));
        }

        if (Input.GetKey(_activateButton))
        {
            CameraInputing?.Invoke(Input.GetAxis(MouseX), Input.GetAxis(MouseY));
        }
    }
}
