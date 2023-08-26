using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ToggleGroup))]
public class ButtonGroupToggleHandler : MonoBehaviour
{   
    private ToggleGroup _toggleGroup;

    private void Awake()
    {
        _toggleGroup = GetComponent<ToggleGroup>();
    }

    public void GetToggleValue()
    {
        var activeToggles = _toggleGroup.ActiveToggles();

        foreach (Toggle toggle in activeToggles)
        {
            Debug.Log(toggle.name);
        }
    }   
}
