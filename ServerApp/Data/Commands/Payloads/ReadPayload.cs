using ServerApp.Data.Services.Helpers;
using System;

namespace ServerApp.Data.Commands.Payloads
{
    public abstract class ReadPayload<TFilterType, TOrderingType> : IPayload
        where TFilterType   : Enum
        where TOrderingType : Enum
    {
        public TFilterType            FilterCode   { get; protected set; }
        public TOrderingType          OrderingCode { get; protected set; }
        public OrderType              OrderCode    { get; protected set; }
        public (int Number, int Size) Page         { get; protected set; }


        public ReadPayload(TFilterType filterCode, TOrderingType orderingCode, OrderType orderCode, int pageNumber, int pageSize)
        {
            this.FilterCode   = filterCode;
            this.OrderingCode = orderingCode;
            this.OrderCode    = orderCode;
            this.Page         = (pageNumber, pageSize);
        }

        public ReadPayload(int filterCode, int orderingCode, int orderType, int pageNumber, int pageSize)
        {
            var isFilterCodeDefined   = Enum.IsDefined(typeof(TFilterType  ), filterCode  );
            var isOrderingCodeDefined = Enum.IsDefined(typeof(TOrderingType), orderingCode);
            var isOrderCodeDefined    = Enum.IsDefined(typeof(OrderType    ), orderType   );


            this.FilterCode   = (isFilterCodeDefined   ? (TFilterType  )(object)filterCode   : default);
            this.OrderingCode = (isOrderingCodeDefined ? (TOrderingType)(object)orderingCode : default);
            this.OrderCode    = (isOrderCodeDefined    ? (OrderType    )(object)orderType    : default);
            this.Page         = (pageNumber, pageSize);
        }

        public ReadPayload(string filterCodeName, string orderingCode, string orderType, int pageNumbe, int pageSize)
        {
            var isFilterCodeDefined   = Enum.IsDefined(typeof(TFilterType  ), filterCodeName.Trim());
            var isOrderingCodeDefined = Enum.IsDefined(typeof(TOrderingType), orderingCode.Trim()  );
            var isOrderCodeDefined    = Enum.IsDefined(typeof(OrderType    ), orderType.Trim()     );


            this.FilterCode   = (isFilterCodeDefined   ? (TFilterType  )Enum.Parse(typeof(TFilterType  ), filterCodeName, true) : default);
            this.OrderingCode = (isOrderingCodeDefined ? (TOrderingType)Enum.Parse(typeof(TOrderingType), orderingCode  , true) : default);
            this.OrderCode    = (isOrderCodeDefined    ? (OrderType    )Enum.Parse(typeof(OrderType    ), orderType     , true) : default);
            this.Page         = (pageNumbe, pageSize);
        }
    }
}
