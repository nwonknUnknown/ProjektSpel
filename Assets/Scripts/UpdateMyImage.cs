using UnityEngine;
using UnityEngine.UI;

//Simon Voss
//Updated the Health-image to the next when called on

public class UpdateMyImage : MonoBehaviour {

    [SerializeField] private Sprite[] sprites;
    int i;

    public void ChangeToNext()
    {
        i++;
        if (i <= sprites.Length)
        {
            GetComponent<Image>().sprite = sprites[i];
            Debug.Log("Changing health");
        }
    }
}
