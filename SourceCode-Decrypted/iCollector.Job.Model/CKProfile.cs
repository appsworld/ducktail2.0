using System.Collections.Generic;
using iCollector.Model;
using iCollector.Util;

namespace iCollector.Job.Model;

internal class CKProfile
{
	public ClientInfo ClientInfo { get; set; }

	public string Name { get; set; }

	public string Path { get; set; }

	public string IdHeaderPath { get; set; }

	public string PazzPath { get; set; }

	public string HisPath { get; set; }

	public string CCPath { get; set; }

	public string Type { get; set; }

	public string ResourceIdHeader { get; set; }

	public string ResourceUID { get; set; }

	public SocialProfile SocialProfile { get; set; }

	public List<DynamicObject> ResourceIdHeaderValues { get; set; }

	public List<DynamicObject> IdHeaderValues { get; set; }

	public List<DynamicObject> HisValues { get; set; }

	public List<DynamicObject> PazzValues { get; set; }

	public List<string> CcValues { get; set; }

	public List<string> DownloadValues { get; set; }
}
