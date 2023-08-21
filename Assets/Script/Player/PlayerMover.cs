using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _horizontalSpeed;
    [SerializeField] private float _verticalSpeed;
    [SerializeField] private Camera _camera;

    public UnityAction MovedHorizontally;
    private float _flipAngleDown = 180f;
    private float _flipAngleUp = -180f;
    private bool _isFlipped = false;
    private Vector3 _screenTopRightBorder;
    private Vector3 _screenBottomLeftBorder;

    public float CurrentHorizontalSpeed { get; private set; }

    private void Start()
    {
        _screenTopRightBorder = _camera.ViewportToWorldPoint(new Vector3(1, 1, 0));
        _screenBottomLeftBorder = _camera.ViewportToWorldPoint(new Vector3(0, 0, 0));
    }

    public void TryMoveUp()
    {
        if (transform.position.y < _screenTopRightBorder.y)
        {
            MoveYAxis(_flipAngleUp, _verticalSpeed);
        }
    }

    public void TryMoveDown() 
    {
        if (transform.position.y > _screenBottomLeftBorder.y)
        {
            MoveYAxis(_flipAngleDown, _verticalSpeed);
        }
    }

    public void StopYMovement()
    {
        MoveYAxis(0, 0);
    }

    public void TryMoveLeft() 
    {
        if (transform.position.x > _screenBottomLeftBorder.x)        
            transform.Translate(-_horizontalSpeed * Time.deltaTime,0 , 0);
    }

    public void TryMoveRight()
    {
        if (transform.position.x < _screenTopRightBorder.x)
            transform.Translate(_horizontalSpeed * Time.deltaTime, 0, 0);
    }

    private void MoveYAxis(float directionAngle, float speed)
    {
        CurrentHorizontalSpeed = speed * Time.deltaTime;
        TryFlipYAxis(directionAngle);
        transform.Translate(0, CurrentHorizontalSpeed, 0);
        MovedHorizontally?.Invoke();
    }

    private void TryFlipYAxis(float flippingAngle)
    {
        if (flippingAngle == -180 && _isFlipped || flippingAngle == 180 && _isFlipped == false)
        { 
            transform.Rotate(flippingAngle, 0, 0);
            _isFlipped = flippingAngle > 0 ? true : false;
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("EnterHere");
    //}
}
