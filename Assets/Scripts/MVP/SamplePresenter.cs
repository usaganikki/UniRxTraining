using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using System;

public class SamplePresenter : MonoBehaviour
{
    [SerializeField]
    InputField inputField;
    [SerializeField]
    Button button;
    [SerializeField]
    Slider slider;
    [SerializeField]
    Text debugText;
    [SerializeField]
    Toggle toggle;

    public SampleModel model = new SampleModel();

    // Start is called before the first frame update
    void Start()
    {

        IObservable<bool> toggleObservable = toggle.OnValueChangedAsObservable();
        toggleObservable
            .Subscribe(x => {
                model.toggle = x;
            });
        var command = toggleObservable.ToReactiveCommand();

        inputField
            .OnValueChangedAsObservable()
            .Where((x) => model.toggle == true)
            .Subscribe(x =>
            {
                model.inputText = x;
                Debug.Log("TextChanged " + x);
            });
        
        model.rxinputText
            .Skip(1)
            .Subscribe(x =>
            {
                debugText.text = x;
            });

        button
            .OnClickAsObservable()
            .Skip(1)
            .Subscribe(_ =>
            {
                Debug.Log("Button click");
                model.button = !model.button;

            });
        command.BindTo(button);
        

        model.rxButton
            .Skip(1)
            .Subscribe(_ =>
            {
                debugText.text = "Button Clicked";
            });

        slider.OnValueChangedAsObservable()
            .Skip(1)
            .Subscribe(x =>
            {
                Debug.Log("slider value is " + x);
                model.slider = x;
            });

        model.rxSlider
            .Skip(1)
            .Subscribe(x =>
            {
                debugText.text = x + "";
            });



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
