using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CriarPersonagem.Jogador
{
    [RequireComponent(typeof(CharacterController))]
    public class JogadorControleRB : MonoBehaviour
    {
        [SerializeField] protected float movementSpeed = 6f;
        [SerializeField] protected float jumpForce = 4f;
        [SerializeField] protected float mass = 1f;
        [SerializeField] protected float damping = 5f;

        protected CharacterController cc;

        protected float velocityY;

        protected Vector3 currentImpact;

        private readonly float gravity = Physics.gravity.y;

        public AudioSource FoostepAudioSource;

        protected virtual void Awake()
        {
            cc = GetComponent<CharacterController>();
        }

        //private void Start()
        //{
        //    audioSource.loop = true;
        //}

        // Update is called once per frame
        protected virtual void Update()
        {
            Move();
            Jump();

            if(cc.velocity.sqrMagnitude > 0 && !FoostepAudioSource.isPlaying)
            {
                FoostepAudioSource.Play();
            }
            else if(cc.velocity.sqrMagnitude == 0)
            {
                FoostepAudioSource.Stop();
            }
        }

        protected virtual void Move()
        {
            Vector3 movementInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f,Input.GetAxisRaw("Vertical")).normalized;

            movementInput = transform.TransformDirection(movementInput);

            if (cc.isGrounded && velocityY < 0f)
            {
                velocityY = 0f;
            }

            velocityY += gravity * Time.deltaTime;

            Vector3 velocity = movementInput * movementSpeed + Vector3.up * velocityY;

            if (currentImpact.magnitude > 0.2f)
                velocity += currentImpact;

            cc.Move(velocity * Time.deltaTime);

            currentImpact = Vector3.Lerp(currentImpact, Vector3.zero, damping * Time.deltaTime);
        }

        public void ResetImpact()
        {
            currentImpact = Vector3.zero;
            velocityY = 0f;
        }

        public void ResetImpactY()
        {
            currentImpact.y = 0f;
            velocityY = 0f;
        }

        protected virtual void Jump()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (cc.isGrounded)
                {
                    AddForce(Vector3.up, jumpForce);
                }
            }
        }

        public void AddForce(Vector3 direction, float magnitude)
        {            
            currentImpact += direction.normalized * magnitude / mass;
        }
    }
}
