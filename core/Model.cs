using System;
using System.Collections.Generic;

namespace core
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public virtual Theme Theme { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public virtual Blog Blog { get; set; }
    }

    public class Theme
    {
        public int ThemeId { get; set; }
        public string Name { get; set; }
        public string TitleColor { get; set; }
    }

    
}
