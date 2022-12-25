using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectElement : MonoBehaviour,  IPointerDownHandler
{
    private void Awake()
    {
        if (TryGetComponent(out IElementColoring elementColoring))
            EventSet.ElementSelected.Invoke(elementColoring);
    }

    private void Start()
    { 
        if (TryGetComponent(out IElementColoring elementColoring))
            EventSet.colorChanged.Invoke(elementColoring.ReturnColor());
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (TryGetComponent(out IElementColoring elementColoring))
        {
            EventSet.ElementSelected.Invoke(elementColoring);
            EventSet.colorChanged.Invoke(elementColoring.ReturnColor());
        }
    }
}
