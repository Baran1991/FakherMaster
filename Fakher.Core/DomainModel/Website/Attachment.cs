namespace Fakher.Core.Website
{
    public class Attachment
    {
        public virtual string Name { get; set; }
        public virtual string MIMEType { get; set; }
        public virtual byte[] Bytes { get; set; }
    }
}