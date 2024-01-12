using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerController : MonoBehaviour
{
	//--- CLASSES ---//
	MouseInput _mouseInput = new MouseInput();
	IGameSettings _gameSettings = GameSettings.Instance;

	[SerializeField] private GameInput _inputs;

	//--- PLAYER ---//
	private float _threshold = 0.001f;
	private float originalHeight;
	private Vector3 originalCenter;
	public float FallTimeout = 0.15f;
	private float _terminalVelocity = 53.0f;
	private float _verticalVelocity;
	private bool _grounded;

	//--- CAMERA ---//
	public GameObject CmCamTarget;

	private float _cmTargetPitch;
	private float _rotationSpeed = 4.0f;
	private float _rotationVelocity;
	private float _minCamPitch = -90.0f;
	private float _maxCamPitch = 90.0f;

	//--- TIMING ---//
	private float _jumpTimeoutDelta;
	private float _fallTimeoutDelta;
	public float JumpTimeout = 0.1f;

	//--- REFERENCES ---//
	private CharacterController _characterController;
	private void Awake()
	{

		_mouseInput.SetMouseLocked();
		_characterController = GetComponent<CharacterController>();

	}

	void Start()
	{
		originalHeight = _characterController.height;
		originalCenter = _characterController.center;
	}

	void Update()
	{

		CheckGround();
		Movement();

	}

	private void LateUpdate()
	{

		Look();

	}

	//--- BASE ---//
	private void Movement()
	{
		Vector3 moveDir = new Vector3(_inputs.GetMovementNormalized().x, 0f, _inputs.GetMovementNormalized().y).normalized;

		if (_inputs.GetMovementNormalized() != Vector2.zero)
		{
			moveDir = transform.right * _inputs.GetMovementNormalized().x + transform.forward * _inputs.GetMovementNormalized().y;
		}


		_characterController.Move(moveDir.normalized * (10f * Time.deltaTime) +
								  new Vector3(0.0f, _verticalVelocity, 0.0f) * Time.deltaTime);
	}

	private void Look()
	{
		if (_inputs.GetLookVector().sqrMagnitude >= _threshold)
		{
			_cmTargetPitch += _inputs.GetLookVector().y * _rotationSpeed * 1;
			_rotationVelocity = _inputs.GetLookVector().x * _rotationSpeed * 1;

			_cmTargetPitch = ClampAngle(_cmTargetPitch, _minCamPitch, _maxCamPitch);

			CmCamTarget.transform.localRotation = Quaternion.Euler(_cmTargetPitch, 0.0f, 0.0f);
			transform.Rotate(Vector3.up * _rotationVelocity);
		}
	}

	//--- CALCULATIONS ---//
	private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
	{
		if (lfAngle < -360f) lfAngle += 360f;
		if (lfAngle > 360f) lfAngle -= 360f;
		return Mathf.Clamp(lfAngle, lfMin, lfMax);
	}

	private void CheckGround()
	{
		_grounded = _characterController.isGrounded;
		if (_grounded)
		{
			// reset the fall timeout timer
			_fallTimeoutDelta = FallTimeout;

			// stop our velocity dropping infinitely when grounded
			if (_verticalVelocity < 0.0f)
			{
				_verticalVelocity = -2f;
			}

			// Jump
			if (_inputs.IsJumping && _jumpTimeoutDelta <= 0.0f)
			{
				// the square root of H * -2 * G = how much velocity needed to reach desired height
				_verticalVelocity = Mathf.Sqrt(1.5f * -2f * _gameSettings.GetGravity());
			}

			// jump timeout
			if (_jumpTimeoutDelta >= 0.0f)
			{
				_jumpTimeoutDelta -= Time.deltaTime;
			}
		}
		else
		{
			// reset the jump timeout timer
			_jumpTimeoutDelta = JumpTimeout;

			// fall timeout
			if (_fallTimeoutDelta >= 0.0f)
			{
				_fallTimeoutDelta -= Time.deltaTime;
			}
		}

		// apply gravity over time if under terminal (multiply by delta time twice to linearly speed up over time)
		if (_verticalVelocity < _terminalVelocity)
		{
			_verticalVelocity += _gameSettings.GetGravity() * Time.deltaTime;
		}
	}
}