using UnityEngine;

//Simon Voss
//Handles the players hp, and checks if the player has lost or not, also calles for an update in the visual display of the players hp at set intervals

public class HpManager : MonoBehaviour
{
    [SerializeField] private float _startHp;
    [SerializeField] private GameObject hpCanvas;
    [SerializeField] private GameObject hpVisual;

    private float hp;
    private float changeHeartImageIntervall = 0.9f;

    public static HpManager instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        HP = _startHp;
        hpCanvas.GetComponent<UpdateMyText>().UpdateMyTextAsFloat(hp);
    }

    
    public float HP
    {
        get { return hp; }
        set
        {
            hp = value;
            hpCanvas.GetComponent<UpdateMyText>().UpdateMyTextAsFloat(hp);
        }
    }
    public void IncreaseHP(int hpToAdd)
    {
        HP += hpToAdd;
    }

    public void RemoveHP(int hpToRemove)
    {
        HP -= hpToRemove;
        if (CheckIfLost())
        {
            GetComponent<StatesMethods>().ShowLoosingState();
        }
        if (HP <= _startHp * changeHeartImageIntervall && HP > 0)
        {
            Debug.Log("Calling for a change in healthimage");
            hpVisual.GetComponent<UpdateMyImage>().ChangeToNext();
            changeHeartImageIntervall -= 0.1f;
        }
    }

    public bool CheckIfLost()
    {
        if (HP <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

