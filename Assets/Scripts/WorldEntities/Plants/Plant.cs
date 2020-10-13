using DG.Tweening;
using Kartsan.ManalotGamesTest.Data;
using System;
using System.Collections;
using UnityEngine;

namespace Kartsan.ManalotGamesTest.WorldEntities
{
    public class Plant : MonoBehaviour
    {
        public static Action<PlantsType, int> OnPickedUpPlantAction;

        [SerializeField] private PlantsType _type;
        [SerializeField] private float _growTime;
        [SerializeField] private int _countPerPickUp;
        [SerializeField] private float _flyAfterPickUpSpeed;

        private Transform _plantTransform;

        public bool IsReadyToPickUp { get; private set; }

        public PlantsType GetPlantsType => _type;

        public void Planting()
        {
            StartCoroutine(GrowProcess());
        }

        public void PickUp()
        {
            var counterPosition = GameProcessData.Instance.PlantsCounterIconTransform.position;
            var duration = Vector3.Distance(counterPosition, _plantTransform.position) / _flyAfterPickUpSpeed;

            _plantTransform.DOMove(counterPosition, duration)
                           .SetEase(Ease.Linear)
                           .onComplete += () =>
                           {
                               Destroy(gameObject);
                               OnPickedUpPlantAction?.Invoke(_type, _countPerPickUp);
                           };

            IsReadyToPickUp = false;
        }

        private void Awake()
        {
            IsReadyToPickUp = false;
            _plantTransform = transform;
        }

        private IEnumerator GrowProcess()
        {
            yield return new WaitForSeconds(_growTime);
            IsReadyToPickUp = true;
            _plantTransform.localScale *= 2;
        }
    }
}