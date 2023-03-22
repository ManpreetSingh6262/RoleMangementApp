using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageBLL.CustomBLL
{
   public  class RoleDetail
    {

        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Desiganation { get; set; }
        public string Mobile_Number { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }
}
