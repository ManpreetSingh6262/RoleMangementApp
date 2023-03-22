using ManageBLL.CustomBLL;
using ManageDAL.ContextDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageDAL.CustomDal
{
    public class RoleMasterDAL
    {
        public static List<RoleDetail> GetDetail()
        {
            using (var context = new ApplicationDBEntities())

            {
                List<RoleDetail> obj = new List<RoleDetail>();

                var Data = context.tblRoleMasters.ToList();

                obj = Data.Select(x => new RoleDetail
                {
                    RoleId = x.RoleId,
                    RoleName = x.RoleName,
                    Desiganation = x.Desiganation,
                    Mobile_Number = x.Mobile_Number,
                    Email = x.Email,
                }).ToList();
                return obj;
            }
        }

        public static List<RoleDetail> GetDetails(int RoleId)
        {
            using (var context = new ApplicationDBEntities())

            {
                List<RoleDetail> obj = new List<RoleDetail>();

                var Data = context.tblRoleMasters.Where(x => x.RoleId == RoleId).ToList();
                obj = Data.Select(x => new RoleDetail
                {
                    RoleId = x.RoleId,
                    RoleName = x.RoleName,
                    Desiganation = x.Desiganation,
                    Mobile_Number = x.Mobile_Number,
                    Email = x.Email,
                }).ToList();
                return obj;
            }
        }

       

        public static string AddRole(RoleDetail obj)
        {
            using (var context = new ApplicationDBEntities())
            {
                var check = context.tblRoleMasters.Where(x => x.RoleName == obj.RoleName).FirstOrDefault();
               
                if(check!= null)
                {
                    return "Duplicate Vlaue in RoleName :(";
                    
                }
               
                else
                {
                    tblRoleMaster Reobj = new tblRoleMaster()
                    {
                        RoleName = obj.RoleName,
                        Desiganation = obj.Desiganation,
                        Mobile_Number = obj.Mobile_Number,
                        Email = obj.Email,
                        Password = obj.Password,
                        IsActive = true,
                        CreatedBy = obj.CreatedBy,
                        CreationDate = DateTime.Now,
                    };
                    context.Entry(Reobj).State = System.Data.Entity.EntityState.Added;
                    context.SaveChanges();
                }
            }
            return "Role Add Sucessfully :)";
        
        }

        public static string EditRole(RoleDetail obj)

        {
            using (var context = new ApplicationDBEntities())
            {
                var check = context.tblRoleMasters.Where(x => x.RoleName == obj.RoleName && x.RoleId != obj.RoleId).FirstOrDefault();
                
                if (check != null)
                {
                    return "Duplicate Vlaue in RoleName   :(";
                }
                else
                {
                    var RD = context.tblRoleMasters.Where(x => x.RoleId == obj.RoleId).FirstOrDefault();
                    if (RD != null)
                    {
                        RD.RoleName = obj.RoleName;
                        RD.Desiganation = obj.Desiganation;
                        RD.Mobile_Number = obj.Mobile_Number;
                        RD.Email = obj.Email;
                        RD.Password = obj.Password;
                        RD.IsActive = true;
                        RD.ModifiedBy = 1;
                        RD.ModifiedDate = DateTime.Now;


                        context.Entry(RD).State = System.Data.Entity.EntityState.Modified;
                        context.SaveChanges();
                    }
                    
                }
            }
            return "Role Update SUCESSFULLY";
        }


        public static string RemoveUser(int RoleId)
        {
            using (var context = new ApplicationDBEntities())
            {
                var delObj = context.tblRoleMasters.Find(RoleId);
                context.tblRoleMasters.Remove(delObj);
                context.SaveChanges();
            }

            return "delete Sucessfully :|";

        }

    }
}
