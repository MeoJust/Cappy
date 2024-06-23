using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Button _startBTN;

    void Start()
    {
        _startBTN.onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        SceneSwitcher.instance.LoadScene(1);
    }
}
