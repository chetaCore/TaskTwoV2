using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Game.Scripts.Elements.ElementTools
{
    public class ChangeAllChannelRandom : MonoBehaviour, IPointerDownHandler
    {
        private Dictionary<string, int> _redChannelDictionary = new();
        private Dictionary<string, int> _greenChannelDictionary = new();
        private Dictionary<string, int> _blueChannelDictionary = new();

        private IElementColoring _activeElement;
    
        private void OnEnable()
        {
            EventSet.ElementSelected += SetActiveElement;
        }
        private void Start()
        {
            _redChannelDictionary.Add("r", _activeElement.ReturnColor().r);
            _greenChannelDictionary.Add("g", _activeElement.ReturnColor().g);
            _blueChannelDictionary.Add("b", _activeElement.ReturnColor().b);
        }

        private void SetActiveElement(IElementColoring activeElement)
        {
            _activeElement = activeElement;
        }

        private void ChangeChannel()
        {
            _redChannelDictionary["r"] = Random.Range(1, 255);
            _greenChannelDictionary["g"] = Random.Range(1, 255);
            _blueChannelDictionary["b"] = Random.Range(1, 255);
            _activeElement.ChangeColor(_redChannelDictionary);
            _activeElement.ChangeColor(_greenChannelDictionary);
            _activeElement.ChangeColor(_blueChannelDictionary);
        }

        private void OnDisable()
        {
            EventSet.ElementSelected -= SetActiveElement;
        }


        public void OnPointerDown(PointerEventData eventData)
        {
            ChangeChannel();
        }

    }
}