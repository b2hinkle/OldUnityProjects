using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    #region Make Singleton
    public static PlayerHealth Instance;



    private void Awake()
    {
        Instance = this;
    }
    #endregion

    int gameOverOnlyOnce = 0;


    public Texture hit1;
    public Texture hit2;
    public Texture hit3;
    public Texture hit4;


    public static int jugLevel = 0;


    float playerRegenWait = 0;
    bool isCounting = false;
    bool timerStart = false;
    bool startHelRegen = true;





    public void UpgradeJug()
    {
        if (PointsManager.player1CurrentPoints >= 1000 && jugLevel < 3)
        {
            PointsManager.player1CurrentPoints = PointsManager.player1CurrentPoints - 1000;
            PointsManager.Instance.UpdatePointsNow();

           
            jugLevel = jugLevel + 1;

            switch (jugLevel)
            {
                case 1: player1CurrentHealth = 150; Debug.Log("Jug upgraded"); break;
                case 2: player1CurrentHealth = 200; Debug.Log("Jug upgraded"); break;
                case 3: player1CurrentHealth = 250; Debug.Log("Jug upgraded"); break;
            }
          
        }
    }

    private void Start()
    {
        player1CurrentHealth = player1MaxHeath;
    }


    public static float player1CurrentHealth = 100f;
    public static float player1MaxHeath = 100f;

    int onlyDieOnce = 0;


    void Update()
    {
        switch (jugLevel)
        {
            case 0: player1MaxHeath = 100; break;
            case 1: player1MaxHeath = 150; break;
            case 2: player1MaxHeath = 200; break;
            case 3: player1MaxHeath = 250; break;
        }

        if (player1CurrentHealth > 0)
        {
            if (GameManager.gotHit == true)
            {
                TimerStartOver();
            }
            if (timerStart == true)
            {
                TimerStart();
            }
            if (startHelRegen == true)
            {
                StartHelRegen();
            }

            ManageHealth();
        }

        if (player1CurrentHealth <= 0)
        {
            gameOverOnlyOnce++;
            if (gameOverOnlyOnce == 1)
            {
                GameManager.Instance.GameOver();
                gameOverOnlyOnce++;
            }
            
        }

    }

    void TimerStartOver()
    {
        GameManager.gotHit = false;
        if (startHelRegen == true)
        {
            startHelRegen = false;
        }

        if (isCounting == false)
        {
            playerRegenWait = 0;
            timerStart = true;
        }
        else if (isCounting == true)
        {
            playerRegenWait = 0;
        }
    }
    #region Hit Methods
    void TimerStart()
    {
        if (playerRegenWait < 2)
        {
            isCounting = true;
            playerRegenWait = playerRegenWait + Time.deltaTime;

            if (playerRegenWait >= 2)
            {
                isCounting = false;
                startHelRegen = true;
            }
        }
    }

    void StartHelRegen()
    {
        timerStart = false;
        if (player1CurrentHealth < player1MaxHeath)
        {
            player1CurrentHealth = player1CurrentHealth + (Time.deltaTime * 10);
        }
        else
        {
            startHelRegen = false;
        }
    }

    void ManageHealth()
    {
        if (player1CurrentHealth > player1MaxHeath)
        {
            player1CurrentHealth = player1MaxHeath;
        }
        else if (player1CurrentHealth <= 0)
        {
            if (onlyDieOnce > 1)
            {
                return;
            }
            onlyDieOnce = onlyDieOnce + 1;
            if (onlyDieOnce == 1)
            {
                GameManager.Instance.GameOver();
            }
            player1CurrentHealth = 0;
        }
    }
    #endregion
    void OnGUI()
    {
        if (player1CurrentHealth < player1MaxHeath)
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), hit1);
        }
        if (player1CurrentHealth < player1MaxHeath * .8)
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), hit2);
        }
        if (player1CurrentHealth < player1MaxHeath * .6)
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), hit3);
        }
        if (player1CurrentHealth < player1MaxHeath * .4)
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), hit4);
        }
    }


    public void HurtPlayer(float damage)
    {
        GameManager.gotHit = true;
        player1CurrentHealth = player1CurrentHealth - damage;
        Debug.Log("You lost health");
    }
}
