using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerAnimatorData : MonoBehaviour
{
    private const string MoveY = "moveY";

    private PlayerMover _mover;
    private Animator _animator;
    private int _moveYIndex;

    private void Start()
    {
        _mover = GetComponent<PlayerMover>();
        _animator = GetComponentInChildren<Animator>();
        _moveYIndex = Animator.StringToHash(MoveY);
        _mover.MovedHorizontally += AnimateTurn;
    }

    private void Update()
    {
        if (_mover.CurrentHorizontalSpeed == 0)
            AnimateTurn();
    }

    private void OnDestroy()
    {
        _mover.MovedHorizontally -= AnimateTurn;
    }

    private void AnimateTurn()
    {
        _animator.SetFloat(_moveYIndex, _mover.CurrentHorizontalSpeed);        
    }
}
