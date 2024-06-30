using TMPro;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [Header("GO")]
    [SerializeField] GameObject _player;
    [SerializeField] Transform _playerStart;

    [Header("UI")]
    [SerializeField] TextMeshProUGUI _coinzTXT;
    [SerializeField] GameObject _gameOverCNV;
    [SerializeField] GameObject _winCNV;
    [SerializeField] Button _resBTN;
    [SerializeField] Button _menuBTN;
    [SerializeField] Button _adBTN;
    [SerializeField] Button _nextBTN;

    int _coinzOnLevel = 0;

    LevelEnd _levelEnd;

    void Start()
    {
        UpdateCoinzTXT();

        _resBTN.onClick.AddListener(ResDaPlayer);
        _menuBTN.onClick.AddListener(ToMenu);

        _gameOverCNV.SetActive(false);
        _winCNV.SetActive(false);

        _levelEnd = FindObjectOfType<LevelEnd>();
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

    void ResDaPlayer()
    {
        Player player = FindObjectOfType<Player>();
        if (player != null) { Destroy(player.gameObject); }
        Instantiate(_player, _playerStart.position, _playerStart.rotation);

        _gameOverCNV.SetActive(false);

        Time.timeScale = 1f;
    }

    void ToMenu()
    {
        Time.timeScale = 1f;
        SceneSwitcher.instance.LoadScene(0);
    }

    public void PlayerDeath()
    {
        Time.timeScale = 0f;
        _gameOverCNV.SetActive(true);
    }

    public void WinDaLevel()
    {
        Time.timeScale = 0f;
        _winCNV.SetActive(true);
        _nextBTN.onClick.AddListener(()=> NextLevel(_levelEnd.LevelToLoad));
        _adBTN.onClick.AddListener(DoubleCoinz);
    }

    void NextLevel(int value)
    {
        Time.timeScale = 1f;
        SceneSwitcher.instance.LoadScene(value);
    }

    void DoubleCoinz(){
        print("watch da ad");
    }
}
