using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Image))]

public class Heart : MonoBehaviour
{
    [SerializeField] private float _lerpDuration;

    private Image _image;
    private int _minValueFillAmount = 0;
    private int _maxValueFillAmount = 1;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _image.fillAmount = _maxValueFillAmount;
    }

    public void ToFill()
    {
        StartCoroutine(Filling(_minValueFillAmount, _maxValueFillAmount, _lerpDuration, Fill));
    }

    public void ToEmpty()
    {
        StartCoroutine(Filling(_maxValueFillAmount, _minValueFillAmount, _lerpDuration, Destroy));
    }

    private void Fill(float value)
    {
        _image.fillAmount = value;
    }

    private void Destroy(float value)
    {
        _image.fillAmount = value;
        Destroy(gameObject);
    }

    private IEnumerator Filling(float startValue, float endValue, float duration, UnityAction<float> lerpingEnd)
    {
        float elapsedTime = 0;
        float nextValue;

        while (elapsedTime < duration)
        {
            nextValue = Mathf.Lerp(startValue, endValue, elapsedTime / duration);
            _image.fillAmount = nextValue;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        lerpingEnd?.Invoke(endValue);
    }
}
