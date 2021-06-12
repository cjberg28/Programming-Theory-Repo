using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatMan : MonoBehaviour
{
    #region Variable Declarations
    private MainUIHandler mainUIHandler;
    private Animator anim;
    //public bool IsDrunk { get; set; }
    private int m_wineCount;
    public int WineCount
    {
        get
        {
            return m_wineCount;
        }
        set
        {
            if(value < 0)
            {
                Debug.LogError("Wine count cannot be negative");
            }
            else
            {
                m_wineCount = value;
            }
        }
    }//ENCAPSULATION

    private int m_cookieCount;
    public int CookieCount
    {
        get
        {
            return m_cookieCount;
        }
        set
        {
            if (value < 0)
            {
                Debug.LogError("Cookie count cannot be negative");
            }
            else
            {
                m_cookieCount = value;
            }
        }
    }//ENCAPSULATION

    private int m_sandwichCount;
    public int SandwichCount
    {
        get
        {
            return m_sandwichCount;
        }
        set
        {
            if (value < 0)
            {
                Debug.LogError("Sandwich count cannot be negative");
            }
            else
            {
                m_sandwichCount = value;
            }
        }
    }//ENCAPSULATION

    private int m_bananaCount;
    public int BananaCount
    {
        get
        {
            return m_bananaCount;
        }
        set
        {
            if (value < 0)
            {
                Debug.LogError("Banana count cannot be negative");
            }
            else
            {
                m_bananaCount = value;
            }
        }
    }//ENCAPSULATION
    #endregion

    private void Start()
    {
        anim = GetComponent<Animator>();
        mainUIHandler = GameObject.Find("UIHandler").GetComponent<MainUIHandler>();
    }

    public void PassOutDrunk()//The alternative to making this public so Wine can call it is to make a delegate system and configure it such that FatMan can pass out when necessary.
    {
        if (!mainUIHandler.gameOver)
        {
            anim.Play("Death_02");
        }
    }
}
