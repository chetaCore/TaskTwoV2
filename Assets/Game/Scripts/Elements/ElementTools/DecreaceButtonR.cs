using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DecreaceButtonR : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private ElementColoroing _elementColoroing;
    private IEnumerator _coloring;

    private void Start()
    {
        _coloring = DecreaceR();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine(_coloring);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        StopCoroutine(_coloring);
    }

    public IEnumerator DecreaceR()
    {
        while (true)
        {
            if (_elementColoroing.RedChannel > 0)
            {
                _elementColoroing.RedChannel--;
                if (_elementColoroing.GetActiveElement.TryGetComponent(out IElement element))
                    element.ChangeChannels();
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
