using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//Erik Neuhofer
//Changes the color of the text of the menubutton

public class MenuButtonColorChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text theText;

    public void OnPointerEnter(PointerEventData eventData)
    {
        theText.color = Color.grey; 
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        theText.color = Color.white; 
    }
}
