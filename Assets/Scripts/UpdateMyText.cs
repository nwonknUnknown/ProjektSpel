using UnityEngine;
using UnityEngine.UI;

//Simon Voss
//Updates text of UI-panels with input numbers when called on

public class UpdateMyText : MonoBehaviour {

    public Text myText;

	public void UpdateMyTextAsInt(int inputValue)
    {
        myText.text = inputValue.ToString();
    }
    public void UpdateMyTextAsFloat(float inputValue)
    {
        myText.text = inputValue.ToString();
    }
    public void UpdateRefillCostAsInt(int inputValue)
    {
        myText.text = "Refill cost: " + inputValue.ToString();
    }
}
