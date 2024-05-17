﻿using Game.Scripts.ECS;
using Game.Scripts.ECS.Monobehaviours;
using UnityEngine;

namespace Game.Scripts.Common
{
    public static class DragonFactory
    {
        public static DragonView CreateDragon(StaticData staticData, DragonType dragonType, Vector3 position, Quaternion rotation)
        {
            staticData.DragonsStats.TryGetValue(dragonType, out var dragonStats);
            var dragonView = staticData.DragonView.GetComponent<DragonView>();
            dragonView.foodAmountToCreateEgg = dragonStats.foodAmountToCreateEgg;
            dragonView.suitableFood = dragonStats.suitableFood;
            
            foreach (var i in dragonView.renderers)
            {
                i.material = dragonStats.material;
            }

            DragonView dragon = Object.Instantiate(staticData.DragonView,
                position,
                rotation);

            return dragon;
        }
    }
}