using ManageBLL.CustomBLL;
using ManageDAL.CustomDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace manageAppUI.Controllers
{
    public class RoleMasterController : ApiController
    {
        //GET api/RoleMaster/GetList
        [HttpGet]
        public List<RoleDetail> GetList()
        {
            return RoleMasterDAL.GetDetail();
        }

        //GET api/RoleMaster/GetRoleById?RoleId
        [HttpGet]
        
        public List<RoleDetail> GetRoleById(int RoleId)
        {
            return RoleMasterDAL.GetDetails(RoleId);
        }

    

        //POST api/RoleMaster/ADDRole
        [Route("api/RoleMaster/ADDRole")]

        [HttpPost]
        public string ADDRole(RoleDetail obj)
        {
            return RoleMasterDAL.AddRole(obj);
        }

        //PUT api/RoleMaster/UpdateRole
        [HttpPut]
        public string UpdateRole(RoleDetail obj)
        {
            return RoleMasterDAL.EditRole(obj);
        }

        // Delete api/RoleMaster/RemoveCompany?RoleId
        [HttpDelete]
        
        public string RemoveCompany(int RoleId)
        {
            return RoleMasterDAL.RemoveUser(RoleId);
        }
    }

}
