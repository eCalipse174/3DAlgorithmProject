using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PlayerEffects : MonoBehaviour
{
    [SerializeField] private Dictionary<PlayerState, VisualEffect> m_effects = new();

    private void Start()
    {
        m_effects.Add(PlayerState.FirstAttack, GameObject.Find("FirstAttack").GetComponent<VisualEffect>());
        m_effects.Add(PlayerState.SecondAttack, GameObject.Find("SecondAttack").GetComponent<VisualEffect>());
        m_effects.Add(PlayerState.ThirdAttack, GameObject.Find("ThirdAttack").GetComponent<VisualEffect>());
    }

    public void PlayEffect(PlayerState pState)
    {
        m_effects[pState].Play();
    }
}