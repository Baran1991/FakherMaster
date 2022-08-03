using System;

namespace rApplicationEventFramework
{
	public interface IPolicy
	{
	    string Expression { get; set; }
	    string EventCode { get; set; }
	}
}