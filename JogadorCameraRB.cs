using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CriarPersonagem.Jogador
{
    public class JogadorCameraRB : MonoBehaviour
    {
        [SerializeField] private float lookSensitivity;
        [SerializeField] private float lookSmoothing;

        private float xAxisClamp;

        private Transform playerTransform;
        private Vector2 smoothedVelocity;
        private Vector2 currentLookingDirection;

        public AudioSource audioSource;

        private void Awake()
        {
            playerTransform = transform.root;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            audioSource = GetComponent<AudioSource>();
            audioSource.loop = true;
            audioSource.Play();
        }        

        // Update is called once per frame
        void Update()
        {
            RotateCamera();
        }

        private void RotateCamera()
        {
            Vector2 cameraRotationInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

            xAxisClamp = currentLookingDirection.y;

            cameraRotationInput = Vector2.Scale(cameraRotationInput, new Vector2(lookSensitivity * lookSmoothing, lookSensitivity * lookSmoothing));
            smoothedVelocity = Vector2.Lerp(smoothedVelocity, cameraRotationInput, 1 / lookSmoothing);

            currentLookingDirection += smoothedVelocity;

            transform.localRotation = Quaternion.AngleAxis(-currentLookingDirection.y, Vector3.right);
            playerTransform.localRotation = Quaternion.AngleAxis(currentLookingDirection.x, playerTransform.up);

            if (xAxisClamp > 90.0f)
            {
                xAxisClamp = 90.0f;                
                ClampXAxisRotationToValue(270.0f);
            }
            else if (xAxisClamp < -90.0f)
            {
                xAxisClamp = -90.0f;                
                ClampXAxisRotationToValue(90.0f);
            }
        }

        private void ClampXAxisRotationToValue(float value)
        {
            Vector3 eulerRotation = transform.eulerAngles;
            eulerRotation.x = value;
            transform.eulerAngles = eulerRotation;
        }
    }    
}