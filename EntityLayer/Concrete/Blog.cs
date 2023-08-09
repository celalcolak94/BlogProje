﻿namespace EntityLayer.Concrete
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
        public string BlogContent { get; set; }
        public string? BlogThumbnailImage { get; set; }
        public string BlogImage { get; set; }
        public DateTime BlogCreateDate { get; set; }
        public bool BlogStatus { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
		public int? WriterId { get; set; }
		public Writer Writer { get; set; }
		public List<Comment> Comments { get; set; }
    }
}
