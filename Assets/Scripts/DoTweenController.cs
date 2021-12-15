using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DoTweenController : Singleton<DoTweenController>
{
    [SerializeField]
    private Vector3 _targetLocation = Vector3.zero;
    [SerializeField]
    private float _scaleMultiplier = 1.3f;

    [Range(1.0f, 10f), SerializeField]
    private float _moveDuration = 1.0f;

    [SerializeField]
    private Ease _moveEase = Ease.Linear;

    [SerializeField]
    private DoTweenType _doTweenType = DoTweenType.MovementOneWay;

    [SerializeField]
    private enum DoTweenType
    {
        MovementOneWay,
        MovementTwoWay,
        MovementOneWayChangeScale


    }
     void Start()
    {
        if (_doTweenType == DoTweenType.MovementOneWay)
        {
            if (_targetLocation == Vector3.zero)
            {
                _targetLocation = transform.position;
            }
            transform.DOMove(_targetLocation, _moveDuration).SetEase(_moveEase);
        }
       else if(_doTweenType == DoTweenType.MovementTwoWay)
        {
            if (_targetLocation == Vector3.zero)
            {
                _targetLocation = transform.position;
                //transform.DOMove(_targetLocation, _moveDuration).SetEase(_moveEase);
            }
            StartCoroutine(MovementBothWays());

        }
        else if (_doTweenType == DoTweenType.MovementOneWayChangeScale)
        {
            if (_targetLocation == Vector3.zero)
                _targetLocation = transform.position;

            transform.DOScale(_scaleMultiplier, _moveDuration).SetEase(_moveEase);
        }

    }

    IEnumerator MovementBothWays()
    {
        Vector3 originalLocation = transform.position;
        transform.DOMove(_targetLocation, _moveDuration).SetEase(_moveEase); // go target
        yield return new WaitForSeconds(_moveDuration);                      // wait
        transform.DOMove(originalLocation,_moveDuration).SetEase(_moveEase); // return original position.
    }
}
