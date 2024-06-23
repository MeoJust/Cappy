using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour
{
    LevelManager _levelManager;

    void Start()
    {
        _levelManager = FindObjectOfType<LevelManager>();

        transform.DOScale(.8f, .5f).SetLoops(-1, LoopType.Yoyo);
        transform.DOMoveY(transform.position.y + 1, 1.5f).SetLoops(-1, LoopType.Yoyo);
    }

    void Update()
    {
        transform.Rotate(0, -90 * Time.deltaTime, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _levelManager.AddCoin();
            Destroy(gameObject);
        }
    }
}
