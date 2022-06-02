using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MintClientControl.Models
{
    public enum Rights
    {
        Admin,
        Moderator
    }
    public class Functions
    {
        public int FuncId { get; set; }
        public string Title { get; set; }
        public string Command { get; set; }
        public int UserId { get; set; }
        public Rights FuncRights { get; set; }
    }

}
