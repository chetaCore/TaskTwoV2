using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolometricElement : MonoBehaviour, IElement
{
    [SerializeField] private ElementColoroing _elementColoroing;


    public void ChangeChannels()
    {
        if (TryGetComponent(out MeshRenderer meshRender))
            _elementColoroing.GetActiveElement.GetComponent<MeshRenderer>().material.color = new Color32((byte)_elementColoroing.RedChannel, (byte)_elementColoroing.GreenChanel, (byte)_elementColoroing.BlueChannel, 255);

        EventSet.colorChanged.Invoke(new Color(_elementColoroing.RedChannel, _elementColoroing.BlueChannel, _elementColoroing.GreenChanel));
    }

    public void SelectElementChannels()
    {
        Color32 color = _elementColoroing.GetActiveElement.GetComponent<MeshRenderer>().material.color;
        _elementColoroing.RedChannel = (int)color.r;
        _elementColoroing.GreenChanel = (int)color.g;
        _elementColoroing.BlueChannel = (int)color.b;

        EventSet.colorChanged.Invoke(new Color(_elementColoroing.RedChannel, _elementColoroing.BlueChannel, _elementColoroing.GreenChanel));
    }
}
