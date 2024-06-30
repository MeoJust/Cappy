using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    public int LevelToLoad;

    LevelManager _levelManager;
    void Start()
    {
        _levelManager = FindObjectOfType<LevelManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _levelManager.WinDaLevel();
        }
    }
}
