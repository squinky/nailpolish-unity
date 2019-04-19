using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void MouseMoved(float xMovement, float yMovement);
public class InputManager : MonoBehaviour
{
	private float _xMovement;
	private float _yMovement;

	public static event MouseMoved MouseMoved;

	private static void OnMouseMoved(float xmovement, float ymovement)
	{
		var handler = MouseMoved;
		if (handler != null) handler(xmovement, ymovement);
	}

	private void InvokeActionOnInput()
	{
		_xMovement = Input.GetAxis("Mouse X");
		_yMovement = Input.GetAxis("Mouse Y");
		OnMouseMoved(_xMovement, _yMovement);
	}
 
	void Update()
	{
		InvokeActionOnInput();
	}
}
