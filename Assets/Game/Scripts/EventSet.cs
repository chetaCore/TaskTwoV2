using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSet : MonoBehaviour
{
    private static Action<IElementColoring> elementSelected;
    public static Action<Color32> colorChanged;

    internal static Action<IElementColoring> ElementSelected { get => elementSelected; set => elementSelected = value; }
}
