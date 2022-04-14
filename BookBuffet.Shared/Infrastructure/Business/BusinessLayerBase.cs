using System;
using System.Diagnostics.CodeAnalysis;


namespace BookBuffet.Shared
{
    /// <summary>
    /// Represents the abstract base class for all Business Domain Components,
    /// Author : Nagarro     
    /// </summary>
    public abstract class BusinessLayerBase : IBusinessLogic
    {
        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessLayerBase"/> class.
        /// </summary>
        /// <param name="bdcType">Type of the BDC.</param>
        /// <param name="securityToken">The security token.</param>
        protected BusinessLayerBase(BusinessLayerType bdcType)
        {
            BDCType = bdcType;
        }

        #endregion

        #region IBusinessDomainComponent Members

        /// <summary>
        /// Gets the type of the BDC.
        /// </summary>
        /// <value>The type of the BDC.</value>
        public BusinessLayerType BDCType { get; private set; }

        #endregion
    }
}
