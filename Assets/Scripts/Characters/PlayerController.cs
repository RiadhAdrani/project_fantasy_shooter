using UnityEngine;

public class PlayerController : Character
{
    private CharacterController controller;
            public CharacterController mController;
            public void setController(CharacterController controller) { this.controller = controller; }
            public CharacterController getController() { return controller; }

    private float mouseSensitivty;
            public float mMouseSensitivity;
            public void setMouseSensitivity(float sensitivity) { mouseSensitivty = sensitivity; }
            public float getMouseSensitivity() { return mouseSensitivty; }

    private GameObject pCamera;
            public GameObject mCamera;
            public void setpCamera(GameObject camera) { pCamera = camera; }
            public GameObject getCamera() { return pCamera; }

    private float cameraRotation;
            public float mCameraRotation;
            public void setCameraRotation(float rotation) { cameraRotation = rotation; }
            public float getCameraRotation() { return cameraRotation; }

    private WeaponsManager weaponManager;
            public WeaponsManager mWeaponManager;
            public void setWeaponManager(WeaponsManager manager) { weaponManager = manager; }
            public WeaponsManager getWeaponManager() { return weaponManager; }

    public override void Jump()
    {
        setVelocityY(Mathf.Sqrt(getJumpHeight() * -2f * CONST.GRAVITY));
    }

    public override void onAwake()
    {
        throw new System.NotImplementedException();
    }

    public override void onDeath()
    {
        throw new System.NotImplementedException();
    }

    public override void Run()
    {
        setIsGrounded(IsGrounded());

        if (getIsGrounded() && getVeclocity().y < 0)
        {
            setVelocityY(CONST.IDLE_VELOCITY);
        }

        float x = Input.GetAxis(CONST.HORIZONTAL_AXIS);

        float y = Input.GetAxis(CONST.VERTICAL_AXIS);

        Vector3 move = transform.right * x + transform.forward * y;

        getController().Move(move * getRunSpeed() * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && getIsGrounded())
        {
            Jump();
            Debug.Log("Velocity = " + getVeclocity().y);
        }

        setVelocityY(getVeclocity().y + CONST.GRAVITY * Time.deltaTime);

        getController().Move(getVeclocity() * Time.deltaTime);

    }

    public override void Walk()
    {
        throw new System.NotImplementedException();
    }

    private void Look()
    {
        // get value of the horizontal mouvement of the mouse
        float mouseX = Input.GetAxis(CONST.MOUSE_X) * getMouseSensitivity() * Time.deltaTime;

        // get value of the vertical mouvement of the mouse
        float mouseY = Input.GetAxis(CONST.MOUSE_Y) * getMouseSensitivity() * Time.deltaTime;

        setCameraRotation(getCameraRotation() - mouseY);

        setCameraRotation(Mathf.Clamp(getCameraRotation(), CONST.CAMERA_ROTATION_LIMIT_NEGATIVE, CONST.CAMERA_ROTATION_LIMIT_POSITIVE));

        getCamera().transform.localRotation = Quaternion.Euler(getCameraRotation(), 0f, 0f);

        gameObject.transform.Rotate(Vector3.up * mouseX);
    }

    private void Shoot()
    {
        getWeaponManager().Shoot();
    }

    // Start is called before the first frame update
    // extending the constructor
    void Start()
    {
        Constructor();
        setMouseSensitivity(mMouseSensitivity);
        setpCamera(mCamera);
        setCameraRotation(mCameraRotation);
        setWeaponManager(mWeaponManager);
        setController(mController);
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Look();
        Run();

        if (Input.GetButton(CONST.FIRE_1))
        {
            Shoot();
        }
    }
}
