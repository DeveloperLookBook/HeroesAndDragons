using ServerApp.Data.Services.Helpers;
using System;

namespace ServerApp.Data.Commands.Payloads
{
    public abstract class ReadCommandPayload : ICommandPayload
    {

    }

    public abstract class ReadCommandPayload<TFilterType, TOrderingType> : ReadCommandPayload
        where TFilterType   : Enum
        where TOrderingType : Enum
    {
        public TFilterType            FilterCode   { get; protected set; }
        public TOrderingType          OrderingCode { get; protected set; }
        public OrderType              OrderCode    { get; protected set; }
        public (int Number, int Size) Page         { get; protected set; }

        protected ReadCommandPayload(
            TFilterType   filterCode, 
            TOrderingType orderingCode, 
            OrderType     orderCode, 
            int           pageNumber, 
            int           pageSize)
        {
            FilterCode   = filterCode;
            OrderingCode = orderingCode;
            OrderCode    = orderCode;
            Page         = (Number: pageNumber, Size: pageSize);
        }
    }
}
