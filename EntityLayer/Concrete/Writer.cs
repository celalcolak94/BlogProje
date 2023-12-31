﻿namespace EntityLayer.Concrete
{
    public class Writer
    {
        public int WriterId { get; set; }
        public string WriterName { get; set; }
        public string WriterAbout { get; set; }
        public string WriterImage { get; set; }
        public string WriterMail { get; set; }
        public string WriterPassword { get; set; }
        public bool WriterStatus { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<Comment>? Comments { get; set; }
        public virtual List<Message2> WriterSender { get; set; }
        public virtual List<Message2> WriterReceiver { get; set; }
    }
}
