using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ElementColoroing : MonoBehaviour
{
    [SerializeField] private GameObject activeElement;

    [SerializeField] private TMP_Text RValue;
    [SerializeField] private TMP_Text GValue;
    [SerializeField] private TMP_Text BValue;

    [SerializeField] private Button RMinusButton;
    [SerializeField] private Button RPlusButton;

    [SerializeField] private Slider GSlider;

    [SerializeField] private Button BRandomButton;


    private int r;
    private int g;
    private int b;

    private void Awake()
    {
        EventSet.elementSelected.AddListener(SelectElement);
        GSlider.onValueChanged.AddListener(ChangeG);
        BRandomButton.onClick.AddListener(ChangeB);
    }
    private void Start()
    {
        SelectElement(activeElement);
    }

    private void UpdateColor()
    {

        if (activeElement.GetComponent<MeshRenderer>() != null)
            activeElement.GetComponent<MeshRenderer>().material.color = new Color32((byte)r, (byte)g, (byte)b, 255);
        else
            activeElement.GetComponent<Image>().color = new Color32((byte)r, (byte)g, (byte)b, 255);


        RValue.text = r.ToString();
        GValue.text = g.ToString();
        BValue.text = b.ToString();
    }

    private void SelectElement(GameObject obj)
    {
        activeElement = obj;

        var meshRenderer = obj.GetComponent<MeshRenderer>();

        if (meshRenderer != null)
        {
            Color32 color = obj.GetComponent<MeshRenderer>().material.color;
           
            r = (int)color.r;
            g = (int)color.g;
            b = (int)color.b;
        }
        else
        {
            Color32 imageColor = obj.GetComponent<Image>().color;
            r = imageColor.r;
            g = imageColor.g;
            b = imageColor.b;
        }

        GSlider.value = g / 255f;

        RValue.text = r.ToString();
        GValue.text = g.ToString();
        BValue.text = b.ToString();
    }

    public IEnumerator IncreaseR()
    {
        while (true)
        {
            if (r < 255)
            {
                r++;
                UpdateColor();
            }
            yield return new WaitForSeconds(0.1f);
        }
       
    }

    public IEnumerator DecreaceR()
    {
        while (true)
        {
            if (r > 0)
            {
                r--;
                UpdateColor();
            }
            yield return new WaitForSeconds(0.1f);
        }
    }


    private void ChangeG(float value)
    {
        g = (int)(255 * value);
        UpdateColor();
    }

    private void ChangeB()
    {
        b = Random.Range(1, 255);
        UpdateColor();
    }

}
