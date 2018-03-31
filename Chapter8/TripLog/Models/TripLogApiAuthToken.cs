using System;
using System.Collections.Generic;
using System.Text;

namespace TripLog.Models
{
	public class TripLogApiUser
	{
		public string UserId { get; set; }
	}

	public class TripLogApiAuthToken
	{
		public TripLogApiUser User { get; set; }
		public string AuthenticationToken { get; set; }
	}
}
