using UnityEngine;
using Random = UnityEngine.Random;

namespace TarodevController {
    /// <summary>
    /// This is a pretty filthy script. I was just arbitrarily adding to it as I went.
    /// You won't find any programming prowess here.
    /// This is a supplementary script to help with effects and animation. Basically a juice factory.
    /// </summary>
    public class PlayerAnimator : MonoBehaviour {
        [SerializeField] private Animator _anim;
        [SerializeField] private AudioSource _source;
        [SerializeField] private LayerMask _groundMask;
        [SerializeField] private ParticleSystem _jumpParticles, _launchParticles;
        [SerializeField] private ParticleSystem _moveParticles, _landParticles;
        [SerializeField] private AudioClip[] _footsteps;
        [SerializeField] private float _maxTilt = .1f;
        [SerializeField] private float _tiltSpeed = 1;

        [SerializeField] private float _maxParticleFallSpeed = -40;
        [SerializeField] private Rigidbody2D _playerRef;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _dirX;
        [SerializeField] private GameObject _soundManager;
        private AudioManager _audioManager;



        private IPlayerController _player;
        private bool _playerGrounded;
        private ParticleSystem.MinMaxGradient _currentGradient;
        private Vector2 _movement;

        void Awake() => _player = GetComponentInParent<IPlayerController>();
       
         void Start()
        {
            Rigidbody2D _rig = _playerRef.GetComponent<Rigidbody2D>();
            _moveSpeed = 5f;
            _audioManager = _soundManager.GetComponent<AudioManager>();
            
        }
        void Update() {
            if (_player == null) return;

            // Flip the sprite
            if (_player.Input.X != 0) transform.localScale = new Vector3(_player.Input.X > 0 ? 1 : -1, 1, 1);

            // Lean while running
            var targetRotVector = new Vector3(0, 0, Mathf.Lerp(-_maxTilt, _maxTilt, Mathf.InverseLerp(-1, 1, _player.Input.X)));
            _anim.transform.rotation = Quaternion.RotateTowards(_anim.transform.rotation, Quaternion.Euler(targetRotVector), _tiltSpeed * Time.deltaTime);

            // Speed up idle while running
            //_anim.SetFloat(IdleSpeedKey, Mathf.Lerp(1, _maxIdleSpeed, Mathf.Abs(_player.Input.X)));

            //if (Input.GetKeyUp(KeyCode.A)|| Input.GetKeyUp(KeyCode.D))
            //{

            //    _anim.SetFloat(IdleSpeedKey, 0);
            //}


            //_velocity = (_playerRef.transform.position - pos) / Time.deltaTime;

            //pos = transform.position;
            //_anim.SetFloat(IdleSpeedKey,_velocity.magnitude);
            //Debug.Log(IdleSpeedKey);

            //if (Input.GetKeyDown(KeyCode.D)|| Input.GetKeyDown(KeyCode.A))
            //{
            //    _anim.Play("RunningPlayer");
            //    Debug.Log("Runing");
            //}
            //else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
            //{
            //    _anim.Play("IdlePlayer");
            //    Debug.Log("Idle");
            //}

            _dirX = Input.GetAxis("Horizontal") * _moveSpeed;
            if (Mathf.Abs(_dirX) > 0 && _playerRef.velocity.y == 0)
            {
                _anim.SetBool("isRunning", true);

            }
            else
            {
                _anim.SetBool("isRunning", false);
            }
            if (Input.GetAxis("Jump") == 1)
            {   

                
                    
                
                
                _anim.SetBool("isJumped", true);
                _anim.SetBool("isGrounded", false);

            }
             else if (Input.GetAxis("Jump") == 0)
            {
                _anim.SetBool("isJumped", false);
               

            }

            // Splat
            if (_player.LandingThisFrame) {
                _anim.SetTrigger(GroundedKey);
                _anim.SetBool("isGrounded", true);
                // _source.PlayOneShot(_footsteps[Random.Range(0, _footsteps.Length)]);
            }
            
            // Jump effects
            if (_player.JumpingThisFrame) {
                _anim.SetTrigger(JumpKey);
                _anim.ResetTrigger(GroundedKey);




                // Only play particles when grounded (avoid coyote)
                if (_player.Grounded) {
                    SetColor(_jumpParticles);
                    SetColor(_launchParticles);
                    _jumpParticles.Play();
                    //_anim.Play("jumpAnim");
                    //Debug.Log("Jump");
                }
            }

            // Play landing effects and begin ground movement effects
            if (!_playerGrounded && _player.Grounded) {
                _playerGrounded = true;
                _moveParticles.Play();
                _landParticles.transform.localScale = Vector3.one * Mathf.InverseLerp(0, _maxParticleFallSpeed, _movement.y);
                SetColor(_landParticles);
                _landParticles.Play();
                //_anim.Play("IdlePlayer");
                //Debug.Log("Idle");
            }
            else if (_playerGrounded && !_player.Grounded) {
                _playerGrounded = false;
                _moveParticles.Stop();
            }

            // Detect ground color
            var groundHit = Physics2D.Raycast(transform.position, Vector3.down, 2, _groundMask);
            if (groundHit && groundHit.transform.TryGetComponent(out SpriteRenderer r)) {
                _currentGradient = new ParticleSystem.MinMaxGradient(r.color * 0.9f, r.color * 1.2f);
                SetColor(_moveParticles);
            }

            _movement = _player.RawMovement; // Previous frame movement is more valuable
        }

        private void OnDisable() {
            _moveParticles.Stop();
        }

        private void OnEnable() {
            _moveParticles.Play();
        }

        void SetColor(ParticleSystem ps) {
            var main = ps.main;
            main.startColor = _currentGradient;
        }

        #region Animation Keys

        private static readonly int GroundedKey = Animator.StringToHash("Grounded");
        private static readonly int IdleSpeedKey = Animator.StringToHash("IdleSpeed");
        private static readonly int JumpKey = Animator.StringToHash("Jump");

        #endregion
    }
}