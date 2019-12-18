using UnityEngine;

//Simon Voss
//Doubles the size of the UI panel when mouse is over the object. 
//Also included a function to resize it down by half when called on, needed when the button is clicked because mouse-exit never happens if clicked on

public class OnHoverEnlarge : MonoBehaviour {

    RectTransform rt;

    private void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    private void OnMouseEnter()
    {
        rt.localScale *= 2;
    }

    void OnMouseExit()
    {
        rt.localScale /= 2;
    }

    public void ReturnSizeUI()
    {
        rt.localScale /= 2;
    }
}
