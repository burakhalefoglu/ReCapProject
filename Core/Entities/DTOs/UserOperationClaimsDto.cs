using Core.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;


namespace Core.Entities.DTOs
{
    public class UserOperationClaimsDto : IDto
    {
        public int UserId { get; set; }
        public string OperationClaimName { get; set; }
    }
}
