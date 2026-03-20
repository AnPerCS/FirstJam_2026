using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    [SerializeField] string levelName = "";


    public void OnButtonClicked()
    {
        SceneManager.LoadScene(levelName);
    }
}
