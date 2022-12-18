using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IncreaseButtonR : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private ElementColoroing _elementColoroing;
    private IEnumerator _coloring;

    private void Start()
    {
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
            if (_elementColoroing.RedChannel < 255)
            {
                _elementColoroing.RedChannel++;
                if (_elementColoroing.GetActiveElement.TryGetComponent(out IElement element))
                    element.ChangeChannels();
            }
            yield return new WaitForSeconds(0.1f);
        }

    }

}
