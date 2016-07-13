using UnityEngine;
using System.Collections;

[RequireComponent (typeof (SpriteRenderer))]
public class ScreenWrap : MonoBehaviour {

	public bool wrapWidth = true;

	private Renderer _renderer;
	private Transform _transform;
	private Camera _camera;
	private Vector2 _viewportPosition;
	private bool isWrappingWidth;
	private Vector2 _newPosition;

	// Use this for initialization
	void Start () {
		_renderer = GetComponent<Renderer> ();
		_transform = transform;
		_camera = Camera.main;
		_newPosition = Vector2.zero;
		_viewportPosition = _transform.position;
		isWrappingWidth = false;
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		Wrap ();
	}

	private void Wrap(){
		bool isVisible = IsBeingRendered ();

		if(isVisible){
			isWrappingWidth = false;

		}

		_newPosition = _transform.position;
		_viewportPosition = _camera.WorldToViewportPoint (_newPosition);

		if (wrapWidth){
			if (!isWrappingWidth) {
				if (_viewportPosition.x > 1) {
					_newPosition.x = _camera.ViewportToWorldPoint (Vector2.zero).x;
					isWrappingWidth = true;

				} else if (_viewportPosition.x < 0){
					_newPosition.x = _camera.ViewportToWorldPoint (Vector2.one).x;
					isWrappingWidth = true;

				}
			}	
		}

		_transform.position = _newPosition;
	}

	private bool IsBeingRendered() {
		if(_renderer.isVisible){
			return true;
		}
		return false;
	}
}
