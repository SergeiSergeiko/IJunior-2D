using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Events;

namespace Charakted
{
    [RequireComponent(typeof(SpriteRenderer), typeof(Rigidbody2D), typeof(Animator))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private Shuriken _shuriken;
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpPower;
        [SerializeField] private VectorValue _storagePlayerPosition;

        private AudioManagerPlayer _audioManagerPlayer;
        private bool isGrounded = false;

        private CharState State
        {
            get { return (CharState)_animator.GetInteger("State"); }
            set { _animator.SetInteger("State", (int)value); }
        }

        private Rigidbody2D _rigidbody;
        private Animator _animator;
        private SpriteRenderer _sprite;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _sprite = GetComponentInChildren<SpriteRenderer>();
            _audioManagerPlayer = GetComponentInChildren<AudioManagerPlayer>();
        }

        private void Start()
        {
           transform.position = _storagePlayerPosition.InitialValue;
        }

        private void FixedUpdate()
        {
            CheckGround();
        }

        private void Update()
        {
            if (isGrounded)
            {
                State = CharState.Idle;
            }

            if (Input.GetButton("Horizontal"))
            {
                Step();
            }
            if (isGrounded && Input.GetButtonDown("Jump"))
            {
                Jump();
            }
            if (Input.GetButton("Fire1"))
            {
                Shoot();
            }
            if (Input.GetButton("Fire2"))
            {
                Run();
            }
        }

        private void Step()
        {
            Vector3 direction = transform.right * Input.GetAxis("Horizontal");

            transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, _speed * Time.deltaTime);

            _sprite.flipX = direction.x > 0.0f;

            if (isGrounded)
            {
                State = CharState.Step;
            }
        }

        private void Run()
        {
            Vector3 direction = transform.right * Input.GetAxis("Horizontal");

            transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, _speed * 2 * Time.deltaTime);

            _sprite.flipX = direction.x > 0.0f;

            if (isGrounded)
            {
                State = CharState.Run;
            }
        }

        private void Jump()
        {
            _rigidbody.AddForce(transform.up * _jumpPower, ForceMode2D.Impulse);

            _audioManagerPlayer.Jump();
        }

        private void Shoot()
        {
            State = CharState.Shoot;
        }

        private void LookForShoot()
        {
            Vector3 position = transform.position;
            position.y += 0.1f;

            Shuriken newShuriken = Instantiate(_shuriken, position, _shuriken.transform.rotation);
            newShuriken.Direction = newShuriken.transform.right * (_sprite.flipX ? 1.0f : -1.0f);
        }

        private void CheckGround()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.5f);

            isGrounded = colliders.Length > 1;

            if (!isGrounded)
            {
                State = CharState.Jump;
            }
        }
    }
}