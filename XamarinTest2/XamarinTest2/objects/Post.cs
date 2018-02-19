using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace XamarinTest2.objects
{
    public class Post
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string userId { get; set; }
        public string title { get; set; }
        public string body { get; set; }

        public Post() 
        {
        }

    }
}
