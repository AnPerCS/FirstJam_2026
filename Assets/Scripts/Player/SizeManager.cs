using UnityEngine;
using System.Collections.Generic;

public class SizeManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Vector3 defaultScale = Vector3.one;
    [SerializeField] private float growthFactor = 0.2f; 

    [Header("Tracking")]
    [SerializeField] private int totalConsumablesTaken = 0;
    private List<GameObject> consumedHistory = new List<GameObject>(); 

    public bool IsResized => transform.localScale != defaultScale;
    public int TotalEaten => totalConsumablesTaken;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Consumable"))
        {
            AbsorbSize(other.gameObject);
        }

        if (other.CompareTag("Tree"))
        {
            TreeGrower tree = other.GetComponent<TreeGrower>();
            if (tree != null)
            {
                if (totalConsumablesTaken == 0) return;
                tree.Grow(totalConsumablesTaken);
                ResetSize();
            }
        }
    }

    private void AbsorbSize(GameObject pickup)
    {
        totalConsumablesTaken++;

        Vector3 extraSize = pickup.transform.localScale * growthFactor;
        transform.localScale += extraSize;

        Destroy(pickup);

        Debug.Log($"Consumed! Total: {totalConsumablesTaken}. Current Scale: {transform.localScale}");
    }

    public void ResetSize()
    {
        transform.localScale = defaultScale;
        totalConsumablesTaken = 0;
    }

}