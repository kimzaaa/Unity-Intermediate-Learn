using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Character
{
    //TODO: Attributes
    private static PlayerController _instance;
	public static PlayerController Instance {
		get {
			if (_instance == null) {
				var objs = FindObjectsByType<PlayerController> (FindObjectsSortMode.None);
				if (objs.Length > 0)
					_instance = objs[0];
				if (objs.Length > 1) {
					Debug.LogError ("There is more than one " + typeof(PlayerController).Name + " in the scene.");
				}
				if (_instance == null) {
					GameObject obj = new GameObject ();
					obj.hideFlags = HideFlags.HideAndDontSave;
					_instance = obj.AddComponent<PlayerController> ();
				}
			}
			return _instance;
		}
	}
    
    private Vector2 _movementInput;

    #region Input System
    private InputSystem_Actions _input;

    protected override void Awake()
    {
        base.Awake();
        _input = new InputSystem_Actions();
    }

    void OnEnable()
    {
        _input.Enable();
    }

    void OnDisable()
    {
        _input.Disable();
    }
    #endregion

    /// <summary>
    /// An Unity Input system event that is called when the player presses the Move-related button.
    /// </summary>
    /// <param name="value">value from Player Input -1 - 1</param>
    void OnMove(InputValue value){
        _movementInput = value.Get<Vector2>();
    }


    void Start()
    {
        _input.Player.Sprint.started += ctx => {_isRunning = true; _speed = _runSpeed; _animator.SetBool("isRunning", true);};
        _input.Player.Sprint.canceled += ctx => {_isRunning = false; _speed = _walkSpeed; _animator.SetBool("isRunning", false);};
        _input.Player.Jump.performed += ctx => {_rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse); _animator.SetTrigger("jump");};
    }

    // TODO: Make it easier to read
    void FixedUpdate()
    {
        _speed = _isRunning ? _runSpeed : _walkSpeed;
        Vector3 movement = new Vector3(_movementInput.x, 0, _movementInput.y);
        
        movement *= _speed * 0.1f;
        transform.Translate(movement, Space.Self);

        if (_movementInput != Vector2.zero)
        {
            _animator.SetBool("isWalking", true);
        }
        else
        {
            _animator.SetBool("isWalking", false);
        }

        
        Vector3 direction = new Vector3(_movementInput.x, 0, _movementInput.y);
        if (direction != Vector3.zero)
        {
            _animator.transform.forward = direction;
        }
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.TryGetComponent<ICollectable>(out ICollectable item)){
            item.Collect(); //detect coin collision and read the coponent of "Coin"
        }
    }
}
