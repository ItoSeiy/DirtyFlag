using UnityEngine;
using UnityEngine.UI;

public class ExecuteChangeColor : MonoBehaviour
{
    [SerializeField]
    private ChangeColor[] _changeColors;

    [SerializeField]
    private Button _button;

    private void Start()
    {
        _button.onClick.AddListener(Execute);
    }

    private void Execute()
    {
        foreach(var changeColor in _changeColors)
        {
            if (changeColor.ClickCount < ChangeColorManager.Instance.ClickCountToChangeColor)
                continue;

            ChangeColorManager.Instance.SetDirty(true);
            for(int i = 0; i < changeColor.ClickCount; i++)
            {
                changeColor.OnDity();
            }

            changeColor.ResetClickCount();
        }
    }
}
