using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlatElement : MonoBehaviour, IElement
{
    [SerializeField] private ElementColoroing _elementColoroing;

    public void ChangeChannels()
    {
        if (TryGetComponent(out Image image))
            _elementColoroing.GetActiveElement.GetComponent<Image>().color = new Color32((byte)_elementColoroing.RedChannel, (byte)_elementColoroing.GreenChanel, (byte)_elementColoroing.BlueChannel, 255);

        EventSet.colorChanged.Invoke(new Color(_elementColoroing.RedChannel, _elementColoroing.BlueChannel, _elementColoroing.GreenChanel));
    }

    public void SelectElementChannels()
    {
        Color32 imageColor = _elementColoroing.GetActiveElement.GetComponent<Image>().color;

        _elementColoroing.RedChannel = imageColor.r;
        _elementColoroing.GreenChanel = imageColor.g;
        _elementColoroing.BlueChannel = imageColor.b;

        EventSet.colorChanged.Invoke(new Color(_elementColoroing.RedChannel, _elementColoroing.BlueChannel, _elementColoroing.GreenChanel));
    }
}
