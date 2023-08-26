using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SettingsApplier : MonoBehaviour
{
    [SerializeField] private ToggleGroup _planeToggle;
    [SerializeField] private ToggleGroup _backgroundToggle;
    [SerializeField] private DifficultyPickerHandler[] _difficulty;
    [SerializeField] private Difficulty _defaultDifficulty;
    [SerializeField] private GameData _gameData;

    public void ApplySettings()
    {
        _gameData.SetGameData(GetPlayerPlane(), GetBackground(), GetDifficulty());
    }

    private Plane GetPlayerPlane()
    {
        var test = _planeToggle.ActiveToggles();
        var test1 = test.FirstOrDefault().GetComponent<PlaneToggleData>();
        var test2 = test1.Plane;
        return test2;
    }

    private Background GetBackground()
    {
        return _backgroundToggle
            .ActiveToggles()
            .FirstOrDefault()
            .GetComponent<BackgroungToggleData>().Background;
    }

    private Difficulty GetDifficulty()
    {
        Difficulty difficulty = _defaultDifficulty;

        foreach (DifficultyPickerHandler difficultyPicker in _difficulty)
        {
            if (difficultyPicker.IsPicked)
                return difficultyPicker.GetComponent<DifficultyToggleData>().Difficulty;
        }
        
        return difficulty;
    }

}
