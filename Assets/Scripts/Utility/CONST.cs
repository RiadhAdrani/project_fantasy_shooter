using UnityEngine;

public abstract class CONST : MonoBehaviour
{
    // global gravity
    public const float GRAVITY = -19.62f;

    // how much can the player turn the camera into the positive direction
    public const float CAMERA_ROTATION_LIMIT_POSITIVE = 80f;

    // how much can the player turn the camera into the negative direction
    public const float CAMERA_ROTATION_LIMIT_NEGATIVE = -80f;

    public const float IDLE_VELOCITY = -2f;

    public const string HORIZONTAL_AXIS = "Horizontal";

    public const string VERTICAL_AXIS = "Vertical";

    public const string MOUSE_X = "Mouse X";

    public const string MOUSE_Y = "Mouse Y";

    public const string FIRE_1 = "Fire1";
}