using UnityEngine;

namespace Charakted
{
    public class Movement : Player
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpPower;

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
                Hit();
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
        }

        private void Hit()
        {
            State = CharState.Hit;
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