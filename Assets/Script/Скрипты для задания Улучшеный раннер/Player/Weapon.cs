using UnityEngine;

public class Weapon : MonoBehaviour
{
    private int _maxAmmo;
    private int _currentAmmo;
    private int _minAmmo;
    private Bullet _bullet;

    public int CurrentAmmo => _currentAmmo;

    public void Init(int maxAmmo, Bullet bullet)
    {
        _maxAmmo = maxAmmo;
        _minAmmo = 0;
        _currentAmmo = _maxAmmo;
        _bullet = bullet;
    }

    public void Shoot()
    {
        if (_currentAmmo > 0)
        {
            Instantiate(_bullet.gameObject, transform.position, transform.rotation);
            _currentAmmo--;
        }
    }

    public void AddAmmo(AmmoIncreaser ammoIncreaser)
    {
        _currentAmmo += ammoIncreaser.AmmoAmount;
        _currentAmmo = Mathf.Clamp(_currentAmmo, _minAmmo, _maxAmmo);
    }
}
