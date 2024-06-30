using UnityEngine;

public class KillY : MonoBehaviour
{
    LevelManager _levelManager;

    void Start()
    {
        _levelManager = FindObjectOfType<LevelManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _levelManager.PlayerDeath();
        }
    }
}
