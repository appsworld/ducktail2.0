using System.Collections.Generic;
using iCollector.Util;

namespace iCollector.Job.Model;

internal class SocialBusinessResourceResult
{
	public bool needFetchAgain;

	public List<DynamicObject> BusinessAccounts { get; set; }
}
