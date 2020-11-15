using UnityEngine;

public abstract class Character : MonoBehaviour
{
    // Character controller provides easy methods to controller a character
    private CharacterController controller;
            public CharacterController mController;
            public void setController(CharacterController controller) { this.controller = controller; }
            public CharacterController getController() { return controller; }

    // Hit Point
    private float hitPoint;
            public float mHitPoint;
            public void setHitPoint(float hp) { hitPoint = hp; }
            public float getHitPoint() { return hitPoint; }

    // Character's Walk speed
    private float walkSpeed;
            public float mWalkSpeed;
            public void setWalkSpeed(float speed) { walkSpeed = speed; }
            public float getWalkSpeed() { return walkSpeed; }

    // Character's Run Speed
    private float runSpeed;
            public float mRunSpeed;
            public void setRunSpeed(float speed) { runSpeed = speed; }
            public float getRunSpeed() { return runSpeed; }

    // Character's Jump Height
    private float jumpHeight;
            public float mJumpHeight;
            public void setJumpHeight(float height) { jumpHeight = height; }
            public float getJumpHeight() { return jumpHeight; }

    // Character Velocity
    private Vector3 velocity;
            public Vector3 mVelocity;
            public void setVelocity(Vector3 velocity) { this.velocity = velocity; }
            public Vector3 getVeclocity() { return velocity; }
            public void setVelocityX(float x) { velocity.x = x; }
            public void setVelocityY(float y) { velocity.y = y; }
            public void setVelocityZ(float z) { velocity.z = z; }

    // Could be used to check if the player is Grounded or not
    private Transform groundCheck;
            public Transform mGroundCheck;
            public void setGroundCheck(Transform groundCheck) { this.groundCheck = groundCheck; }
            public Transform getGroundCheck() { return groundCheck; }

    // distance between the character and the ground
    private float groundDistance;
            public float mGroundDistance;
            public void setGroundDistance(float distance) { groundDistance = distance; }
            public float getGroundDistance() { return groundDistance; }

    // layer mask of the ground
    private LayerMask groundMask;
            public LayerMask mGroundMask;
            public void setGroundMask(LayerMask groundMask) { this.groundMask = groundMask; }
            public LayerMask getGroundMask() { return groundMask; }

    // Grounded status
    private bool isGrounded;
            public bool mIsGrounded;
            public void setIsGrounded(bool isGrounded) { this.isGrounded = isGrounded; }
            public bool getIsGrounded() { return isGrounded; }

    // public Constructor
    public void Constructor()
    {
        setController(mController);
        setHitPoint(mHitPoint);
        setWalkSpeed(mWalkSpeed);
        setRunSpeed(mRunSpeed);
        setJumpHeight(mJumpHeight);
        setGroundCheck(mGroundCheck);
        setGroundDistance(mGroundDistance);
        setGroundMask(mGroundMask);
        setIsGrounded(mIsGrounded);
    }

    // Walk()
    public abstract void Walk();

    // Run()
    public abstract void Run();

    // Jump()
    public abstract void Jump();

    // onAwake()
    public abstract void onAwake();

    // on death actions
    public abstract void onDeath();

    // IsGrounded()
    // return true if the character is grounded
    // return false else
    public bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }
}
