using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChengeColor : MonoBehaviour, IPointerClickHandler
{
	[SerializeField] ChengeColor _child;

	private MeshRenderer _renderer;

	[SerializeField] float substractAlphaValue = 0.1f;

	private void Awake()
	{
		_renderer = GetComponent<MeshRenderer>();
		if (_child == this) _child = null;
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		SubtractAlpha(substractAlphaValue);
	}

	public void SubtractAlpha(float value) {
		var setColor = _renderer.material.color;
		setColor.b -= value;

		_renderer.material.color = setColor;

		if (_child != null)
		{
			_child.SubtractAlpha(value * 0.5f);
		}

		Debug.Log("ChengeColor!");
	}

}
