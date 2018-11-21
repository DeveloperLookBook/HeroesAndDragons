using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data.Commands.Payloads
{
    public class CreateHitPayload
    {
        public int TargetId { get; set; }
        public int SourceId { get; set; }

        public CreateHitPayload()
        {

        }

        public CreateHitPayload(int targetId, int sourceId)
        {
            TargetId = targetId;
            SourceId = sourceId;
        }
    }
}
