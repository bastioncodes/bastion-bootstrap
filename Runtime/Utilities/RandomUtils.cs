using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Bastion.Utilities
{
    public static class RandomUtils
    {
        /// <summary>
        /// Generates a random sign (-1 or 1).
        /// </summary>
        /// <returns>Randomly -1 or 1.</returns>
        public static int GetRandomSign()
        {
            return Random.Range(0, 2) * 2 - 1;
        }
        
        /// <summary>
        /// Generates a random boolean value (true or false).
        /// </summary>
        /// <returns>Randomly true or false.</returns>
        public static bool GetRandomBool()
        {
            return Random.Range(0, 2) == 1;
        }
        
        /// <summary>
        /// Returns a random point within a circle of a given radius.
        /// </summary>
        /// <param name="radius">Radius of the circle.</param>
        /// <returns>Random point within the specified circle.</returns>
        public static Vector2 GetRandomPointInCircle(float radius)
        {
            return Random.insideUnitCircle * radius;
        }
        
        /// <summary>
        /// Returns a random point within a sphere of a given radius.
        /// </summary>
        /// <param name="radius">Radius of the sphere.</param>
        /// <returns>Random point within the specified sphere.</returns>
        public static Vector3 GetRandomPointInSphere(float radius)
        {
            return Random.insideUnitSphere * radius;
        }
        
        /// <summary>
        /// Generates a random direction vector in 3D space.
        /// </summary>
        /// <returns>Randomly oriented unit vector.</returns>
        public static Vector3 GetRandomDirection()
        {
            return Random.onUnitSphere;
        }
        
        /// <summary>
        /// Selects a random value from an enumeration type.
        /// </summary>
        /// <typeparam name="T">Enum type from which to select a value.</typeparam>
        /// <returns>Randomly selected enum value.</returns>
        public static T GetRandomEnum<T>() where T : Enum
        {
            Array values = Enum.GetValues(typeof(T));
            return (T)values.GetValue(Random.Range(0, values.Length));
        }
        
        /// <summary>
        /// Randomly shuffles the elements of a list.
        /// </summary>
        /// <typeparam name="T">Type of elements in the list.</typeparam>
        /// <param name="list">List to shuffle.</param>
        public static void ShuffleList<T>(List<T> list)
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = Random.Range(0, i + 1);
                (list[i], list[j]) = (list[j], list[i]);
            }
        }
        
        /// <summary>
        /// Returns a random element from a list.
        /// </summary>
        /// <typeparam name="T">Type of elements in the list.</typeparam>
        /// <param name="list">List from which to select the element.</param>
        /// <returns>Randomly selected element from the list.</returns>
        public static T GetRandomElement<T>(List<T> list)
        {
            if (list == null || list.Count == 0) throw new ArgumentException("List is empty or null.");
            
            return list[Random.Range(0, list.Count)];
        }
    }
}
