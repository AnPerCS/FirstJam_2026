using System.IO;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_TextMeshProUGUI;

    private float m_Time;

    bool isRunning = false;

    public float M_Time
    {
        get { return m_Time; }
    }

    private void Awake()
    {
        m_TextMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        Player.OnWin += OnWin;
        isRunning = true;
    }

    private void OnWin()
    {
        isRunning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            m_Time += Time.deltaTime;

            string formattedText = System.TimeSpan.FromSeconds(m_Time).ToString(@"mm\:ss\:ff");
            m_TextMeshProUGUI.text = formattedText;
        }
    }
}
