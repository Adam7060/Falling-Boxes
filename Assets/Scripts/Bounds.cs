using UnityEngine;

public class Bounds : MonoBehaviour
{
    private static Vector2 screenBounds = new Vector2();
    private static Vector2 boxSize = new Vector2();

    private static Vector2 GetScreenBounds()
    {

        screenBounds.x = (Camera.main.orthographicSize * Screen.width / Screen.height) - (GetBoxSize().x * 0.5f);
        screenBounds.y = Camera.main.orthographicSize - (GetBoxSize().y * 0.5f);
        return screenBounds;
    }

    private static Vector2 GetBoxSize()
    {
        boxSize.x = BoxPool.Instance.prefabObject.GetComponent<Renderer>().bounds.size.x;
        boxSize.y = BoxPool.Instance.prefabObject.GetComponent<Renderer>().bounds.size.y;
        return boxSize;
    }

    public static Vector2 ScreenBounds => GetScreenBounds();
}
