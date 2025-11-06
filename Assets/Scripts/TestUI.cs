using System;
using UnityEngine;
using UnityEngine.UI;

public class TestUI : MonoBehaviour 
{
    public PlayerStateMachine playerStateMachine;

    Text stateText;

    private void Start()
    {
        stateText = GetComponent<Text>();
    }

    private void Update()
    {
        stateText.text = playerStateMachine.CurrentState.ToString();
    }
}