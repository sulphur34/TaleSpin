using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class DifficultyPickerHandler : MonoBehaviour
{
    [SerializeField] private Button[] _buttons;
    [SerializeField] private Sprite _uncheckedImage;
    [SerializeField] private Sprite _checkedImage;

    private bool _isPicked;

    public bool IsPicked => _isPicked;

    public void PickEvent()
    {
        GetComponent<Image>().sprite = _checkedImage;
        _isPicked = true;

        foreach (Button button in _buttons) 
        {
            button.image.sprite = _uncheckedImage;
            button.GetComponent<DifficultyPickerHandler>().UnpickButton();
        }
    }

    public void UnpickButton()
    {
        _isPicked = false;
    }
}
