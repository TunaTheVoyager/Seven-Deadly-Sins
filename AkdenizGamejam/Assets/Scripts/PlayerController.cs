using UnityEngine;
using UnityEngine.SceneManagement;

namespace gameJam
{
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody2D _rb;
        private AudioSource _aud;
        public bool IsMoving;
        public float speed;
        
        [SerializeField] private FrameInput _frameInput;
        private Vector2 _frameVelocity;
        [SerializeField] private AudioClip _walkingSound;


        #region debug

        private float _vert;
        private float _hori;
        

        #endregion

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _aud = GetComponent<AudioSource>();
        }

        private void GatherInput()
        {
            _frameInput = new FrameInput
            {
                move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"))
            };
        }

        private void HandleDirection()
        {
            if (_frameInput.move.x == 0)
            {
                _frameVelocity.x = Mathf.MoveTowards(_frameVelocity.x, _frameInput.move.x * 10, Time.fixedDeltaTime);
            }
            else
            {
                _frameVelocity.x = Mathf.MoveTowards(_frameVelocity.x, _frameInput.move.x * 10, Time.fixedDeltaTime);
            }
        }
        

        private void FixedUpdate()
        {
            ApplyMovement();

            _vert = Input.GetAxis("Vertical");
            _hori = Input.GetAxis("Horizontal");
            
            isMovingTrue();
            
            walkingSound();
        }

        private void isMovingTrue()
        {
            if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0  ) {
 
                IsMoving= true;
            }
            else
            {
                IsMoving = false;
                
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("End1"))
            {
                SceneManager.LoadScene("lazy");
            }
            if (other.CompareTag("End2"))
            {
                SceneManager.LoadScene("kibir");
            }
            if (other.CompareTag("End3"))
            {
                SceneManager.LoadScene("acgozluluk");
            }
            if (other.CompareTag("End4"))
            {
                SceneManager.LoadScene("obur");
            }
            if (other.CompareTag("End5"))
            {
                SceneManager.LoadScene("lust");
            }
            if (other.CompareTag("End6"))
            {
                SceneManager.LoadScene("Envy");
            }
            if (other.CompareTag("End7"))
            {
                SceneManager.LoadScene("Anger");
            }
        }


        private void walkingSound()
        {
            if (IsMoving) {
 
                if (!_aud.isPlaying)
                {
                    _aud.clip = _walkingSound;
                    _aud.Play ();
                }
            }
            else
            {
                _aud.Stop();
            }
        }

        private void ApplyMovement() => _rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, Input.GetAxisRaw("Vertical") * speed);

    }

    public struct FrameInput
    {
        public Vector2 move;
    }
}

