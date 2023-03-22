using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorWay : MonoBehaviour
{
    
    [SerializeField]int countLife = 0;
    [SerializeField] List<Button> listUIButton = new List<Button>();
    [SerializeField]List<SkinnedMeshRenderer> buttons = new List<SkinnedMeshRenderer>();
    [SerializeField]Scorer scorer;
    [SerializeField] ChangeDisplay changeDisplay;


    public List<SkinnedMeshRenderer> listButtons;
   
    List<int> random = new List<int>();

    float timeToWait = 0.6f;
    int lengthGame = 2;
    bool statusGame = false;
    bool statusRandom = false;
    bool chainShow = false;
    


    private void Start()
    {
        RandomStart();
        
    }
  
    public void ShowUIButtons()
    {
        foreach (var item in listUIButton)
        {
            item.gameObject.SetActive(true);
        }
        
    }
    public void HideUIButtons()
    {
        foreach (var item in listUIButton)
        {
            item.gameObject.SetActive(false);
        }
        
    }
    public void StartGame()
    {
       
        countLife = 0;
        statusRandom = false;
        StartGameStatus();
        RestartChain();
        scorer.HideText();
        HideUIButtons();
       
    }
    public void StartGameWithLife()
    {
       
        countLife = 3;
        statusRandom = false;
        StartGameStatus();
        RestartChain();
        scorer.HideText();
        HideUIButtons();
       
    }

    

    public void AbsoluteRandom()
    {
      
        statusRandom = true;
        lengthGame = Random.Range(2,15);
        timeToWait = 0.6f;
        StartGameStatus();
        RandomStart();
        StartNewChainRandom();
        scorer.HideText();
        HideUIButtons();
        
    }

    public void RestartChain()
    {
        lengthGame = 2;
        timeToWait = 0.6f;
        RandomStart();
        StartNewChain();
    }
    public void StartChain()
    {
        StartCoroutine(DelayButton());
    }


    public void StartNewChain()
    {
        
        timeToWait = timeToWait * 0.95f;
        SingleRandom();
        listButtons = ListOfButton();
        ShowButtons();
        StartCoroutine(DelayButton());

    }
    public void StartNewChainRandom()
    {
       
        timeToWait = timeToWait * 0.95f;
        RandomStart();
        listButtons = ListOfButton();
        ShowButtons();
        StartCoroutine(DelayButton());

    }

    public void DeleteChainColor()
    {
        listButtons.RemoveAt(0);
    }

    private void ChainShowStart()
    {
        chainShow = true;
    }

    private void ChainShowEnd()
    {
        chainShow = false;
    }

    public bool ChainShowStatus()
    {
        return chainShow;
    }

    public bool GameRandomStatus()
    {
        return statusRandom;
    }
    public void StartGameStatus()
    {
        changeDisplay.enabled = false;
        statusGame = true;
    }
    public void EndGameStatus()
    {
        changeDisplay.enabled = true;
        statusGame = false;
    }
    public bool StatusGame()
    {
        return statusGame;
    }
    public int Life()
    {
        return countLife;
    }
    public void LostLife()
    {
        countLife--;
    }

   
    void RandomStart()
    {
        random.Clear();
        for (int i = 0; i < lengthGame; i++)
        {
            random.Add(Random.Range(0,4));
        }
        
    }

    void SingleRandom()
    {
        random.Add(Random.Range(0, 4));
    }


    public void ShowButtons()
    {
        List<SkinnedMeshRenderer> list = ListOfButton();
        for (int i = 0; i < list.Count; i++)
        {
            Debug.Log(list[i]);
        }
    }

    List<SkinnedMeshRenderer> ListOfButton()
    {
        List<SkinnedMeshRenderer> list = new List<SkinnedMeshRenderer>();

        for (int i = 0; i < random.Count; i++)
        {
            
            list.Add(buttons[random[i]]);
            
        }


        return list;
    }

    void ButtonOn(SkinnedMeshRenderer button)
    {
        button.material.EnableKeyword("_EMISSION");
    }

    void ButtonOff(SkinnedMeshRenderer button)
    {
        button.material.DisableKeyword("_EMISSION");
    }


    IEnumerator DelayButton()
    {

        EndGameStatus();
        ChainShowStart();
        changeDisplay.enabled = false;
        for (int i = 0; i < random.Count; i++)
        {
            yield return new WaitForSeconds(timeToWait);
            ButtonOn(buttons[random[i]]);
            yield return new WaitForSeconds(timeToWait);
            ButtonOff(buttons[random[i]]);
        }
        lengthGame++;
        ChainShowEnd();
        StartGameStatus();


    }

    

   

}
