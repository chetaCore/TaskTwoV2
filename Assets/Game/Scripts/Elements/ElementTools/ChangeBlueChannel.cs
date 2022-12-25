using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBlueChannel : MonoBehaviour
{
    [SerializeField] private Button _blueChannelRandomButton;
    private Dictionary<string, int> _blueChannelDictionary = new();

    private IElementColoring _activeElement;
    private void Awake()
    {
        _blueChannelRandomButton.onClick.AddListener(ChangeChannel);
    }

    private void OnEnable()
    {
        EventSet.ElementSelected += SetActiveElement;
    }
    private void Start()
    {
        _blueChannelDictionary.Add("b", _activeElement.ReturnColor().g);
    }

    private void SetActiveElement(IElementColoring activeElement)
    {
        _activeElement = activeElement;
    }

    private void ChangeChannel()
    {

        _blueChannelDictionary["b"] = Random.Range(1, 255);
        _activeElement.ChangeColor(_blueChannelDictionary);
    }

    private void OnDisable()
    {
        EventSet.ElementSelected -= SetActiveElement;
    }
}
