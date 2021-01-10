using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameObject restartButton;  
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Time.timeScale = 0;
            gameObject.SetActive(false);
            restartButton.SetActive(true);
        }
    }
}
