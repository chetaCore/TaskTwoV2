using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeGreenChannel : MonoBehaviour
{
    [SerializeField] private Slider _greenChannelSlider;
    private Dictionary<string, int> _greenChannelDictionary = new();

    private IElementColoring _activeElement;
    private void Awake()
    {
        _greenChannelSlider.onValueChanged.AddListener(ChangeColorChannel);
    }

    private void Start()
    {
        _greenChannelDictionary.Add("g", _activeElement.ReturnColor().g);
    }

    private void OnEnable()
    {
        EventSet.ElementSelected += SetActiveElement;
    }

    private void SetActiveElement(IElementColoring activeElement)
    {
        _activeElement = activeElement;
    }

    private void ChangeColorChannel(float value)
    {
        _greenChannelDictionary["g"] = (int)(255 * value);
        _activeElement.ChangeColor(_greenChannelDictionary);
    }

    private void OnDisable()
    {
        EventSet.ElementSelected -= SetActiveElement;
    }

}
