using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class Controller_Ui : MonoBehaviour
{
    [SerializeField]
    GameObject _imagePowerBar;

    [SerializeField]
    int record;

    [SerializeField]
    TextMeshProUGUI _record;


    bool fillBar = false;

    public bool FillBar { set { fillBar = value; } }

    // Update is called once per frame
    void Update()
    {
        if (fillBar)
        {
            if (_imagePowerBar.transform.localScale.x < 1)
                _imagePowerBar.transform.localScale = new Vector3(_imagePowerBar.transform.localScale.x + Time.deltaTime, _imagePowerBar.transform.localScale.y, _imagePowerBar.transform.localScale.z);
        }
        else
        {
            if (_imagePowerBar.transform.localScale.x > 0)
                _imagePowerBar.transform.localScale = new Vector3(_imagePowerBar.transform.localScale.x - Time.deltaTime, _imagePowerBar.transform.localScale.y, _imagePowerBar.transform.localScale.z);
        }
    }

    public void SetRecord(int r)
    {
        _record.text = (r - 1).ToString();
    }
}
