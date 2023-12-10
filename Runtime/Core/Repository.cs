using System;
using System.Collections.Generic;
using System.Linq;

namespace SebastianFeistl.Winky.Core
{
    public abstract class Repository<TKey, TModel> where TModel : class
    {
        protected readonly Dictionary<TKey, TModel> Models = new();
        private string ModelName => typeof(TModel).Name; 

        public virtual event Action<TKey> ModelAdded = _ => { };
        public virtual event Action<TKey> ModelUpdated = _ => { };
        public virtual event Action<TKey> ModelRemoved = _ => { };

        public bool IsEmpty => Models.Count == 0;

        public virtual List<TModel> All()
        {
            return Models.Values.ToList();
        }

        public virtual TModel Find(TKey id)
        {
            if (!Exists(id))
                throw new KeyNotFoundException($"Cannot find {ModelName}: ID \"{id}\" was not found in the repository.");
            
            return Models[id];
        }

        public virtual void Add(TKey id, TModel model)
        {
            if (Exists(id))
                throw new ArgumentException($"Cannot add {ModelName}: ID \"{id}\" already exists in the repository.");
            
            Models.Add(id, model);
            
            ModelAdded.Invoke(id);
        }

        public virtual void Update(TKey id, TModel model)
        {
            if (!Exists(id))
                throw new KeyNotFoundException($"Cannot update {ModelName}: ID \"{id}\" was not found in the repository.");
            
            Models[id] = model;
            
            ModelUpdated.Invoke(id);
        }
        
        public virtual void Remove(TKey id)
        {
            if (!Exists(id))
                throw new KeyNotFoundException($"Cannot remove {ModelName}: ID \"{id}\" was not found in the repository.");
            
            Models.Remove(id);
            
            ModelRemoved.Invoke(id);
        }

        public TModel First()
        {
            if (IsEmpty)
                throw new InvalidOperationException($"Cannot get the first model because the repository is empty.");

            return Models.First().Value;
        }
        
        public TModel Last()
        {
            if (IsEmpty)
                throw new InvalidOperationException($"Cannot get the last model because the repository is empty.");

            return Models.Last().Value;
        }

        public virtual TModel Random()
        {
            if (Models.Count == 0)
                throw new InvalidOperationException($"Cannot retrieve a random {ModelName} model from an empty repository.");

            return Random(1)[0];
        }
        
        public virtual List<TModel> Random(int count, bool allowDuplicates = false)
        {
            if (Models.Count < count)
                throw new InvalidOperationException($"Cannot retrieve {count} random {ModelName} models because the repository only contains {Models.Count} models.");

            List<TModel> availableModels = Models.Values.ToList();
            List<TModel> selectedModels = new List<TModel>();
            
            for (int i = 0; i < count; i++)
            {
                // Select a random model
                int index = UnityEngine.Random.Range(0, availableModels.Count);
                selectedModels.Add(availableModels[index]);
                
                // If no duplicates are allowed, make sure it can't be selected again
                if (!allowDuplicates)
                    availableModels.RemoveAt(index);
            }
            
            return selectedModels;
        }

        public virtual bool Exists(TKey id)
        {
            return Models.ContainsKey(id);
        }

        public virtual void Clear()
        {
            Models.Clear();
        }
    }
}