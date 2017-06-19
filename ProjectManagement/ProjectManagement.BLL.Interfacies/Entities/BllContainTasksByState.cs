using System.Collections.Generic;

namespace ProjectManagement.BLL.Interfacies.Entities
{
    public class BllContainTasksByState
    {
        public IEnumerable<BllTask> Todo { get; set; }

        public IEnumerable<BllTask> InProcess { get; set; }

        public IEnumerable<BllTask> Done { get; set; }
    }
}
