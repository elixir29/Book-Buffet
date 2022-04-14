using System.Diagnostics.CodeAnalysis;

namespace BookBuffet.Shared
{
    /// <summary>
    /// Represents the abstract base class for all facades,
    /// Author : Nagarro     
    /// </summary>
    public abstract class FacadeBase : IBusinessFacade
    {
        #region Ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="FacadeBase"/> class.
        /// </summary>
        /// <param name="facadeType">Type of the facade.</param>
        protected FacadeBase(BusinessFacadeType facadeType)
        {
            FacadeType = facadeType;
        }
        #endregion

        #region IFacade Members

        /// <summary>
        /// Gets the type of the facade.
        /// </summary>
        /// <value>The type of the facade.</value>
        public BusinessFacadeType FacadeType { get; private set; }

        #endregion
    }
}
