using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Core.Entities
{
    public class Album
    {
        public int id { get; set; }
        public int userId { get; set; }
        public string? title { get; set; }
    }
}
