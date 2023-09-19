using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeChangindBlock : MonoBehaviour
{
    [SerializeField] private float _duration;

    private int _targetTime = 3;
    private Vector3 _startScale;
    private Vector3 _endScale = new Vector3(0, 0, 0);

    private void Awake()
    {
        _startScale = transform.localScale;
    }

    private void OnCollisionEnter(Collision other)
    {
        StartCoroutine(ChangeScale(_endScale));
    }

    private IEnumerator ChangeScale(Vector3 desiredSize)
    {
        float elapsedTime = 0;

        while (elapsedTime < _targetTime)
        {
            elapsedTime += Time.deltaTime;
            transform.localScale = Vector3.Lerp(transform.localScale, desiredSize, elapsedTime / _duration);

            yield return null;
        }

        elapsedTime = 0;

        StartCoroutine(ChangeScale(_startScale));

        yield return null;
    }
}