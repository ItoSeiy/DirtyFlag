using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeColorManager : SingletonMonoBehaviour<ChangeColorManager>
{
    public bool Dirty => _dirty;

    public int ClickCountToChangeColor => _clickCountToChangeColor;

    [SerializeField]
    private int _clickCountToChangeColor = 1;

    private bool _dirty;

    public void SetDirty(bool flag)
    {
        _dirty = flag;
    }
}
