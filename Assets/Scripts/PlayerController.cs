using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Singleton<PlayerController>
{
    //TODO: Attributes
    [Header("Player Attributes")]
    [SerializeField] private Animator _animator;
    [Tooltip("Player's speed.")]
    [SerializeField] private float _walkSpeed = 1f;
    [Tooltip("Player's run speed.")]
    [SerializeField] private float _runSpeed = 2f;
    [Range(0f,100f)] public  float _jumpForce = 10f;
    [SerializeField] private Rigidbody _rigidbody;
    [Space(10)]
    
    private Vector2 _movementInput;
    private float _speed;
    private bool _isRunning = false;

    #region Input System
    private InputSystem_Actions _input;

    void Awake()
    {
        _input = new InputSystem_Actions();

        _speed = _walkSpeed;
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
