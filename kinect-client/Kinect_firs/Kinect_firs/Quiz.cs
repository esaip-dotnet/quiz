using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinect_firs
{
    public class Quiz
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        public List<Question> Questions { get; set; }
    }
}
