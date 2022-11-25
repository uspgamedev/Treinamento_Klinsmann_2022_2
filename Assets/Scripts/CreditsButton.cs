using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CreditsButton : MonoBehaviour
{
    static bool isClicked = false;
    public GameObject creditsScreen;
    public TextMeshProUGUI buttonText;
    // Start is called before the first frame update
    public void clicked(){
        if(isClicked){
            creditsScreen.SetActive(false);
            buttonText.text = "Creditos";
        }
        else{
            creditsScreen.SetActive(true);
            buttonText.text = "Voltar";
        }
        isClicked = !isClicked;
    }
}
