
using System;

namespace Nagarro.Sample.Shared
{
    [EntityMapping("Event", MappingType.TotalExplicit)]
    public class EventDTO : DTOBase
    {
        [EntityPropertyMapping(MappingDirectionType.Both, "ID")]//There is no entity like Sample that exists
        public int ID { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "BookTitle")]
        public string BookTitle { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Date")]//There is no entity like Sample that exists
        public DateTime Date { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Location")]
        public string Location { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "StartTime")]
        public string StartTime { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Type")]//There is no entity like Sample that exists
        public EventType Type { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Duration")]
        public int? Duration { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Description")]
        public string Description { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "OtherDetails")]
        public string OtherDetails { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "InvitedEmails")]
        public string InvitedEmails { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "UserID")]//There is no entity like Sample that exists
        public int UserID { get; set; }


        [EntityPropertyMapping(MappingDirectionType.Both, "CreatedOn")]//There is no entity like Sample that exists
        public DateTime CreatedOn { get; set; }

    }
}
