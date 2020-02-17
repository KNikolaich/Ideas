using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class WebContext : ContextAdapter
    {
        public static List<Task> GetTasks(int i)
        {
            var context = new WebContext();
            return context.Tasks.Where(t => i < 0 || t.UserId == i).ToList();
        }
    }
}
