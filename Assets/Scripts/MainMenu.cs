using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public TMP_InputField inputField;
    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(SaveName);
    }

    private void SaveName()
    {
        Persistance.Instance.playerName = inputField.text;
        SceneManager.LoadScene("main", LoadSceneMode.Single);
    }
}
