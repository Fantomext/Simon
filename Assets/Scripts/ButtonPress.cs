using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ButtonPress : MonoBehaviour
{
    [SerializeField] SkinnedMeshRenderer button;
    [SerializeField] ColorWay colorWay;
    [SerializeField] Scorer scorer;
    [SerializeField] ColorChange colorChange;
    [SerializeField] AudioSource pressSound;
    
    
    bool pressed;
    
    void Start()
    {
        button = GetComponent<SkinnedMeshRenderer>();
        button.material.DisableKeyword("_EMISSION");
    }

 

    private void OnMouseDown()
    {
        
        if (colorWay.ChainShowStatus() == false)
        {
            button.material.EnableKeyword("_EMISSION");
            pressSound.Play();
        }
        
        
        if (colorWay.listButtons.Count != 0 && colorWay.StatusGame())
        {
            if (gameObject.name == colorWay.listButtons[0].name)
            {
                Debug.Log("right");
                colorWay.DeleteChainColor();
            }
            else
            {
                if (colorWay.Life() == 0)
                {
                    Debug.Log("not right");
                    colorWay.ShowUIButtons();
                    scorer.ShowText();
                    scorer.CounterSuccessful();
                    colorWay.EndGameStatus();
                   
                }
                else
                {
                    colorWay.StartChain();
                    colorWay.LostLife();
                }
                
            }
        }
    }

    
    private void OnMouseUp()
    {
       
        
            button.material.DisableKeyword("_EMISSION");
        
        
        if (colorWay.listButtons.Count == 0 && colorWay.StatusGame())
        {
            scorer.CounterAndMoneyInc();
            if (colorWay.GameRandomStatus())
            {
                colorWay.StartNewChainRandom();
            }
            else
            {
                colorWay.StartNewChain();
            }
            
        }
            
    }

    //public void ClickButton()
    //{
    //    if (colorWay.ChainShowStatus() == false)
    //    {
    //        StartCoroutine(WaitFlashButton());

    //        if (colorWay.listButtons.Count != 0)
    //        {
    //            if (gameObject.name == colorWay.listButtons[0].name)
    //            {
    //                Debug.Log("right");
    //                colorWay.DeleteChainColor();
    //            }
    //            else
    //            {
    //                Debug.Log("not right");
    //                colorWay.RestartChain();
    //            }
    //        }


    //        if (colorWay.listButtons.Count == 0)
    //        {

    //            colorWay.StartNewChain();

    //        }
    //    }
    //}

    //IEnumerator WaitFlashButton()
    //{

    //    button.material.EnableKeyword("_EMISSION");
    //    yield return new WaitForSeconds(0.5f);
    //    button.material.DisableKeyword("_EMISSION");
    //}
}
