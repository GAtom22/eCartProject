using System.Collections.Generic;

namespace BusinessLogic.Cart
{
    public interface IBusinessLogic<T> where T : class
    {
        ///  
        /// Get All objects  
        ///  
        ///  
        IEnumerable<T> GetAll();
        ///  
        /// Get Object by Id  
        ///  
        ///  
        T GetById(int id);
        T GetById(string id);
        ///  
        /// Create the object  
        ///  
        ///  
        void Create(T entity);
        ///  
        /// Delete object  
        ///  
        ///  
        void Delete(T entity);
        ///  
        ///  
        ///  
        ///  
        void Delete(int id);
        void Delete(string id);
        ///  
        /// Update the object  
        ///  
        ///  
        void Update(T entity);
    }
}
