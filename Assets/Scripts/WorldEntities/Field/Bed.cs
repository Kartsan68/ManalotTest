using UnityEngine;

namespace Kartsan.ManalotGamesTest.WorldEntities
{
    public class Bed
    {
        private Vector3 _spawnPlantPosition;
        private Transform _plantsParent;
        private Plant _actualPlant;

        public bool IsFree { get; private set; }
        public bool IsActive { get; private set; }

        public Bed(Vector3 spawnPosition, Transform plantsParent)
        {
            _spawnPlantPosition = spawnPosition;
            _plantsParent = plantsParent;
            IsFree = true;
            IsActive = false;
        }

        public void DestroyGrass() => IsActive = true;

        public void SetPlant(Plant plant)
        {
            IsFree = false;
            _actualPlant = GameObject.Instantiate(plant, _spawnPlantPosition, Quaternion.identity, _plantsParent);

            _actualPlant.Planting();
        }

        public void PickUpPlant()
        {
            if (_actualPlant == null || !_actualPlant.IsReadyToPickUp) return;

            _actualPlant.PickUp();
            IsFree = true;
        }
    }
}