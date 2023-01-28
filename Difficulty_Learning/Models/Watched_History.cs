using Microsoft.EntityFrameworkCore;
using System;

namespace Difficulty_Learning.Models
{
    [Keyless]
    public class Watched_History
    {
      
        public int WatchedHistory_ID { get; set; }
        public int WatchedHistory_UserID { get; set; }
        public int WatchedHistory_CourseID { get; set; }
        public DateTime WatchedHistory_Timeing { get; set; }
      

    }
}
