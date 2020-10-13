using UnityEngine;

namespace Kartsan.ManalotGamesTest.Data
{
    public class GameProcessData
    {
        public static GameProcessData Instance;

        public int ActualBedCount;
        public Transform PlantsCounterIconTransform;
        public ActualActionType ActualAction;
        public PlantsType ActualPlantType;

        public GameProcessData()
        {
            Instance = this;
            ActualBedCount = 0;
            ActualAction = ActualActionType.none;
            ActualPlantType = PlantsType.none;
        }
    }
}