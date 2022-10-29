using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button btnOne = GameObject.Find("Button Quit").GetComponent<Button>();
        btnOne.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
    void QuitGame()
    {
        Application.Quit();
        Debug.Log("Exited");
    }
}
