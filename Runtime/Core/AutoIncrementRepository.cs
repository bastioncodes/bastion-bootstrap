﻿namespace Bastion.Core
{
    /// <summary>
    /// Manages a collection of models with automatic integer key assignment for each new model added.
    /// </summary>
    /// <typeparam name="TModel">The type of model stored in the repository. Must be a class.</typeparam>
    public class AutoIncrementRepository<TModel> : Repository<int, TModel> where TModel : class
    {
        /// <summary>
        /// Gets the current value of the key counter used for automatic key assignment.
        /// </summary>
        protected int KeyCounter { get; private set; }

        /// <summary>
        /// Adds a model to the repository with an automatically incremented key.
        /// </summary>
        /// <param name="model">The model to add to the repository.</param>
        public int Add(TModel model)
        {
            var id = IncrementKeyCounter();
            
            base.Add(id, model);

            return id;
        }

        /// <summary>
        /// Increments the key counter and returns the new key.
        /// </summary>
        /// <returns>The next integer key.</returns>
        private int IncrementKeyCounter()
        {
            KeyCounter++;
            
            return KeyCounter;
        }
    }
}