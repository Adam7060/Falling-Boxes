using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float xMin, xMax, halfScreen;
    private readonly int movingSpeed = 7;

    private void Start()
    {
        xMin = - Bounds.ScreenBounds.x;
        xMax = Bounds.ScreenBounds.x;
        halfScreen = Screen.width * 0.5f;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Move();
        }
    }

    private void Move()
    {
        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Stationary)
        {
            if (touch.position.x < halfScreen)
            {
                transform.Translate(new Vector3(Time.deltaTime * -movingSpeed, 0, 0));
            }

            if (touch.position.x > halfScreen)
            {
                transform.Translate(new Vector3(Time.deltaTime * movingSpeed, 0, 0));
            }
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, xMin, xMax),
            transform.position.y, transform.position.z);
        }
    }
}
