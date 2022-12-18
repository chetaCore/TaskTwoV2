using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSet : MonoBehaviour
{
    public static Action<GameObject> elementSelected;
    public static Action<Color> colorChanged;
}
