using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    public int TotalCoins;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
