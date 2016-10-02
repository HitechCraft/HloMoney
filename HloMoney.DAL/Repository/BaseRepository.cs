﻿using NHibernate.Util;

namespace HloMoney.DAL.Repository
{
    #region Using Directives

    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Core.DI;
    using Core.Entity.Base;
    using Core.Projector;
    using Core.Projector.Extentions;
    using Core.Repository.Specification;
    using UnitOfWork;

    using global::NHibernate.Linq;
    
    #endregion

    public class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : BaseEntity<TEntity>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IContainer _container;

        public BaseRepository(IContainer container)
        {
            _container = container;
            _unitOfWork = _container.Resolve<IUnitOfWork>();
        }

        public TEntity GetEntity(object id)
        {
            return _unitOfWork.Session.Get<TEntity>(id);
        }

        public void Add(TEntity entity)
        {
            _unitOfWork.BeginTransaction();
            _unitOfWork.Session.Save(entity);
        }

        public void Update(TEntity entity)
        {
            _unitOfWork.BeginTransaction();
            _unitOfWork.Session.Update(entity);
        }

        public void Delete(object id)
        {
            _unitOfWork.BeginTransaction();
            _unitOfWork.Session.Delete(_unitOfWork.Session.Load<TEntity>(id));
        }

        public ICollection<TResult> Query<TResult>(ISpecification<TEntity> specification,
            IProjector<TEntity, TResult> projector)
        {
            var entities = _unitOfWork.Session.Query<TEntity>();

            if (specification != null) entities = entities.Where(specification.IsSatisfiedBy());

            if (projector != null)
            {
                return entities.Project(projector).ToList();
            }
            
            return ((IQueryable<TResult>) entities).ToList();
        }

        public bool Exist(object id)
        {
            return GetEntity(id) != null;
        }

        public bool Exist(ISpecification<TEntity> specification)
        {
            return Query(specification).Any();
        }

        public bool Any()
        {
            return Query().Any();
        }

        public int Count()
        {
            return Query().Count;
        }

        public ICollection<TEntity> Query(ISpecification<TEntity> specification)
        {
            return Query<TEntity>(specification, null);
        }

        public ICollection<TResult> Query<TResult>(IProjector<TEntity, TResult> projector)
        {
            return Query(null, projector);
        }

        public ICollection Query()
        {
            return Query<TEntity>(null, null).ToList();
        }

        public void Dispose()
        {
            _unitOfWork.Commit();
        }
    }
}