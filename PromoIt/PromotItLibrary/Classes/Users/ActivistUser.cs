﻿using System;
using System.Threading.Tasks;
using PromotItLibrary.Enums;
using PromotItLibrary.Interfaces.Actions;
using PromotItLibrary.Interfaces.Users;
using PromotItLibrary.Models;

namespace PromotItLibrary.Classes.Users
{
    public class ActivistUser : Users, IActivistUser, IActionsUser_ActivistUser
    {
        public static string CashDefultSet { get; } = Configuration.ActivistCashDefultSet;

        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Cash { get; set; }

        public ActivistUser() : base()
        {
            UserType = "activist";
            RunActions(this);
        }
        public ActivistUser(IUsers user) : this() { CopyUser(user); }

        //Actions
        public async Task<IActivistUser> GetCashAmountAsync(Modes mode = null) =>
            await actionsUser.GetCashAmountAsync(mode);
    }
}
