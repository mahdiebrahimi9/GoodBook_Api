﻿using Common.Domain;

namespace Book.Domain.UserAgg
{
    public class UserRole : BaseEntity
    {
        public UserRole(long roleId)
        {
            RoleId = roleId;
        }

        public long UserId { get; internal set; }
        public long RoleId { get; private set; }
    }
}
