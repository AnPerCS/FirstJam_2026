using UnityEngine;

public class SizeManager : MonoBehaviour
{
    [Header("Settings")]
    private Vector3 defaultScale = Vector3.one;
    private Vector3 currentStoredSize = Vector3.one;

    public bool IsResized => transform.localScale != defaultScale;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Consumable"))
        {
            AbsorbSize(other.gameObject);
        }
    }

    private void AbsorbSize(GameObject pickup)
    {
        currentStoredSize = pickup.transform.localScale;
        transform.localScale = currentStoredSize;
        Destroy(pickup);
    }

    public void ResetSize()
    {
        transform.localScale = defaultScale;
        currentStoredSize = defaultScale;
    }
}