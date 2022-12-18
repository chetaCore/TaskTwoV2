using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectElement : MonoBehaviour,  IPointerDownHandler
{

    public void OnPointerDown(PointerEventData eventData)
    {
        EventSet.elementSelected.Invoke(gameObject);
    }
}
