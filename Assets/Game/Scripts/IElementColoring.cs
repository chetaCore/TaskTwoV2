using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IElementColoring
{
    void ChangeColor(Dictionary<string, int> channelValue);
    Color32 ReturnColor();
}
