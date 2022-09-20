using UnityEngine;
using UnityEngine.Events;

public class PlayerLogic : MonoBehaviour
{
    public UnityEvent<float> Jumped;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private int _minValue;
    [SerializeField] private int _maxValue;

    private  float _sizeStep = 3;
    private float _timeForJump = 2;
    private float _nowTime;
    private int _valueForJump;
    private Vector3 _targetPosition;

    private void Start()
    {
        _targetPosition = transform.position;
    }

    private void Update()
    {
        _nowTime += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.W) && _targetPosition.y != _maxValue)
            _targetPosition = new Vector2(_targetPosition.x, _targetPosition.y + _sizeStep);
        else if (Input.GetKeyDown(KeyCode.S) && _targetPosition.y != _minValue)
            _targetPosition = new Vector2(_targetPosition.x, _targetPosition.y - _sizeStep);

        if (Input.GetKeyDown(KeyCode.Space) && _targetPosition.y != 0)
        {
            if (_nowTime >= _timeForJump)
            {
                if (_targetPosition.y == _maxValue)
                    _valueForJump = _minValue;
                else if (_targetPosition.y == _minValue)
                    _valueForJump = _maxValue;

                transform.position = new Vector2(transform.position.x, _valueForJump);
                _targetPosition = new Vector2(transform.position.x, _valueForJump);

                if (_targetPosition.y == _maxValue || _targetPosition.y == _minValue)
                    _nowTime = 0;

                Jumped?.Invoke(_timeForJump);
            }
        }

        if (transform.position != _targetPosition)
            transform.position = Vector2.MoveTowards(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);
    }
}
