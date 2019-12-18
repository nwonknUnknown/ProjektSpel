using UnityEngine;

//Simon Voss
//Handles the player gold, also sends for updates on the gold-canvas text in the UI when gold-ammount changes, plays sound when gold is spent

public class GoldManager : MonoBehaviour
{

    public static GoldManager instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] private int _startGold;
    private int _gold;
    [SerializeField] private GameObject goldCanvas;

    void Start()
    {
        Gold = _startGold;
        goldCanvas.GetComponent<UpdateMyText>().UpdateMyTextAsInt(_gold);
    }

    

    public int Gold
    {
        get { return _gold; }
        set
        {
            _gold = value;
            goldCanvas.GetComponent<UpdateMyText>().UpdateMyTextAsInt(_gold);
        }
    }

    public void IncreaseGold(int goldToAdd)
    {
        Gold += goldToAdd;
    }

    public void RemoveGold(int goldToRemove)
    {
        Gold -= goldToRemove;
        if (goldToRemove > 0)
        {
            GetComponent<Soundcontroller>().PlaySound();
        }
    }
}

