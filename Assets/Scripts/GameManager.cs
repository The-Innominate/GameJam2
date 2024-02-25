using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
//using System;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameObject titleUI;
    [SerializeField] GameObject gameScreenUI;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] TMP_Text timerUI;
    [SerializeField] TMP_Text instructionUI;
   
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
    //public int lives;
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
                if (gameScreenUI) gameScreenUI.SetActive(false);
                //player.SetActive(false);
                if (gameOverUI) gameOverUI.SetActive(false);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    state = State.START_GAME;
                }
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
                if (timer >= 290)
                {
                    instructionUI.text = "Press E to use teleporters. WASD or Arrow-Keys to move.";
                }
                else if (timer < 290 && timer >= 280)
                {
                    instructionUI.text = "Watch out for DANGERS such as SPIKES, HOLES, or areas that might make you SLOW.";
                }
                else if(timer < 280 && timer >= 270)
                {
                    instructionUI.text = "Find the green teleporter within 5 minutes to escape the mazes youre stuck in.";
                }
                else if (timer < 270 && timer >= 260)
                {
                    instructionUI.text = "Watch out for RED or ORANGE, they might signify danger.";
                }
                else
                {
                    instructionUI.text = "";
                }
                break;
            case State.GAME_OVER:
                gameOverUI.SetActive(true);
                gameScreenUI.SetActive(false);
                //player.SetActive(false);
                if(Input.GetKeyDown(KeyCode.Space)) 
                {
                    state = State.TITLE;
                }
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
        //Console.WriteLine("Game Started");
    }

}
