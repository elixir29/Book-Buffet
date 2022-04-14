namespace BookBuffet.Shared
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics.CodeAnalysis;

    public abstract class DACBase : IDataAccess
    {

        #region Ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="DACBase"/> class.
        /// </summary>
        /// <param name="dacType">Type of the dac.</param>
        protected DACBase(DataAccessType dacType)
        {
            DACType = dacType;
        }
        #endregion

        #region IDataAccessComponent Members

        /// <summary>
        /// private gets the type of the DAC.
        /// </summary>
        /// <value>The type of the DAC.</value>
        public DataAccessType DACType { get; private set; }

        #endregion

    }
}
