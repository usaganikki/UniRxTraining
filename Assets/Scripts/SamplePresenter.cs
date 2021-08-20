using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class SamplePresenter : MonoBehaviour
{
    [SerializeField]
    InputField inputField;
    [SerializeField]
    Button button;
    [SerializeField]
    Text debugText;

    public SampleModel model = new SampleModel();

    // Start is called before the first frame update
    void Start()
    {
        inputField
            .OnValueChangedAsObservable()
            
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
        model.rxButton
            .Skip(1)
            .Subscribe(_ =>
            {
                debugText.text = "Button Clicked";
            });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
