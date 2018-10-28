using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Contracts
{
    public class ContractMessages<TConcreteContract, TContractMessagesEnum>
    {
        #region FIELDS

        private static readonly Dictionary<string, Dictionary<TContractMessagesEnum, string>> _mainMessageDictionary;

        #endregion


        #region PROPERTIES

        private static object LockMainDictionaryCreation     => new object();
        private static object LockConcreteDictionaryCreation => new object();
        private static string ContractKey                    => typeof(TConcreteContract).Name;

        private static Dictionary<string, Dictionary<TContractMessagesEnum, string>> MainMessageDictionary
        {
            get => _mainMessageDictionary ?? throw new NullReferenceException("Main message dictionary wasn't created and equals to Null.");            
        }

        private static Dictionary<TContractMessagesEnum, string> СoncreteMessageDictionary
        {
            get => MainMessageDictionary.TryGetValue(ContractKey, out var dictionary) ? 
                   dictionary : throw new NullReferenceException($"{ContractKey} contract message dictionary wasn't created.");            
        }

        #endregion


        #region CONSTRUCTORS

        static ContractMessages()
        {
            lock (LockMainDictionaryCreation)
            {
                if (MainMessageDictionary is null) 
                {
                    _mainMessageDictionary = new Dictionary<string, Dictionary<TContractMessagesEnum, string>>();
                }
            }
        }        

        #endregion


        #region METHODS                

        public void   Add(TContractMessagesEnum key, string message)
        {
            lock (LockConcreteDictionaryCreation)
            {
                if (!MainMessageDictionary.ContainsKey(ContractKey))
                {
                    MainMessageDictionary.Add(ContractKey, new Dictionary<TContractMessagesEnum, string>(50));
                }

                СoncreteMessageDictionary.Add(key, message);
            }
        }

        public string Get(TContractMessagesEnum key)
        {
            return СoncreteMessageDictionary.TryGetValue(key, out var message) ? 
                   message : throw new Exception($"Key value: {ContractKey}, doesn't exist.");    
        }

        #endregion
    }
}
