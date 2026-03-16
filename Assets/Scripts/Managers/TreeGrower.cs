using UnityEngine;

public class TreeGrower : MonoBehaviour
{
    public GameObject trunkPrefab;
    public Transform leafTop;
    public float segmentHeight = 1.0f;
    public int initialTrunkCount = 1;

    private int spawnedCount = 0;

    public void Grow(int amountToAdd)
    {
        for (int i = 0; i < amountToAdd; i++)
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