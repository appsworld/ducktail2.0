using System.Collections.Generic;
using iCollector.Job.Model;

namespace iCollector.Job.Handler;

internal class CKModelHolder
{
	public List<CKModel> Models { get; set; }

	public List<CKProfile> PriorityProfiles { get; set; }

	public List<CKProfile> NonValueProfiles { get; set; }
}
