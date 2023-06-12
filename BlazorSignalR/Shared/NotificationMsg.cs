using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSignalR.Shared
{
    public class NotificationMsg
    {
        public int Id { get; set; }
        public string Message { get; set; } = null!;
    }
}
