using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeColor : MonoBehaviour, IPointerClickHandler
{
	public int ClickCount => _clickCount;

	[SerializeField]
	ChangeColor _child;

	[SerializeField]
	float _substractAlphaValue = 0.1f;

	private MeshRenderer _renderer;

	private int _clickCount;

	private void Awake()
	{
		_renderer = GetComponent<MeshRenderer>();
		if (_child == this) _child = null;
	}

	void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
	{
		_clickCount++;
	}

	public void ResetClickCount()
    {
		_clickCount = 0;
    }

	public void OnDity()
	{
		SubtractAlpha(_substractAlphaValue);
	}

	public void SubtractAlpha(float value)
	{
		var setColor = _renderer.material.color;
		setColor.b -= value;

		_renderer.material.color = setColor;

		if (_child != null)
		{
			_child.SubtractAlpha(value * 0.5f);
			Debug.Log("ChengeColor!");
		}
		else
        {
			ChangeColorManager.Instance.SetDirty(false);
			Debug.Log("AllColorChanged!");
        }
	}
}
