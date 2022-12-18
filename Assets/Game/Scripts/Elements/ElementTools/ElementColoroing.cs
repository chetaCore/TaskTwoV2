using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ElementColoroing : MonoBehaviour
{
    [SerializeField] private GameObject _activeElement;
    public GameObject GetActiveElement => _activeElement;

    [SerializeField] private Button _redChannelMinusButton;
    [SerializeField] private Button _redChannelPlusButton;

    [SerializeField] private Slider _greenChannelSlider;

    [SerializeField] private Button _blueChannelRandomButton;

    private IElement _element;

    public int RedChannel { get; set; }
    public int GreenChanel { get; set; }
    public int BlueChannel { get; set; }

    private void OnEnable()
    {
        EventSet.elementSelected += (SelectElement);
        _greenChannelSlider.onValueChanged.AddListener(ChangeGreenChannel);
        _blueChannelRandomButton.onClick.AddListener(ChangeBlueChannel);
    }
   
    private void Start()
    { 
        SelectElement(_activeElement);       
    }

    private void SelectElement(GameObject obj)
    {
        if (obj.TryGetComponent(out IElement element))
        {
            _activeElement = obj;
            _element = obj.GetComponent<IElement>();
            element.SelectElementChannels();
        }      
    }

    private void ChangeGreenChannel(float value)
    {
        GreenChanel = (int)(255 * value);
        _element.ChangeChannels();
    }

    private void ChangeBlueChannel()
    {
        BlueChannel = Random.Range(1, 255);
        _element.ChangeChannels();
    }

    private void OnDisable()
    {
        EventSet.elementSelected -= (SelectElement);
    }
}
