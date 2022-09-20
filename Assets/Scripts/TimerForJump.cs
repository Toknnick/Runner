using System.Collections;
using TMPro;
using UnityEngine;

public class TimerForJump : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private  WaitForSeconds _timer = new(1);
    private Coroutine _coroutine;

    public void StartTimer(float timeForJump)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = StartCoroutine(Timer(timeForJump));
        }
        else
        {
            _coroutine = StartCoroutine(Timer(timeForJump));
        }
    }

    private  IEnumerator Timer(float timeForJump)
    {
        for (int i = 0; i < timeForJump; i++)
        {
            _text.text = i.ToString();
            yield return _timer;
        }

        _text.text = "Ready to Jump \nPress space";
    }
}
