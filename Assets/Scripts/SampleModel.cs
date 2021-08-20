using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class SampleModel
{
    public StringReactiveProperty rxinputText = new StringReactiveProperty();
    public string inputText
    {
        get
        {
            return rxinputText.Value;
        }
        set
        {
            rxinputText.Value = value;
        }
    }


    public BoolReactiveProperty rxButton = new BoolReactiveProperty(false);
    public bool button
    {
        get
        {
            return rxButton.Value;
        }
        set
        {
            rxButton.Value = value;
        }
    }



}
