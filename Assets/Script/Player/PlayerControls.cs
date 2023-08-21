using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private PlayerMover _mover;
    private Weapon _weapon;

    public void Init(PlayerMover mover, Weapon weapon)
    {
        _mover = mover;
        _weapon = weapon;
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.W))
            _mover.TryMoveUp();
        else if (Input.GetKeyUp(KeyCode.W))
            _mover.StopYMovement();

        if (Input.GetKey(KeyCode.S))
            _mover.TryMoveDown();
        else if (Input.GetKeyUp(KeyCode.S))
            _mover.StopYMovement();

        if (Input.GetKey(KeyCode.D))
            _mover.TryMoveRight();

        if (Input.GetKey(KeyCode.A))
            _mover.TryMoveLeft();

        if (Input.GetKeyDown(KeyCode.Space))
            _weapon.Shoot();
    }
}
