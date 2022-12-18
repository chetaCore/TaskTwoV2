using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _redChannelValue;
    [SerializeField] private TMP_Text _greenChannelValue;
    [SerializeField] private TMP_Text _blueChannelValue;

    private void OnEnable()
    {
        EventSet.colorChanged += ChangeUI;
    }

    private void ChangeUI(Color channelValue)
    {
        _redChannelValue.text = channelValue.r.ToString();
        _greenChannelValue.text = channelValue.g.ToString();
        _blueChannelValue.text = channelValue.b.ToString();
    }
    private void OnDisable()
    {
        EventSet.colorChanged -= ChangeUI;
    }
}
