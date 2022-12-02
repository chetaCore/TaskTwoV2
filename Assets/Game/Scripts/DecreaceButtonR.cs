using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DecreaceButtonR : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private ElementColoroing elementColoroing;
    private IEnumerator coloring;

    private void Start()
    {
        coloring = elementColoroing.DecreaceR();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine(coloring);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        StopCoroutine(coloring);
    }
}
