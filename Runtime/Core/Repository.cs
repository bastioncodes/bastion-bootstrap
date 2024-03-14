using System;
using System.Collections.Generic;
using System.Linq;
using Reflex.Attributes;
using SebastianFeistl.Winky.Serialization;

namespace SebastianFeistl.Winky.Core
{
    public abstract class Repository<TKey, TModel> where TModel : class
    {
        [Inject] protected IJsonConverter JsonConverter;
        
        protected Dictionary<TKey, TModel> Models = new();
        private string ModelName => typeof(TModel).Name; 

        public virtual event Action<TKey> ModelAdded = _ => { };
        public virtual event Action<TKey> ModelUpdated = _ => { };
        public virtual event Action<TKey> ModelRemoved = _ => { };

        public bool IsEmpty => Models.Count == 0;

        /// <summary>
        /// Set the <typeparam name="TModel">model</typeparam>
        /// </summary>
        /// <param name="models"></param>
        /// <param name="notifyUpdates"></param>
        /// <exception cref="ArgumentException"></exception>
        public void SetModels(Dictionary<TKey, TModel> models, bool notifyUpdates = false)
        {
            if (models == null)
            {
                throw new ArgumentException($"{nameof(models)} cannot be null.");
            }
            
            if (!notifyUpdates)
            {
                Models = models;
                return;
            }

            foreach (var (key, model) in models)
            {
                if (Exists(key))
                {
                    // Invoke "Updated" events for each model that was already present
                    Update(key, model);
                    continue;
                }
                
                // Invoke "Added" events for each new model
                Add(key, model);
            }

            foreach (var (key, model) in Models)
            {
                if (!models.ContainsKey(key))
                {
                    // Invoke "Remove" events for each model no longer present
                    Remove(key);
                }
            }
        }

        public void FromJson(string data, bool notifyUpdates = false)
        {
            var models = JsonConverter.Deserialize<Dictionary<TKey, TModel>>(data);
            SetModels(models, notifyUpdates);
        }
        
        public string ToJson()
        {
            return JsonConverter.Serialize(Models, true);
        }

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
                throw new InvalidOperationException($"Cannot get the first {ModelName} model because the repository is empty.");

            return Models.First().Value;
        }
        
        public TModel Last()
        {
            if (IsEmpty)
                throw new InvalidOperationException($"Cannot get the last {ModelName} model because the repository is empty.");

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