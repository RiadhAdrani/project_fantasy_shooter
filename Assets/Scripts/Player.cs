using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const float CAMERA_ROTATION_LIMIT_POSITIVE = 80f;
    private const float CAMERA_ROTATION_LIMIT_NEGATIVE = - 80f;
    private const float GRAVITY = - 19.62f;

    private CharacterController controller;

    [SerializeField] private float mouseSensitivity = 10f;
    [SerializeField] private GameObject playerCamera = null;
    private float cameraRotation = 0f;

    [SerializeField] private float mouvementSpeed = 10f;
    [SerializeField] private Vector3 velocity;
    [SerializeField] private float jumpHeight = 3f;
    [SerializeField] private Transform groundCheck = null;
    private float groundDistance = 0.25f;
    public LayerMask groundMask;
    bool isGrounded = false;

    public WeaponsManager weaponManager;

    void Start()
    {
        // getting a CharacterController from the gameObject
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        CameraLook();
        PlayerMouvement();

        if (Input.GetButton("Fire1")){
            Shoot();
        }

    }

    private void PlayerMouvement()
    {
        // making a physics check to see if the player is grounded or not
        // before performing any mouvement
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // if the character is on the ground
        // don't increase gravity force
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // get value of the hoziontal axis
        float x = Input.GetAxis("Horizontal");

        // get value of the vertical axis
        float y = Input.GetAxis("Vertical");

        // set the mouvement vector to the local vector
        Vector3 move = transform.right * x + transform.forward * y;
        
        // performing the mouvement
        controller.Move(move * mouvementSpeed * Time.deltaTime);

        // checking if the player wants to jump
        // before applying the gravity
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * GRAVITY);
            Debug.Log("Jump Pressed");
        }

        // increasing velocity
        // free fall physics
        // delta(Y) = 1/2 * g * t²
        velocity.y += GRAVITY * Time.deltaTime;
        
        // applying gravity
        controller.Move(velocity * Time.deltaTime);
    }

    private void CameraLook()
    {
        // get value of the horizontal mouvement of the mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        
        // get value of the vertical mouvement of the mouse
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // set the rotation of the camera
        // change (-) to (+) for inverted rotation
        cameraRotation -= mouseY;

        // limiting the camera hoziontally
        // so it won't reach absurd values
        // and look behind
        cameraRotation = Mathf.Clamp(cameraRotation, CAMERA_ROTATION_LIMIT_NEGATIVE, CAMERA_ROTATION_LIMIT_POSITIVE);

        // setting the local rotation to the desired value
        playerCamera.transform.localRotation = Quaternion.Euler(cameraRotation, 0f, 0f);

        // perform the rotation
        gameObject.transform.Rotate(Vector3.up * mouseX);

    }


    public void Shoot()
    {
        weaponManager.Shoot();
    }


}