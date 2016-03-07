using Csla;
using Csla.Core;
using Csla.Serialization.Mobile;
using DH.Lending.Borrower.Business.Repository;
using System;
using System.Threading.Tasks;

namespace DH.Lending.Borrower.Business.Model
{
    public sealed class ObjectFactory<T>
        : IObjectFactory<T>
        where T : class, IMobileObject
    {
#pragma warning disable 67
        public Task<T> CreateAsync()
        {
            return DataPortal.CreateAsync<T>();
        }

        public Task<T> CreateAsync(object criteria)
        {
            return DataPortal.CreateAsync<T>(criteria);
        }

        public Task<T> FetchAsync()
        {
            return DataPortal.FetchAsync<T>();
        }

        public Task<T> FetchAsync(object criteria)
        {
            return DataPortal.FetchAsync<T>(criteria);
        }

        public Task<T> UpdateAsync(T obj)
        {
            return DataPortal.UpdateAsync<T>(obj);
        }

        public Task<T> ExecuteAsync(T command)
        {
            return DataPortal.ExecuteAsync<T>(command);
        }

        public Task DeleteAsync(object criteria)
        {
            return DataPortal.DeleteAsync<T>(criteria);
        }

        public T Create(object criteria)
        {
            return DataPortal.Create<T>(criteria);
        }

        public T Create()
        {
            return DataPortal.Create<T>();
        }

        public T Fetch(object criteria)
        {
            return DataPortal.Fetch<T>(criteria);
        }

        public T Fetch()
        {
            return DataPortal.Fetch<T>();
        }

        public T Execute(T obj)
        {
            return DataPortal.Execute<T>(obj);
        }

        public T Update(T obj)
        {
            return DataPortal.Update<T>(obj);
        }

        public void Delete(object criteria)
        {
            DataPortal.Delete<T>(criteria);
        }

        public void BeginCreate()
        {
            throw new NotImplementedException();
        }

        public void BeginCreate(object criteria)
        {
            throw new NotImplementedException();
        }

        public void BeginCreate(object criteria, object userState)
        {
            throw new NotImplementedException();
        }

        public void BeginFetch()
        {
            throw new NotImplementedException();
        }

        public void BeginFetch(object criteria)
        {
            throw new NotImplementedException();
        }

        public void BeginFetch(object criteria, object userState)
        {
            throw new NotImplementedException();
        }

        public void BeginUpdate(T obj)
        {
            throw new NotImplementedException();
        }

        public void BeginUpdate(T obj, object userState)
        {
            throw new NotImplementedException();
        }

        public void BeginDelete(object criteria)
        {
            throw new NotImplementedException();
        }

        public void BeginDelete(object criteria, object userState)
        {
            throw new NotImplementedException();
        }

        public void BeginExecute(T command)
        {
            throw new NotImplementedException();
        }

        public void BeginExecute(T command, object userState)
        {
            throw new NotImplementedException();
        }

        public ContextDictionary GlobalContext => ApplicationContext.GlobalContext;

        public event EventHandler<DataPortalResult<T>> CreateCompleted;
        public event EventHandler<DataPortalResult<T>> FetchCompleted;
        public event EventHandler<DataPortalResult<T>> UpdateCompleted;
        public event EventHandler<DataPortalResult<T>> DeleteCompleted;
        public event EventHandler<DataPortalResult<T>> ExecuteCompleted;
#pragma warning restore
    }
}
