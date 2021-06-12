using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainUIHandler : MonoBehaviour
{
    private FatMan fatMan;
    public TextMeshProUGUI generalText;
    private TextMeshProUGUI drunkText;
    private TextMeshProUGUI consumedText;
    private Button cookieButton;
    private Button wineButton;
    private Button bananaButton;
    private Button sandwichButton;
    private Button restartButton;
    private Button quitButton;
    public TMP_InputField quantityField;
    public bool gameOver { get; set; }
    public GameObject[] foodPrefabs;
    private int m_quantity;
    public int Quantity
    {
        get { return m_quantity;}
        set
        {
            if(value < 1)
            {
                m_quantity = -1;
            }
            else
            {
                m_quantity = value;
            }
        }
    }//ENCAPSULATION

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        fatMan = GameObject.Find("Fat Man").GetComponent<FatMan>();
        generalText = GameObject.Find("General Text").GetComponent<TextMeshProUGUI>();
        drunkText = GameObject.Find("Drunk Text").GetComponent<TextMeshProUGUI>();
        drunkText.gameObject.SetActive(false);
        consumedText = GameObject.Find("Objects Consumed Text").GetComponent<TextMeshProUGUI>();
        cookieButton = GameObject.Find("Cookie Button").GetComponent<Button>();
        wineButton = GameObject.Find("Wine Button").GetComponent<Button>();
        bananaButton = GameObject.Find("Banana Button").GetComponent<Button>();
        sandwichButton = GameObject.Find("Sandwich Button").GetComponent<Button>();
        restartButton = GameObject.Find("Restart Button").GetComponent<Button>();
        restartButton.gameObject.SetActive(false);
        quitButton = GameObject.Find("Quit Button").GetComponent<Button>();
        quitButton.gameObject.SetActive(false);
        quantityField = GameObject.Find("QuantityField").GetComponent<TMP_InputField>();
    }

    #region Restart and Quit
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    #endregion

    #region PrintMessage()
    public void PrintMessage(Wine wine)
    {
        generalText.text = "Mmm...*hiccup*";
    }
    public void PrintMessage(Cookie cookie)
    {
        generalText.text = "I always love a fresh-baked cookie...";
    }
    public void PrintMessage(Banana banana)
    {
        generalText.text = "Bananas are rich in Potassium!";
    }
    public void PrintMessage(Sandwich sandwich)
    {
        generalText.text = "Another day, another sandwich!";
    }
    #endregion

    public void GameOver()
    {
        gameOver = true;
        generalText.gameObject.SetActive(false);
        cookieButton.gameObject.SetActive(false);
        wineButton.gameObject.SetActive(false);
        bananaButton.gameObject.SetActive(false);
        sandwichButton.gameObject.SetActive(false);
        quantityField.gameObject.SetActive(false);
        drunkText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
    }

    public void UpdateCount()
    {
        string updatedText = "Food Consumed@Cookies: " + fatMan.CookieCount + "@Bananas: " + fatMan.BananaCount + "@Sandwiches: " + fatMan.SandwichCount + "@Wine: " + fatMan.WineCount;
        updatedText = updatedText.Replace("@", System.Environment.NewLine);
        consumedText.text = updatedText;
    }

    #region Spawn Methods
    public void SpawnBanana()
    {
        if (!gameOver)
        {
            for (int i = 0; i < Quantity; i++)
            {
                Instantiate(foodPrefabs[0]);
            }
        }
    }
    public void SpawnCookie()
    {
        if (!gameOver)
        {
            for (int i = 0; i < Quantity; i++)
            {
                Instantiate(foodPrefabs[1]);
            }
        }
    }
    public void SpawnSandwich()
    {
        if (!gameOver)
        {
            for (int i = 0; i < Quantity; i++)
            {
                Instantiate(foodPrefabs[2]);
            }
        }
    }
    public void SpawnWine()
    {
        if (!gameOver)
        {
            for (int i = 0; i < Quantity; i++)
            {
                Instantiate(foodPrefabs[3]);
            }
        }
    }
    #endregion

    public void onChange()
    {
        try
        {
            Quantity = int.Parse(quantityField.text);//Convert the input into an integer.
            if (Quantity == -1)
            {
                generalText.text = "Hey smarty, you can't spawn nothing, or a negative amount of food. Resetting to 1.";
                Quantity = 1;
            }
            else
            {
                generalText.text = "";//Remove the snobby error message.
            }
        }
        catch (FormatException)
        {
            generalText.text = "That's not an integer, chief.";
        }
    }
}
