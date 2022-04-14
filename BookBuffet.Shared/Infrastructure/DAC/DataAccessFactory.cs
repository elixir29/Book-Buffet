
using BookBuffet.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBuffet.Shared
{
    public class DataAccessFactory : FactoryBase, IDataAccessFactory
    {
        private static volatile DataAccessFactory _instance;
        private static object _syncObject = new object();

        #region Ctor
        /// <summary>
        /// Constructor definition
        /// </summary>
        private DataAccessFactory()
        {
        }
        #endregion

        #region Public Properties

        /// <summary>
        /// Instance is private static property to return the same Instance of the class everytime.
        /// Note: Double - checked serialized initialization of class pattern is used.
        /// </summary>
        public static DataAccessFactory Instance
        {
            get
            {
                #region Single Instance Logic
                //Check for null before acquiring the lock.
                if (_instance == null)
                {
                    //Use a _syncObject to lock on, to avoid deadlocks among multiple threads.
                    lock (_syncObject)
                    {
                        //Again check if _instance has been initialized, 
                        //since some other thread may have acquired the lock first and constructed the object.
                        if (_instance == null)
                        {
                            _instance = new DataAccessFactory();
                        }
                    }
                }
                #endregion

                return _instance;
            }
        }

        #endregion

        #region DataAccessFactory Members

        /// <summary>
        /// Creates the specified BDC type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public IDataAccess Create(DataAccessType type, params object[] args)
        {
            // get attribute value
            QualifiedTypeNameAttribute QualifiedNameAttr = EnumAttributeUtility<DataAccessType, QualifiedTypeNameAttribute>.GetEnumAttribute(type.ToString());

            // create instance
            return (IDataAccess)this.CreateObjectInstance(QualifiedNameAttr.AssemblyFileName, QualifiedNameAttr.QualifiedTypeName, args);
        }

        #endregion
    }
}
