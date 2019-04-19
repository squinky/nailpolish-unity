using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField, Range(0.0f, 1.0f)]
	private float _lerpRate;
	private float _xRotation;
	private float _yYRotation;
 
	private void Rotate(float xMovement, float yMovement)
	{
		_xRotation += xMovement;
		_yYRotation += yMovement;
	}
 
	void Start ()
	{
		InputManager.MouseMoved += Rotate;
	}
 
	void Update ()
	{
		_xRotation = Mathf.Lerp(_xRotation, 0, _lerpRate);
		_yYRotation = Mathf.Lerp(_yYRotation, 0, _lerpRate);
		transform.eulerAngles += new Vector3(_yYRotation, -_xRotation, 0);
	}
 
	void OnDestroy()
	{
	   InputManager.MouseMoved -= Rotate;    
	}
}
