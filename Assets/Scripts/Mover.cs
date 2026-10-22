using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    [SerializeField] private float _speed;

    private void OnEnable()
    {
        _inputReader.DirectionInputing += Move;
    }

    private void OnDisable()
    {
        _inputReader.DirectionInputing -= Move;
    }

    private void Move(float horizontalDirection, float verticalDirection)
    {
        Vector2 direction = new Vector2(horizontalDirection, verticalDirection);

        transform.Translate(_speed * Time.deltaTime * direction);
    }
}
