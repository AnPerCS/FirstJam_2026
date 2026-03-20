using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private Character_Controller player;
   

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Goal"))
        {
            Debug.Log("Goal Reached");
            player.GoUp(true);
        }

    }

}
