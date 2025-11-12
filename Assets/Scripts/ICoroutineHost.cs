using System.Collections;
using UnityEngine;

public interface ICoroutineHost
{
    Coroutine StartCoroutine(IEnumerator routine);
}