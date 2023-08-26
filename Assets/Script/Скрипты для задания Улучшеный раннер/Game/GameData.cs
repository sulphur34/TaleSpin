using UnityEngine;
using IJunior.TypedScenes;

public class GameData : MonoBehaviour
{
    [SerializeField] private Background _background;
    [SerializeField] private Plane _playerPlane;
    [SerializeField] private Difficulty _difficulty;

    public Background Background => _background;
    public Plane PlayerPlane => _playerPlane;
    public Difficulty Difficulty => _difficulty;

    public void SetGameData(Plane playerPlane, Background background, Difficulty difficulty)
    {
        _playerPlane = playerPlane;
        _background = background;
        _difficulty = difficulty;
    }

    public void LoadGame() 
    {
        SampleScene.Load((_playerPlane, _background, _difficulty));
    }
}
