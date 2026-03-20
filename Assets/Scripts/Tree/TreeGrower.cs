using UnityEngine;

public class TreeGrower : MonoBehaviour
{
    public GameObject trunkPrefab;
    public Transform leafTop;
    public float segmentHeight = 1.0f;
    public int initialTrunkCount = 1;
    public int addMultiplier = 2;

    private int spawnedCount = 0;

    public void Grow(int amountToAdd)
    {
        int totalAmountToAdd = amountToAdd * addMultiplier;
        for (int i = 0; i < totalAmountToAdd; i++)
        {
            int slotIndex = initialTrunkCount + spawnedCount;
            float yOffset = slotIndex * segmentHeight;

            GameObject newBlock = Instantiate(trunkPrefab, transform);
            newBlock.transform.localPosition = new Vector3(0, yOffset, 0);

            spawnedCount++;
        }

        UpdateLeafPosition();
    }

    private void UpdateLeafPosition()
    {
        if (leafTop != null)
        {
            float totalHeight = (initialTrunkCount + spawnedCount) * segmentHeight;
            leafTop.localPosition = new Vector3(0, totalHeight, 0);
        }
    }
}