using UnityEngine;

public abstract class CONST : MonoBehaviour
{
    // global gravity
    public const float GRAVITY = -19.62f;

    // how much can the player turn the camera into the positive direction
    public const float CAMERA_ROTATION_LIMIT_POSITIVE = 80f;

    // how much can the player turn the camera into the negative direction
    public const float CAMERA_ROTATION_LIMIT_NEGATIVE = -80f;

    // Velocity when Character is grounded
    public const float IDLE_VELOCITY = -2f;

    // Horizontal Mouvement Axis
    public const string HORIZONTAL_AXIS = "Horizontal";

    // Vertical Mouvement Axis
    public const string VERTICAL_AXIS = "Vertical";

    // Horizontal Mouse Axis
    public const string MOUSE_X = "Mouse X";

    // Vertical Mouse Axis
    public const string MOUSE_Y = "Mouse Y";

    // Fire 1 Axis
    public const string FIRE_1 = "Fire1";

    // default speed for enemies
    public const float DEFAULT_ENEMY_SPEED = 2f;
}