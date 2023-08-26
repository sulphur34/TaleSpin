using UnityEngine;
using UnityEngine.UI;

public class HUDHandler : MonoBehaviour
{
    [SerializeField] private GameController _gameController;
    [SerializeField] private Image[] _healthPoints;
    [SerializeField] private Image[] _bulletPoints;
    [SerializeField] private Slider _slider;

    private float _sliderValue;

    private void LateUpdate()
    {
        DisplayActivePoints(_gameController.PlayerHealth, _healthPoints);
        DisplayActivePoints(_gameController.PlayerAmmo, _bulletPoints);
        _sliderValue = _gameController.EnemiesSpawnedCount / (float)_gameController.EnemiesCount;
        _slider.value = _sliderValue;
    }

    private void DisplayActivePoints(int pointsCount, Image[] points)
    {
        for (int i = 0; i < points.Length; i++)
        {
            points[i].enabled = i < pointsCount ? true : false;
        }
    }
}
