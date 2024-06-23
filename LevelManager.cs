using TMPro;
using UnityEngine;
using DG.Tweening;

public class LevelManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _coinzTXT;
    [SerializeField] GameObject _player;
    [SerializeField] Transform _playerStart;

    int _coinzOnLevel = 0;

    void Start()
    {
        UpdateCoinzTXT();
    }

    public void AddCoin()
    {
        CoinTXTAnim();
        _coinzOnLevel++;
        UpdateCoinzTXT();
    }

    void UpdateCoinzTXT()
    {
        _coinzTXT.text = _coinzOnLevel.ToString();
    }

    void CoinTXTAnim()
    {
        _coinzTXT.transform.DOScale(2f, .1f).OnComplete(() => _coinzTXT.transform.DOScale(1f, .1f));
    }

    void ResDaPlayer(){
        Player player = FindObjectOfType<Player>();
        if(player != null){ Destroy(player.gameObject); }
        Instantiate(_player, _playerStart.position, _playerStart.rotation);
    }
}
