using System.Collections.Generic;
using iCollector.Util;

namespace iCollector.Job.Model;

internal class SocialResourceResult
{
	public bool needFetchAgain = true;

	public List<DynamicObject> Accounts { get; set; }
}
