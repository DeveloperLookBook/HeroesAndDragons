using ServerApp.Extencions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Contracts
{    
    public abstract class Contract<TConcreteContract, TContractMessagesEnum> where TConcreteContract : class, new()
    {
        #region FIELDS

        private static readonly ContractMessages<TConcreteContract, TContractMessagesEnum> _messages;

        #endregion


        #region PROPERTIES

        public static ContractMessages<TConcreteContract, TContractMessagesEnum> Messages => _messages;

        #endregion


        #region CONSTRUCTORS

        static Contract()
        {
            if (IsEnum<TContractMessagesEnum>())
                throw new Exception($"Generic type - {typeof(TContractMessagesEnum).Name}, must be an Enum.");

            _messages = new ContractMessages<TConcreteContract, TContractMessagesEnum>();            
        }

        #endregion


        #region METHODS       

        private   static bool   IsEnum<TEnum>() => typeof(TConcreteContract).IsEnum;

        #endregion
    }
}
