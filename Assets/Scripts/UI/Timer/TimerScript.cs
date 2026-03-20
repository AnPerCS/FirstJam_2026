using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_TextMeshProUGUI;

    private float m_Time;


    private void Awake()
    {
        m_TextMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        m_Time += Time.deltaTime;

        string formattedText = System.TimeSpan.FromSeconds(m_Time).ToString(@"mm\:ss\:ff");
        m_TextMeshProUGUI.text = formattedText; 
    }
}
