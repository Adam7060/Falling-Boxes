using UnityEngine;

public class FreeFall : MonoBehaviour
{
    public Rigidbody2D rb;
    private readonly int direction = -1;

    void FixedUpdate()
    {
        rb.velocity = new Vector2(0, direction) * BoxSpawner.fallingSpeed * Time.deltaTime;

    }

    void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
