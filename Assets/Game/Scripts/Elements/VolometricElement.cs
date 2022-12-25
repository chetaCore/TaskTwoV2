using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolometricElement : MonoBehaviour, IElementColoring
{
    public void ChangeColor(Dictionary<string, int> channelValue)
    {
        string key = "";

        foreach (var channelKey in channelValue.Keys)
        {
            key = channelKey;
        }

        switch (key)
        {
            case "r":
                GetComponent<MeshRenderer>().material.color = new Color32((byte)channelValue[key], ReturnColor().g, ReturnColor().b, 255);
                break;
            case "g":
                GetComponent<MeshRenderer>().material.color = new Color32(ReturnColor().r, (byte)channelValue[key], ReturnColor().b, 255);
                break;
            case "b":
                GetComponent<MeshRenderer>().material.color = new Color32(ReturnColor().r, ReturnColor().g, (byte)channelValue[key], 255);
                break;
            default:
                break;
        }

        EventSet.colorChanged.Invoke(ReturnColor());
    }

    public Color32 ReturnColor()
    {
        return GetComponent<MeshRenderer>().material.color;
    }
}
