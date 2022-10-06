using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using PromotItLibrary.Classes;
using PromotItLibrary.Models;
using PromotItLibrary.Patterns;
using PromotItLibrary.Patterns.Actions;
using PromotItLibrary.Patterns.Actions.Actions_Interfaces;
using PromotItLibrary.Patterns.DataTables;
using PromotItLibrary.Patterns.LinkedLists;
using PromotItLibrary.Patterns.LinkedLists.LinkedList_Function_State.LinkedLists_Interfaces;
using System;
using System.Collections.Generic;

using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi.Core.Models;

namespace PromotItLibrary.Interfaces.Variables_Interfaces
{
    public interface ITweet_Variables
    {
        string Id { get; set; }
        ICampaign Campaign { get; set; }
        IUsers ActivistUser { get; set; }
        decimal Cash { get; set; }
        int Retweets { get; set; }
        bool IsApproved { get; set; }
    }
}
