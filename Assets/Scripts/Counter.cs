using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TMP_Text _textDisplay;

    private Coroutine _countJob;

    private float _currentTime = 0;
    private bool _isCounterStop = true;

    private void Update()
    {
        Work();
    }

    private IEnumerator CountWithDelay()
    {
        var delay = new WaitForSeconds(0.5f);

        while(true)
        {
            _currentTime++;
            _textDisplay.text = _currentTime.ToString();

            yield return delay;
        }
    }

    private void Work()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (_isCounterStop == true)
            {
                StopCountWithDelayCoroutine();

                _countJob = StartCoroutine(CountWithDelay());
                _isCounterStop = false;
            }
            else
            {
                StopCountWithDelayCoroutine();
                _isCounterStop = true;
            }
        }
    }

    private void StopCountWithDelayCoroutine()
    {
        if (_countJob != null)
        {
            StopCoroutine(_countJob);
        }
    }
}
