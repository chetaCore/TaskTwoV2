using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IncreaseButtonR : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private IEnumerator _coloring;
    private IElementColoring _activeElement;
    private Dictionary<string, int> _redChannelDictionary = new();

    private void OnEnable()
    {
        EventSet.ElementSelected += SetActiveElement;
    }

    private void SetActiveElement(IElementColoring activeElement)
    {
        _activeElement = activeElement;
    }
 
    private void Start()
    {
        _redChannelDictionary.Add("r", _activeElement.ReturnColor().r);
        _coloring = IncreaseR();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine(_coloring);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        StopCoroutine(_coloring);
    }

    public IEnumerator IncreaseR()
    {
        while (true)
        {
            if (_activeElement.ReturnColor().r < 255)
            {
                _redChannelDictionary["r"] = _activeElement.ReturnColor().r;
                _redChannelDictionary["r"] = _redChannelDictionary["r"] + 1;
                _activeElement.ChangeColor(_redChannelDictionary);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void OnDisable()
    {
        EventSet.ElementSelected -= SetActiveElement;
    }

}
