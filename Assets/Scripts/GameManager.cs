using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using System;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameObject titleUI;
    [SerializeField] GameObject gameScreenUI;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] TMP_Text timerUI;
    //Pass in an animator for the player which is called on game start
    [SerializeField] Animator playerAnimator;

    [SerializeField] GameObject player;

    [Header("Events")]
    //[SerializeField] IntEvent scoreEvent;
    [SerializeField] VoidEvent gameStartEvent;

    public enum State
    {
        TITLE,
        START_GAME,
        //START_LEVEL,
        PLAY_GAME,
        //PLAYER_DEAD,
        GAME_OVER
        //PLAYER_WIN
    }

    public State state = State.TITLE;
    public float timer;
    public int lives;
    public float stateTimer = 0;

    public float Timer
    {
        get { return timer; }
        set { timer = value; timerUI.text = string.Format("{0:F1}", timer); }
    }

    private void Start()
    {
        //reset game, timer goes to 5 minutes, lives to 3
        //timer = 300;
        //lives = 3;
        //titleUI.SetActive(true);
        //gameScreenUI.SetActive(false);
        //player.SetActive(false);
    }

    private void Update()
    {
        switch (state)
        {
            case State.TITLE:
                
                titleUI.SetActive(true);
                gameScreenUI.SetActive(false);
                //player.SetActive(false);
                gameOverUI.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
            case State.START_GAME:
                titleUI.SetActive(false);
                gameScreenUI.SetActive(true);
                gameOverUI.SetActive(false);
                //player.SetActive(true);
                //Set timer to 5 minutes
                Timer = 300;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                gameStartEvent.RaiseEvent();
                state = State.PLAY_GAME;
                break;
            case State.PLAY_GAME:
                gameStartEvent.RaiseEvent();
                Timer = Timer - Time.deltaTime;
                if (Timer <= 0)
                {
                    stateTimer = 0;
                    state = State.GAME_OVER;
                }
                break;
            case State.GAME_OVER:
                gameOverUI.SetActive(true);
                gameScreenUI.SetActive(false);
                //player.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
        }
    }

    public void AddTime(float time)
    {
        timer += time;
    }

    public void OnStartGame()
    {
        state = State.START_GAME;
        Console.WriteLine("Game Started");
    }

}
