using System;

namespace rApplicationEventFramework
{
	public interface IApplicationEvent
	{
        string Date { get; set; }
        string Time { get; set; }
        string ObjectId { get; set; }
        string Description { get; set; }
        string Entity { get; set; }
        string Operator { get; set; }
	}
}