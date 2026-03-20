using UnityEngine;

public class TreeScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            GameObject player = GameObject.FindWithTag("Player");
            player.GetComponent<Player>()._OnWin();
        }
    }
}
