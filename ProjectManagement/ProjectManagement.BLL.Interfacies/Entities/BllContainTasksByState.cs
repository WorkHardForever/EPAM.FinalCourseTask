using System.Collections.Generic;

namespace ProjectManagement.BLL.Interface.Entities
{
    public class BllContainTasksByState
    {
        public List<BllTask> Todo { get; set; }

        public List<BllTask> InProcess { get; set; }

        public List<BllTask> Done { get; set; }
    }
}
