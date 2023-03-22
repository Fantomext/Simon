using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scorer : MonoBehaviour
{
    [SerializeField] Text counter;
    [SerializeField] Text totalMoney;
    int countWin = 0;
    int money = 0;


    private void Start()
    {
        money = PlayerPrefs.GetInt("money");
        totalMoney.text = totalMoney.text = ($"$: {money}");
    }

    public void HideText()
    {
        counter.gameObject.SetActive(false);
        totalMoney.gameObject.SetActive(false);
    }

    public void ShowText()
    {
        counter.gameObject.SetActive(true);
        totalMoney.gameObject.SetActive(true);
    }
    public void CounterSuccessful()
    {
        counter.text = ($"Score: {countWin}");
        totalMoney.text = ($"$: {money}");
        PlayerPrefs.SetInt("money", money);
        countWin = 0;
    }

    public void CounterAndMoneyInc()
    {
        money++;
        countWin++;
    }
}
