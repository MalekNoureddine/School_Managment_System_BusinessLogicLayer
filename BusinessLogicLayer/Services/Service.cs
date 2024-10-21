using BusinessLogicLayer.Services.Interfaces;
using FluentValidation;
using School_Managment_System1.InterFaces.IRepositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IRepository<T> _repository;
        private readonly IValidator<T> _validator;

        public Service(IRepository<T> repository, IValidator<T> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        /// <summary>
        /// Adds an entity to the repository after validating it.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        public virtual void Add(T entity)
        {
            Validate(entity);
            _repository.Add(entity);
        }

        /// <summary>
        /// Asynchronously adds an entity to the repository after validating it.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public virtual async Task AddAsync(T entity)
        {
            Validate(entity);
            await _repository.AddAsync(entity);
        }

        /// <summary>
        /// Adds a range of entities to the repository after validating each one.
        /// </summary>
        /// <param name="entities">The list of entities to add.</param>
        public virtual void AddRange(List<T> entities)
        {
            foreach (var entity in entities)
            {
                Validate(entity);
            }
            _repository.AddRange(entities);
        }

        /// <summary>
        /// Asynchronously adds a range of entities to the repository after validating each one.
        /// </summary>
        /// <param name="entities">The list of entities to add.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public virtual async Task AddRangeAsync(List<T> entities)
        {
            foreach (var entity in entities)
            {
                Validate(entity);
            }
            await _repository.AddRangeAsync(entities);
        }

        /// <summary>
        /// Deletes an entity from the repository.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        public virtual void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity to delete cannot be null.");
            }
            _repository.Delete(entity);
        }

        /// <summary>
        /// Deletes a range of entities from the repository.
        /// </summary>
        /// <param name="entities">The list of entities to delete.</param>
        public void DeleteRange(List<T> entities)
        {
            if (entities == null || !entities.Any())
            {
                throw new ArgumentException("Entities list cannot be null or empty.", nameof(entities));
            }
            _repository.DeleteRange(entities);
        }

        /// <summary>
        /// Retrieves all entities from the repository asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous operation, containing a list of entities.</returns>
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }


        /// <summary>
        /// Updates an entity in the repository after validating it.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        public virtual void Update(T entity)
        {
            Validate(entity);
            _repository.Update(entity);
        }

        /// <summary>
        /// Asynchronously updates an entity in the repository after validating it.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public virtual async Task UpdateAsync(T entity)
        {
            Validate(entity);
            await _repository.UpdateAsync(entity);
        }

        // Other CRUD methods...

        /// <summary>
        /// Validates an entity using FluentValidation.
        /// </summary>
        /// <param name="entity">The entity to validate.</param>
        /// <exception cref="ValidationException">Thrown if validation fails.</exception>
        protected void Validate(T entity)
        {
            if (_validator != null)
            {
                var result = _validator.Validate(entity);

                if (!result.IsValid)
                {
                    throw new FluentValidation.ValidationException(result.Errors);
                    
                }
            }
        }
    }
}
